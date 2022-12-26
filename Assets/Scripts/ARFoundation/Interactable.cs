using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class Interactable : MonoBehaviour
{
    [SerializeField]
    private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    [SerializeField]
    private GameObject placedPrefab;

    [SerializeField]
    private int maxPlacedObjects;

    private Camera arCamera;
    private Logger logger;

    // Handle placed objects
    private GameObject lastSelectedObject;
    private int nPlacedObjects;

    // Handle touch input
    private Vector2 touchPosition = default;

    // Handle scale
    float initialDistance;
    Vector3 initialScale;

    private GameObject PlacedPrefab 
    {
        get {return placedPrefab;}
        set {placedPrefab = value;}
    }

    void Awake()
    {
        arCamera = GameObject.Find("AR Camera").GetComponent<Camera>(); 
        logger = GameObject.Find("AR Logger").GetComponent<Logger>();
        nPlacedObjects = 0;

        // TODO: Add a way to change the prefab
        // redButton.onClick.AddListener(() => ChangePrefabSelection("ARRed"));

        // logger.LogInfo("Interactable: Awake");
    }

    private void ChangePrefabSelection(string name)
    {
        GameObject loadedGameObject = Resources.Load<GameObject>($"Prefabs/{name}");
        if(loadedGameObject != null)
        {
            PlacedPrefab = loadedGameObject;
            Debug.Log($"Game object with name {name} was loaded");
        }
        else 
        {
            Debug.Log($"Unable to find a game object with name {name}");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount == 0)
            return;

        // RaycastHit hit;
        Ray ray = arCamera.ScreenPointToRay(Input.GetTouch(0).position);

        // Handle drag motion
        if(Input.touchCount == 1)
            handleDrag();

        // Handle pinch motion to scale objects
        else if (Input.touchCount == 2)
           handleScale();
    }

    private void handleDrag()
    {
        Touch touch = Input.GetTouch(0);
            
        touchPosition = touch.position;

        // Select placed object
        if(touch.phase == TouchPhase.Began)
        {
            selectPlacedObject(touch.position);
        }

        // Stop selecting placed object
        /*
        if(touch.phase == TouchPhase.Ended)
        {
            lastSelectedObject.Selected = false;
        }
        */

        // Move selected object
        if(arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            if (lastSelectedObject == null && nPlacedObjects < maxPlacedObjects)
            {
                // lastSelectedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation).GetComponent<PlacementObject>();
                lastSelectedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
                nPlacedObjects++;
            }
            else 
            {
                lastSelectedObject.transform.position = hitPose.position;
                lastSelectedObject.transform.rotation = hitPose.rotation;
            }
        }
    }

    private void handleScale()
    {
        Touch firstTouch = Input.GetTouch(0);
        Touch secondTouch = Input.GetTouch(1);

        // If any of the touches are cancelled or ended, do nothing
        if (firstTouch.phase == TouchPhase.Ended || firstTouch.phase == TouchPhase.Canceled ||
            secondTouch.phase == TouchPhase.Ended || secondTouch.phase == TouchPhase.Canceled)
        {
            return;
        }

        // Select placed object
        if(firstTouch.phase == TouchPhase.Began)
        {
            selectPlacedObject(firstTouch.position);
        }

        // Stop selecting placed object
        /*
        if(firstTouch.phase == TouchPhase.Ended)
        {
            lastSelectedObject.Selected = false;
        }
        */

        // Scale selected object
        if (arRaycastManager.Raycast(firstTouch.position, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            if (lastSelectedObject != null)
            {
                // Get the distance between the two touches
                float currentDistance = Vector2.Distance(firstTouch.position, secondTouch.position);

                // If this is the first frame of the pinch, store the distance
                if (initialDistance == 0)
                {
                    initialDistance = currentDistance;
                    initialScale = lastSelectedObject.transform.localScale;
                }
                else
                {
                    // Calculate the scale factor
                    float scaleFactor = currentDistance / initialDistance;

                    // Scale the object
                    lastSelectedObject.transform.localScale = initialScale * scaleFactor;
                }
               
            }
        }
    }

    // TODO: Fix Selection
    /*
    private void selectPlacedObject(Vector2 touchPosition)
    {
        Ray ray = arCamera.ScreenPointToRay(touchPosition);
        RaycastHit hitObject;

        if(Physics.Raycast(ray, out hitObject))
        {
            lastSelectedObject = hitObject.transform.GetComponent<PlacementObject>();
            logger.LogInfo($"Interactable: Selecting object {lastSelectedObject.name}");

            if(lastSelectedObject != null)
            {
                PlacementObject[] allObjects = FindObjectsOfType<PlacementObject>();

                foreach(PlacementObject placementObject in allObjects)
                {
                    placementObject.Selected = placementObject == lastSelectedObject;
                }
                
                lastSelectedObject.Selected = true;
            }
        }
    }
    */

    private void selectPlacedObject(Vector2 touchPosition) {
        Ray ray = arCamera.ScreenPointToRay(touchPosition);
        RaycastHit hitObject;

        if(Physics.Raycast(ray, out hitObject))
        {
            lastSelectedObject = null;
            if (hitObject.collider.gameObject.tag == "Spawnable")
            {
                lastSelectedObject = hitObject.collider.gameObject;
                // logger.LogInfo($"Interactable: Selecting object {lastSelectedObject.name}");
            }
        }
    }
}
