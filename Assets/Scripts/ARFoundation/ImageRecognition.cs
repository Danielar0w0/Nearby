using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageRecognition : MonoBehaviour
{

    [SerializeField]
    private string spotTrackedImageName;

    private ARTrackedImageManager trackedImageManager;

    private void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
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

            if (isSpotImage(trackedImage))
            {
                GetInteractiveModelHandler().CenterInteractiveModel(trackedImage);
            }
            else
            {
                GetInteractivePrefabHandler().CenterInteractivePrefab(trackedImage);
            }

        }

        foreach (var trackedImage in eventArgs.updated)
        {

            string trackedImageName = trackedImage.referenceImage.name;

            if (trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
            {
                if (isSpotImage(trackedImage))
                {
                    GetInteractiveModelHandler().CenterInteractiveModel(trackedImage);
                }
                else
                {

                    GetInteractivePrefabHandler().CenterInteractivePrefab(trackedImage);

                    GetInteractivePrefabHandler().UpdateVideoInPrefab(trackedImageName);
                    GetInteractivePrefabHandler().UpdateModelInPrefab(trackedImageName);

                }
            }
            else
            {
                if (isSpotImage(trackedImage))
                {
                    GetInteractiveModelHandler().HideInteractiveModel();
                }
                else
                {
                    GetInteractivePrefabHandler().HideInteractivePrefab(trackedImage);
                }
            }

        }

        foreach (var trackedImage in eventArgs.removed)
        {

            if (isSpotImage(trackedImage))
            {
                GetInteractiveModelHandler().HideInteractiveModel();
            }
            else
            {
                GetInteractivePrefabHandler().HideInteractivePrefab(trackedImage);
            }

        }

    }

    private bool isSpotImage(ARTrackedImage trackedImage)
    {
        return trackedImage.referenceImage.name == spotTrackedImageName;
    }

    private InteractivePrefabHandler GetInteractivePrefabHandler()
    {
        return GetComponentInParent<InteractivePrefabHandler>();
    }

    private InteractiveModelHandler GetInteractiveModelHandler()
    {
        return GetComponentInParent<InteractiveModelHandler>();
    }

}
