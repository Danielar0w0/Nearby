using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ImageRecognition : MonoBehaviour
{

    public TextMeshProUGUI debugText;
    public List<string> imageNamesList;
    public List<GameObject> gameObjectsList;
    private ARTrackedImageManager trackedImageManager;

    private void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    public void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    public void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    public void OnImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {

            string imageName = trackedImage.referenceImage.name.ToString();
            int imageNameIndex = imageNamesList.IndexOf(imageName);

            // trackedImageManager.trackedImagePrefab = gameObjectsList[imageNameIndex];

            debugText.text = "Image added " + gameObjectsList[imageNameIndex];

            //debugText.text = "Image added " + trackedImage.referenceImage.name.ToString();
            Debug.Log("Image added " +  trackedImage.name);

        }

        foreach (var trackedImage in eventArgs.updated)
        {

            // debugText.text = "Image updated " + trackedImage.referenceImage.name.ToString();
            Debug.Log("Image updated " +  trackedImage.name);

        }

        foreach (var trackedImage in eventArgs.removed)
        {
            // debugText.text = "Image removed " + trackedImage.referenceImage.name.ToString();
            Debug.Log("Image removed " +  trackedImage.name);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
