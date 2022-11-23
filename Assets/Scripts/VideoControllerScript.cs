using System;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Serialization;

public class VideoControllerScript : MonoBehaviour
{

    [SerializeField]
    private string controllerType;
    [SerializeField]
    private VideoPlayer videoPlayer;

    // When clicked
    void OnMouseDown()
    {

        if (controllerType.Equals("Play", StringComparison.InvariantCultureIgnoreCase)) {
            videoPlayer.Play();
        } else if (controllerType.Equals("Pause", StringComparison.InvariantCultureIgnoreCase)) {
            videoPlayer.Pause();
        } else if (controllerType.Equals("Stop", StringComparison.InvariantCultureIgnoreCase)) {
            videoPlayer.Stop();
            videoPlayer.transform.parent.gameObject.SetActive(false);
        } else {
            Debug.Log("Button clicked but no action performed - ControllerType not found.");
        }

    }

}
