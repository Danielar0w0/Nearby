using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataService : MonoBehaviour
{

    private static DataService instance;

    private readonly DataStore dataStore;
    private readonly SpotData spotData;
    private readonly ModelPreviewData modelPreviewData;
    private readonly SelectedModelData selectedModelData;

    private DataService() {

        dataStore = DataStore.getInstance();

        spotData = SpotData.getInstance();
        modelPreviewData = ModelPreviewData.getInstance();
        selectedModelData = SelectedModelData.getInstance();

    }

    public void UpdateCurrentModel(bool isInteractive)
    {

        if (isInteractive)
        {
            GameObject spotInstance = Instantiate(dataStore.CurrentModel);
            GameObject modelPreviewInstance = Instantiate(dataStore.CurrentModel);

            spotInstance.name = dataStore.CurrentModel.name;
            modelPreviewInstance.name = dataStore.CurrentModel.name;

            spotInstance.SetActive(false);
            modelPreviewInstance.SetActive(false);

            spotData.SpotInteractableModel = spotInstance;
            modelPreviewData.PreviewModel = modelPreviewInstance;

        }

        selectedModelData.SelectedModel = dataStore.CurrentModel;

    }

    public static DataService getInstance()
    {
        if (instance == null)
            instance = new DataService();
        return instance;
    }

}
