using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UINotifications : MonoBehaviour
{

    [SerializeField]
    private GameObject selectedModelPanel;

    [SerializeField]
    private GameObject videoFeedbackPanel;

    void OnEnable()
    {
        EventManager.OnModelSelectedEvent += ShowSelectedModelNotification;
        EventManager.OnPlayClickedEvent += ShowPlayVideoNotification;
        EventManager.OnPauseClickedEvent += ShowPauseVideoNotification;
        EventManager.OnSoundUpClickedEvent += IncreaseVideoSound;
        EventManager.OnSoundDownClickedEvent += DecreaseVideoSound;
        EventManager.OnSoundMuteClickedEvent += MuteVideoSound;
    }

    void OnDisable()
    {
        EventManager.OnModelSelectedEvent -= ShowSelectedModelNotification;
        EventManager.OnPlayClickedEvent -= ShowPlayVideoNotification;
        EventManager.OnPauseClickedEvent -= ShowPauseVideoNotification;
        EventManager.OnSoundUpClickedEvent -= IncreaseVideoSound;
        EventManager.OnSoundDownClickedEvent -= DecreaseVideoSound;
        EventManager.OnSoundMuteClickedEvent -= MuteVideoSound;
    }

    void ShowSelectedModelNotification(GameObject selectedModel)
    {
        
        if (selectedModelPanel == null) return;

        selectedModelPanel.SetActive(true);
        
        StartCoroutine(FadeUtils.FadeInObject(selectedModelPanel));
        StartCoroutine(HideNotification(selectedModelPanel, 2));

    }

    void ShowPlayVideoNotification()
    {

        if (videoFeedbackPanel == null) return;

        Text notificationText = videoFeedbackPanel.GetComponentInChildren<Text>();
        notificationText.text = "Playing Video";

        videoFeedbackPanel.SetActive(true);

        StartCoroutine(FadeUtils.FadeInObject(videoFeedbackPanel));
        StartCoroutine(HideNotification(videoFeedbackPanel, 2));

    }

    void ShowPauseVideoNotification()
    {

        if (videoFeedbackPanel == null) return;

        Text notificationText = videoFeedbackPanel.GetComponentInChildren<Text>();
        notificationText.text = "Paused Video";

        videoFeedbackPanel.SetActive(true);

        StartCoroutine(FadeUtils.FadeInObject(videoFeedbackPanel));
        StartCoroutine(HideNotification(videoFeedbackPanel, 2));

    }

    void IncreaseVideoSound()
    {

        if (videoFeedbackPanel == null) return;

        Text notificationText = videoFeedbackPanel.GetComponentInChildren<Text>();
        notificationText.text = "Volume Up";

        videoFeedbackPanel.SetActive(true);

        StartCoroutine(FadeUtils.FadeInObject(videoFeedbackPanel));
        StartCoroutine(HideNotification(videoFeedbackPanel, 1));

    }

    void DecreaseVideoSound()
    {
        if (videoFeedbackPanel == null) return;

        Text notificationText = videoFeedbackPanel.GetComponentInChildren<Text>();
        notificationText.text = "Volume Down";

        videoFeedbackPanel.SetActive(true);

        StartCoroutine(FadeUtils.FadeInObject(videoFeedbackPanel));
        StartCoroutine(HideNotification(videoFeedbackPanel, 1));
    }

    void MuteVideoSound()
    {
        if (videoFeedbackPanel == null) return;

        Text notificationText = videoFeedbackPanel.GetComponentInChildren<Text>();
        notificationText.text = "Muted";

        videoFeedbackPanel.SetActive(true);

        StartCoroutine(FadeUtils.FadeInObject(videoFeedbackPanel));
        StartCoroutine(HideNotification(videoFeedbackPanel, 1));
    }


    private IEnumerator HideNotification(GameObject notification, int timeInSeconds)
    {
        yield return new WaitForSeconds(timeInSeconds);
        StartCoroutine(FadeUtils.FadeOutObject(notification));
    }

}
