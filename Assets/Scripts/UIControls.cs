using UnityEngine;
using UnityEngine.Video;

public class UIControls : MonoBehaviour
{

    public void onPlayClicked()
    {
        GameObject currentPrefab = DataStore.getInstance().CurrentPrefab;

        if (currentPrefab == null) return;

        VideoPlayer videoPlayer = currentPrefab.transform.Find("Video").gameObject.transform.Find("Video Player").gameObject.GetComponentInChildren<VideoPlayer>();

        videoPlayer.Play();

    }

    public void onPauseClicked()
    {
        GameObject currentPrefab = DataStore.getInstance().CurrentPrefab;

        if (currentPrefab == null) return;

        VideoPlayer videoPlayer = currentPrefab.transform.Find("Video").gameObject.transform.Find("Video Player").gameObject.GetComponentInChildren<VideoPlayer>();
        videoPlayer.Pause();

    }

    public void onRemoveClicked()
    {
        GameObject currentPrefab = DataStore.getInstance().CurrentPrefab;
        currentPrefab.SetActive(false);
    }

    public void onSelectModelClick()
    {

        GameObject[] objectsInScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject gameObject in objectsInScene)
        {
            if (gameObject.name == "AR Video" && gameObject.activeSelf)
            {
                DataStore.getInstance().CurrentPrefab = gameObject.transform.Find("InteractiveModel").gameObject.transform.Find("3DModel").gameObject;
            }
        }

    }

}
