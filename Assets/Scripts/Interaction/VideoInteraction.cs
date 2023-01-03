using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoInteraction : MonoBehaviour
{

    void OnEnable()
    {
        EventManager.OnPlayClickedEvent += PlayVideo;
        EventManager.OnPauseClickedEvent += PauseVideo;
        EventManager.OnSoundUpClickedEvent += IncreaseVideoSound;
        EventManager.OnSoundDownClickedEvent += DecreaseVideoSound;
        EventManager.OnSoundMuteClickedEvent += MuteVideoSound;
        EventManager.OnVideoForwardClickedEvent += ForwardVideo;
        EventManager.OnVideoBackwardClickedEvent += BackwardVideo;
    }

    void OnDisable()
    {
        EventManager.OnPlayClickedEvent -= PlayVideo;
        EventManager.OnPauseClickedEvent -= PauseVideo;
        EventManager.OnSoundUpClickedEvent -= IncreaseVideoSound;
        EventManager.OnSoundDownClickedEvent -= DecreaseVideoSound;
        EventManager.OnSoundMuteClickedEvent -= MuteVideoSound;
        EventManager.OnVideoForwardClickedEvent -= ForwardVideo;
        EventManager.OnVideoBackwardClickedEvent -= BackwardVideo;
    }

    void PlayVideo()
    {
        GetCurrentVideoPlayer().Play();
    }

    void PauseVideo()
    {
        GetCurrentVideoPlayer().Pause();
    }

    void IncreaseVideoSound()
    {
        GetCurrentVideoPlayer().SetDirectAudioVolume(0, GetCurrentVideoPlayer().GetDirectAudioVolume(0)+0.1f);
    }

    void DecreaseVideoSound()
    {
        GetCurrentVideoPlayer().SetDirectAudioVolume(0, GetCurrentVideoPlayer().GetDirectAudioVolume(0) - 0.1f);
    }

    void MuteVideoSound()
    {
        GetCurrentVideoPlayer().SetDirectAudioVolume(0, 0f);
    }

    void ForwardVideo()
    {
        GetCurrentVideoPlayer().time += 5f;
    }

    void BackwardVideo()
    {
        GetCurrentVideoPlayer().time -= 5f;
    }

    private VideoPlayer GetCurrentVideoPlayer()
    {
        GameObject selectedModel = DataStore.getInstance().CurrentModel;
        VideoPlayer videoPlayer;

        if (selectedModel == null)
            videoPlayer = GetComponent<VideoPlayer>();
        else
            videoPlayer = selectedModel.transform.Find("Video").transform.GetComponentInChildren<VideoPlayer>();

        return videoPlayer;

    }

}
