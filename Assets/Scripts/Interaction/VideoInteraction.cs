using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoInteraction : MonoBehaviour
{

    private VideoPlayer videoPlayer;

    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    void OnEnable()
    {
        EventManager.OnPlayClickedEvent += PlayVideo;
        EventManager.OnPauseClickedEvent += PauseVideo;
        EventManager.OnSoundUpClickedEvent += IncreaseVideoSound;
        EventManager.OnSoundDownClickedEvent += DecreaseVideoSound;
        EventManager.OnSoundMuteClickedEvent += MuteVideoSound;
    }

    void OnDisable()
    {
        EventManager.OnPlayClickedEvent -= PlayVideo;
        EventManager.OnPauseClickedEvent -= PauseVideo;
        EventManager.OnSoundUpClickedEvent -= IncreaseVideoSound;
        EventManager.OnSoundDownClickedEvent -= DecreaseVideoSound;
        EventManager.OnSoundMuteClickedEvent -= MuteVideoSound;
    }

    void PlayVideo()
    {
        videoPlayer.Play();
    }

    void PauseVideo()
    {
        videoPlayer.Pause();
    }

    void IncreaseVideoSound()
    {
        videoPlayer.SetDirectAudioVolume(0, videoPlayer.GetDirectAudioVolume(0)+0.1f);
    }

    void DecreaseVideoSound()
    {
        videoPlayer.SetDirectAudioVolume(0, videoPlayer.GetDirectAudioVolume(0) - 0.1f);
    }

    void MuteVideoSound()
    {
        videoPlayer.SetDirectAudioVolume(0, 0f);
    }

}
