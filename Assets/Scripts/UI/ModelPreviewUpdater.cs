using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ModelPreviewUpdater : MonoBehaviour
{   

    [SerializeField]
    private Text modelName;

    void Update()
    {
        updateModel();
    }

    void updateModel()
    {
        GameObject previewModel = ModelPreviewData.getInstance().PreviewModel;
        modelName.text = previewModel.name;
    }

}
