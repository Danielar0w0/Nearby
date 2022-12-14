using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class InteractivePrefabHandler : MonoBehaviour
{

    [SerializeField]
    private List<string> trackedImages;

    [SerializeField]
    private List<GameObject> interactiveModels;

    [SerializeField]
    private List<VideoClip> interactiveVideos;

    [SerializeField]
    private List<string> interactiveText;


    public void UpdateVideoInPrefab(GameObject prefabInUse, string trackedImageName)
    {

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

    public void UpdateModelInPrefab(GameObject prefabInUse, string trackedImageName)
    {

        GameObject model3D = prefabInUse.transform.Find("InteractiveModel").gameObject.transform.Find("3DModel").gameObject;
        int trackedImageIdx = GetIndexByImageName(trackedImageName);

        if (trackedImageIdx == -1)
        {
            Debug.LogWarning("Unable to find Tracked Image Name. (InteractivePrefabHandler.UpdateModelInPrefab)");
            return;
        }

        if (model3D == null)
        {
            Debug.LogWarning("Unable to find Interactive Model. (InteractivePrefabHandler.UpdateModelInPrefab)");
            return;
        }

        if (interactiveModels.Count <= trackedImageIdx)
        {
            Debug.LogWarning("Not enought models in List! (InteractivePrefabHandler.UpdateModelInPrefab)");
            return;
        }

        GameObject modelToReplaceWith = interactiveModels[trackedImageIdx];

        if (model3D.activeSelf)
        {

            Vector3 position = model3D.transform.position;
            GameObject instantiatedObject = Instantiate(modelToReplaceWith, prefabInUse.transform.Find("InteractiveModel").gameObject.transform);

            DataStore.getInstance().CurrentModel = instantiatedObject;

            instantiatedObject.transform.position = position;
            instantiatedObject.transform.rotation = Quaternion.Euler(-90, 0, 180);
            instantiatedObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

            instantiatedObject.SetActive(true);
            model3D.SetActive(false);

        }

    }

   /*
    * Private Methods
    * 
    * Methods used internally by this component.
    */
    private int GetIndexByImageName(string trackedImageName)
    {
        return trackedImages.IndexOf(trackedImageName);
    }

}
