using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.ARFoundation;

public class InteractivePrefabHandler : MonoBehaviour
{

    [SerializeField]
    private GameObject interactivePrefab;

    [SerializeField]
    private List<string> trackedImagesNames;

    [SerializeField]
    private List<GameObject> interactiveModels;

    [SerializeField]
    private List<VideoClip> interactiveVideos;

    [SerializeField]
    private List<string> interactiveText;

    // Prefabs created for each image. Each registered image had a prefab associated.
    private Dictionary<string, GameObject> instantiatedPrefabs = new Dictionary<string, GameObject>();

    private void Awake()
    {

        foreach (string trackedImageName in trackedImagesNames) {
            
            GameObject prefabInstance = Instantiate(interactivePrefab, Vector3.zero, Quaternion.identity);
            prefabInstance.name = trackedImageName + "_Interactive";

            instantiatedPrefabs.Add(trackedImageName, prefabInstance);
        
        }

        interactivePrefab.SetActive(false);

    }

    public void CenterInteractivePrefab(ARTrackedImage trackedImage)
    {

        string trackedImageName = trackedImage.referenceImage.name;
        GameObject prefabInstanceForImage = instantiatedPrefabs[trackedImageName];

        prefabInstanceForImage.transform.position = trackedImage.transform.position;
        prefabInstanceForImage.transform.rotation = trackedImage.transform.rotation;
        prefabInstanceForImage.SetActive(true);

    }

    public void HideInteractivePrefab(ARTrackedImage trackedImage)
    {

        string trackedImageName = trackedImage.referenceImage.name;
        GameObject prefabInstanceForImage = instantiatedPrefabs[trackedImageName];

        prefabInstanceForImage.SetActive(false);

    }

    public void UpdateVideoInPrefab(string trackedImageName)
    {

        GameObject prefabInUse = instantiatedPrefabs[trackedImageName];
        VideoPlayer videoPlayer = prefabInUse.GetComponentInChildren<VideoPlayer>();
        int trackedImageIdx = GetIndexByImageName(trackedImageName);

        if (trackedImageIdx == -1)
        {
            Debug.LogWarning("Unable to find Tracked Image Name. (InteractivePrefabHandler.UpdateVideoInPrefab)");
            return;
        }

        if (videoPlayer == null)
        {
            Debug.LogWarning("Unable to find Video Player. (InteractivePrefabHandler.UpdateVideoInPrefab)");
            return;
        }

        if (interactiveVideos.Count <= trackedImageIdx)
        {
            Debug.LogWarning("Not enought videos in List! (InteractivePrefabHandler.UpdateVideoInPrefab)");
            return;
        }

        videoPlayer.clip = interactiveVideos[trackedImageIdx];

    }

    public void UpdateTextInPrefab(string trackedImageName)
    {

        GameObject prefabInUse = instantiatedPrefabs[trackedImageName];
        TextMeshPro textMesh = prefabInUse.GetComponentInChildren<TextMeshPro>();
        int trackedImageIdx = GetIndexByImageName(trackedImageName);

        if (trackedImageIdx == -1)
        {
            Debug.LogWarning("Unable to find Tracked Image Name. (InteractivePrefabHandler.UpdateTextInPrefab)");
            return;
        }

        if (textMesh == null)
        {
            Debug.LogWarning("Unable to find Text Mesh. (InteractivePrefabHandler.UpdateTextInPrefab)");
            return;
        }

        if (interactiveVideos.Count <= trackedImageIdx)
        {
            Debug.LogWarning("Not enought videos in List! (InteractivePrefabHandler.UpdateTextInPrefab)");
            return;
        }

        textMesh.text = interactiveText[trackedImageIdx];

    }

    public void UpdateModelInPrefab(string trackedImageName)
    {

        if (trackedImageName == null)
        {
            Debug.LogWarning("Tracked Image null");
            return;
        }

        GameObject prefabInUse = instantiatedPrefabs[trackedImageName];

        if (prefabInUse == null)
        {
            Debug.Log("Prefab In Use null");
            return;
        }

        Transform model3DTransform = prefabInUse.transform.Find("InteractiveModel/3DModelSelector/3DModel");
        
        // Expected in second iteraction and onwards.
        if (model3DTransform == null) return;

        GameObject model3D = model3DTransform.gameObject;
        int trackedImageIdx = GetIndexByImageName(trackedImageName);

        if (trackedImageIdx == -1)
        {
            Debug.Log("Unable to find Tracked Image Name. (InteractivePrefabHandler.UpdateModelInPrefab)");
            return;
        }

        if (model3D == null)
        {
            Debug.Log("Unable to find Interactive Model. (InteractivePrefabHandler.UpdateModelInPrefab)");
            return;
        }

        if (interactiveModels.Count <= trackedImageIdx)
        {
            Debug.Log("Not enought models in List! (InteractivePrefabHandler.UpdateModelInPrefab)");
            return;
        }

        GameObject modelToReplaceWith = interactiveModels[trackedImageIdx];

        if (model3D != null)
        {

            Vector3 position = model3D.transform.position;
            float scaleNormalization = model3D.transform.localScale.x;

            GameObject instantiatedObject = Instantiate(modelToReplaceWith, prefabInUse.transform.Find("InteractiveModel/3DModelSelector").gameObject.transform);

            instantiatedObject.name = modelToReplaceWith.name;
            instantiatedObject.transform.position = position;
            instantiatedObject.transform.rotation = Quaternion.Euler(-90, 0, 180);
            instantiatedObject.transform.localScale = new Vector3(scaleNormalization, scaleNormalization, scaleNormalization);

            instantiatedObject.SetActive(true);
            
            Destroy(model3D);

        }

    }

   /*
    * Private Methods
    * 
    * Methods used internally by this component.
    */
    private int GetIndexByImageName(string trackedImageName)
    {
        return trackedImagesNames.IndexOf(trackedImageName);
    }

}
