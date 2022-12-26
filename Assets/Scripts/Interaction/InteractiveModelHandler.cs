using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InteractiveModelHandler : MonoBehaviour
{

    [SerializeField]
    private string spotTrackedImageName;

    [SerializeField]
    private GameObject spotModelPrefab;

    private SpotData spotDataSingleton = SpotData.getInstance();

    public void CenterInteractiveModel(ARTrackedImage trackedImage)
    {
        
        string trackedImageName = trackedImage.referenceImage.name;

        // If the tracked image is not the "Spot" image, return
        if (!trackedImageName.Equals(spotTrackedImageName)) return; 

        // If no model was selected yet, return
        if (spotDataSingleton.SpotInteractableModel == null) return;

        if (!spotDataSingleton.IsBeingDisplayed)
        {
            spotDataSingleton.SpotTrackedObject = SummonInteractiveModel(trackedImage);
            spotDataSingleton.IsBeingDisplayed = true;
        } else
        {
            if (spotDataSingleton.SpotTrackedObject == null) return;
            spotDataSingleton.SpotTrackedObject.transform.position = trackedImage.transform.position;
        }

    }

    public void HideInteractiveModel()
    {

        GameObject trackedObject = spotDataSingleton.SpotTrackedObject;

        if (trackedObject == null) return;

        trackedObject.SetActive(false);

        spotDataSingleton.SpotTrackedObject = null;
        spotDataSingleton.IsBeingDisplayed = false;

    }

    private GameObject SummonInteractiveModel(ARTrackedImage trackedImage)
    {
        
        GameObject storedInteractiveModelInstance = spotDataSingleton.SpotInteractableModel;
        GameObject placeholderInstance = Instantiate(spotModelPrefab);

        // Get the size of the tracked image. Once the image is a square we will only consider the x size
        float imageMagnitude = trackedImage.extents.x;

        // Set the scale of the Instantiated Model Prefab to match the size of the tracked image
        placeholderInstance.transform.localScale = new Vector3(imageMagnitude, imageMagnitude, imageMagnitude);

        // Set the position and rotation of the Instantiated Model Prefab to match the size of the tracked image
        placeholderInstance.transform.position = trackedImage.transform.position;
        placeholderInstance.transform.rotation = trackedImage.transform.rotation;

        Transform placeholderRoot = placeholderInstance.transform;
        GameObject placeholderChildObject = placeholderRoot.Find("BoundingBox/3DSpotModel").gameObject;
           
        // Placing the interactive model with same physic caracteristics as the placeholder cube
        storedInteractiveModelInstance.transform.position = placeholderChildObject.transform.position;
        storedInteractiveModelInstance.transform.rotation = placeholderChildObject.transform.rotation;
        storedInteractiveModelInstance.transform.parent = placeholderChildObject.transform.parent;

        // Set Scale relative to parent - relative to BoundingBox in this case 
        storedInteractiveModelInstance.transform.localScale = new Vector3(imageMagnitude/2, imageMagnitude/2, imageMagnitude/2);

        // Enable created objects
        storedInteractiveModelInstance.SetActive(true);
        placeholderInstance.SetActive(true);
        
        Destroy(placeholderChildObject);

        return placeholderInstance;

    }

}
