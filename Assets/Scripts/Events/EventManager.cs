using UnityEngine;

public class EventManager : MonoBehaviour
{

    public static EventManager current;

    public delegate void ModelSelected(GameObject selectedModel);
    public static event ModelSelected OnModelSelectedEvent;

    public delegate void PlayClicked();
    public static event PlayClicked OnPlayClickedEvent;

    public delegate void PauseClicked();
    public static event PauseClicked OnPauseClickedEvent;

    public delegate void SoundUpClicked();
    public static event SoundUpClicked OnSoundUpClickedEvent;

    public delegate void SoundDownClicked();
    public static event SoundDownClicked OnSoundDownClickedEvent;

    public delegate void SoundMuteClicked();
    public static event SoundMuteClicked OnSoundMuteClickedEvent;

    public delegate void VideoForwardClicked();
    public static event VideoForwardClicked OnVideoForwardClickedEvent;

    public delegate void VideoBackwardClicked();
    public static event VideoBackwardClicked OnVideoBackwardClickedEvent;

    public delegate void MenuItemClicked();
    public static event MenuItemClicked OnMenuItemClickedEvent;

    private void Awake()
    {
        current = this;
    }

    public void OnModelSelected(GameObject selectedModel)
    {
        if (OnModelSelectedEvent != null)
            OnModelSelectedEvent(selectedModel);

        Debug.Log("Model Selected Event - Producer.");

    }

    public void OnPlayClicked()
    {
        if (OnPlayClickedEvent != null)
            OnPlayClickedEvent();
    }

    public void OnPauseClicked()
    {
        if (OnPauseClickedEvent != null)
            OnPauseClickedEvent();
    }

    public void OnSoundUpClicked()
    {
        if (OnSoundUpClickedEvent != null)
            OnSoundUpClickedEvent();
    }

    public void OnSoundDownClicked()
    {
        if (OnSoundDownClickedEvent != null)
            OnSoundDownClickedEvent();
    }

    public void OnSoundMuteClicked()
    {
        if (OnSoundMuteClickedEvent != null)
            OnSoundMuteClickedEvent();
    }

    public void OnVideoForwardClicked()
    {
        if (OnVideoForwardClickedEvent != null)
            OnVideoForwardClickedEvent();
    }

    public void OnVideoBackwardClicked()
    {
        if (OnVideoBackwardClickedEvent != null)
            OnVideoBackwardClickedEvent();
    }

    public void OnMenuItemClicked()
    {
        if (OnMenuItemClickedEvent != null)
            OnMenuItemClickedEvent();
    }

}
