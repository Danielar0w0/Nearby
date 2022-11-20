using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ImageRecognition : MonoBehaviour
{

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
            Debug.Log("Image added " +  trackedImage.name);
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            Debug.Log("Image updated " +  trackedImage.name);
        }

        foreach (var trackedImage in eventArgs.removed)
        {
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
