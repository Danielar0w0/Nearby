using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ImageRecognition : MonoBehaviour
{

    [SerializeField]
    private List<string> trackedImagesNames;

    [SerializeField]
    private List<GameObject> placeablePrefabs;

    [SerializeField]
    private List<VideoClip> videoClips;

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
            GameObject prefabInUse = UpdatePrefab(trackedImage);
            UpdateVideoInPrefab(prefabInUse);
            Debug.Log("Image added " +  trackedImage.referenceImage.name);
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            if (trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
            {
                GameObject prefabInUse = UpdatePrefab(trackedImage);
                UpdateVideoInPrefab(prefabInUse);
            }
            Debug.Log("Image updated " + trackedImage.referenceImage.name + "; State: " + trackedImage.trackingState);
        }

        foreach (var trackedImage in eventArgs.removed)
        {
           
            Debug.Log("IMAGE REMOOOOOOOOOOVED");
            spawnedPrefabs[trackedImage.referenceImage.name].SetActive(false);
        }

    }

    private GameObject UpdatePrefab(ARTrackedImage trackedImage)
    {

        string name = trackedImage.referenceImage.name;
        Vector3 position = trackedImage.transform.position;
        Quaternion rotation = trackedImage.transform.rotation;

        GameObject prefab = spawnedPrefabs[name];
        

        prefab.transform.position = position;
        prefab.transform.rotation = rotation;
        prefab.SetActive(true);

        // HideOtherPrefabs(trackedImage);

        return prefab;

    }

    private void HideOtherPrefabs(ARTrackedImage trackedImage)
    {
        foreach (GameObject go in spawnedPrefabs.Values)
        {
            int gameObjectIdx = spawnedPrefabs.Values.ToList().IndexOf(go);
            string imageNameAssociatedWithGameObject = trackedImagesNames[gameObjectIdx];

            if (imageNameAssociatedWithGameObject != trackedImage.referenceImage.name)
            {
                go.SetActive(false);
            }

        }
    }

    private void UpdateVideoInPrefab(GameObject prefabInUse)
    {

        VideoPlayer videoPlayer = prefabInUse.GetComponentInChildren<VideoPlayer>();
        int prefabIdx = spawnedPrefabs.Values.ToList().IndexOf(prefabInUse);

        if (videoPlayer != null)
        {
            videoPlayer.clip = videoClips[prefabIdx];
        }

    }

}
