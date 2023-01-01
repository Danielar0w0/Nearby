using UnityEngine;

public class UIControls : MonoBehaviour
{

    public void onPlayClicked()
    {
        EventManager.current.OnPlayClicked();
    }

    public void onPauseClicked()
    {
        EventManager.current.OnPauseClicked();
    }

    public void onSoundUpClicked()
    {
        EventManager.current.OnSoundUpClicked();
    }

    public void onSoundDownClicked()
    {
        EventManager.current.OnSoundDownClicked();
    }

    public void onSoundMuteClicked()
    {
        EventManager.current.OnSoundMuteClicked();
    }

    public void onVideoForwardClicked()
    {
        EventManager.current.OnVideoForwardClicked();
    }

    public void onVideoBackwardClicked()
    {
        EventManager.current.OnVideoBackwardClicked();
    }

}
