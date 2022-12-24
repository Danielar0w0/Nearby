using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InteractiveModelHandler : MonoBehaviour
{

    [SerializeField]
    private string spotTrackedImageName;

    private SpotData spotDataSingleton = SpotData.getInstance();

    public void SummonInteractiveModel()
    {
        spotDataSingleton.SpotInteractableModel = DataStoreAccessor.getInstance().InstantiateCurrentModel();
    } 

    public void CenterInteractiveModel(ARTrackedImage trackedImage)
    {
        
        string trackedImageName = trackedImage.referenceImage.name;

        if (!trackedImageName.Equals(spotTrackedImageName)) return;


        if (!spotDataSingleton.IsBeingDisplayed)
        {
            SummonInteractiveModel();
            spotDataSingleton.IsBeingDisplayed = true;
        } else
        {
            GameObject prefabModelInstance = spotDataSingleton.SpotInteractableModel;

            prefabModelInstance.transform.position = trackedImage.transform.position;
            prefabModelInstance.transform.localScale = new Vector3(0.025f, 0.025f, 0.025f);

            prefabModelInstance.SetActive(true);
        }

    }

    public void HideInteractiveModel()
    {

        GameObject prefabModelInstance = spotDataSingleton.SpotInteractableModel;

        prefabModelInstance.SetActive(false);

        spotDataSingleton.IsBeingDisplayed = false;

    }

}
