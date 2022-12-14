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

}
