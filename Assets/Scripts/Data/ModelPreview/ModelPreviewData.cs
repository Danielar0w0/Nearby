using UnityEngine;

public class ModelPreviewData
{

    private static ModelPreviewData instance;
    
    public GameObject PreviewModel { get; set; }

    private ModelPreviewData() { }

    public static ModelPreviewData getInstance()
    {
        if (instance == null)
            instance = new ModelPreviewData();
        return instance;
    }

}
