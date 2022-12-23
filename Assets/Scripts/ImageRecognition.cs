using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.ARFoundation;

public class ImageRecognition : MonoBehaviour
{

    [SerializeField]
    private List<string> trackedImagesNames;

    [SerializeField]
    private List<GameObject> placeablePrefabs;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    private ARTrackedImageManager trackedImageManager;

    private void Awake()
    {

        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        for (int placeablePrefabIdx = 0; placeablePrefabIdx < placeablePrefabs.Count; placeablePrefabIdx++)
        {
            GameObject placeablePrefab = placeablePrefabs[placeablePrefabIdx];
            GameObject prefabInstance = Instantiate(placeablePrefab, Vector3.zero, Quaternion.identity);

            prefabInstance.name = placeablePrefab.name;
            spawnedPrefabs.Add(trackedImagesNames[placeablePrefabIdx], prefabInstance);
        }

    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {

        foreach (var trackedImage in eventArgs.added)
        {

            string trackedImageName = trackedImage.referenceImage.name;

            if (trackedImageName != "Spot")
            {

                GameObject prefabInUse = UpdatePrefab(trackedImage);

                GetInteractivePrefabHandler().UpdateVideoInPrefab(prefabInUse, trackedImageName);
                GetInteractivePrefabHandler().UpdateModelInPrefab(prefabInUse, trackedImageName);
                
            } else
            {
                UpdatePrefab(trackedImage);
            }

            // Debug.Log("OnImageAdded triggered. Image name: " + trackedImage.referenceImage.name);

        }

        foreach (var trackedImage in eventArgs.updated)
        {

            string trackedImageName = trackedImage.referenceImage.name;

            if (trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
            {

                GameObject prefabInUse = UpdatePrefab(trackedImage);

                GetInteractivePrefabHandler().UpdateVideoInPrefab(prefabInUse, trackedImageName);
                GetInteractivePrefabHandler().UpdateModelInPrefab(prefabInUse, trackedImageName);

            } else if (trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Limited)
            {
                if (trackedImageName != "Spot")
                {
                    HidePrefab(trackedImageName);
                } else
                {
                    DataStore.getInstance().CurrentModel.SetActive(false);
                }
                
            }

            // Debug.Log("OnImageUpdated triggered. Image name: " + trackedImage.referenceImage.name);

        }

        foreach (var trackedImage in eventArgs.removed)
        {

            string trackedImageName = trackedImage.referenceImage.name;
            HidePrefab(trackedImageName);
           
            // spawnedPrefabs[trackedImage.referenceImage.name].SetActive(false);
            // Debug.Log("OnImageRemoved triggered. Image name: " + trackedImage.referenceImage.name);

        }

    }

    private GameObject UpdatePrefab(ARTrackedImage trackedImage)
    {

        string name = trackedImage.referenceImage.name;
        Vector3 position = trackedImage.transform.position;
        Quaternion rotation = trackedImage.transform.rotation;
        GameObject prefab;

        if (trackedImage.referenceImage.name != "Spot")
        {

            prefab = spawnedPrefabs[name];

            prefab.transform.position = position;
            prefab.transform.rotation = rotation;
            prefab.SetActive(true);

            // Save Current Prefab
            // DataStore.getInstance().CurrentPrefab = prefab;

        } else
        {

            prefab = DataStore.getInstance().CurrentModel;

            prefab.transform.position = position;
            prefab.transform.localScale = new Vector3(0.025f, 0.025f, 0.025f);
            // prefab.transform.rotation = Quaternion.Euler(-90, 0, 180);
            prefab.SetActive(true);

        }

        return prefab;

    }

    private void HidePrefab(string trackedImageName)
    {

        if (!spawnedPrefabs.ContainsKey(trackedImageName)) return;

        GameObject gameObject = spawnedPrefabs[trackedImageName];
        gameObject.SetActive(false);

    }

    private InteractivePrefabHandler GetInteractivePrefabHandler()
    {
        return GetComponentInParent<InteractivePrefabHandler>();
    }

}
