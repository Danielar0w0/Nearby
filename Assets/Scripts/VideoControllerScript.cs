using System;
using UnityEngine;
using UnityEngine.Video;

public class VideoControllerScript : MonoBehaviour
{

    public string controllerType;
    public VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // When clicked
    void OnMouseDown()
    {

        if (controllerType.Equals("Play", StringComparison.InvariantCultureIgnoreCase)) {
            videoPlayer.Play();
        } else if (controllerType.Equals("Pause", StringComparison.InvariantCultureIgnoreCase)) {
            videoPlayer.Pause();
        } else if (controllerType.Equals("Stop", StringComparison.InvariantCultureIgnoreCase)) {
            videoPlayer.Stop();
        } else {
            Debug.Log("Button clicked but no action performed - ControllerType not found.");
        }

    }

}
