using System;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class VideoTimer : MonoBehaviour
{

    [SerializeField]
    private VideoPlayer videoPlayer;

    void Update()
    {

        if (videoPlayer == null) return; 

        TextMeshPro timerText = GetComponentInChildren<TextMeshPro>();
        timerText.text = GetVideoTimeString(videoPlayer);

    }

    private ulong GetVideoDuration(VideoPlayer videoPlayer)
    {
        return (ulong)(videoPlayer.frameCount / videoPlayer.frameRate);
    }

    private uint GetVideoTime(VideoPlayer videoPlayer)
    {
        return Convert.ToUInt32(videoPlayer.time);
    }

    private string GetVideoTimeString(VideoPlayer videoPlayer)
    {
        
        uint videoCurrentTime = GetVideoTime(videoPlayer);
        ulong videoDuration = GetVideoDuration(videoPlayer);

        TimeSpan videoCurrentTimeSpan = TimeSpan.FromSeconds(videoCurrentTime);
        TimeSpan videoDurationTimeSpan = TimeSpan.FromSeconds(videoDuration);

        return videoCurrentTimeSpan.ToString(@"mm\:ss") + "|" + videoDurationTimeSpan.ToString(@"mm\:ss");

    } 

}
