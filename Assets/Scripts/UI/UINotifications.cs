using UnityEngine;

public class UINotifications : MonoBehaviour
{

    [SerializeField]
    private GameObject selectedModelPanel;

    void OnEnable()
    {
        EventManager.OnModelSelectedEvent += ShowSelectedModelNotification;
    }

    void OnDisable()
    {
        EventManager.OnModelSelectedEvent -= ShowSelectedModelNotification;
    }

    void ShowSelectedModelNotification(GameObject selectedModel)
    {
        
        if (selectedModelPanel == null) return;

        selectedModelPanel.SetActive(true);
        
        StartCoroutine(FadeUtils.FadeInObject(selectedModelPanel));

        Invoke("HideSelectedModelNotification", 4);

    }

    private void HideSelectedModelNotification()
    {
        StartCoroutine(FadeUtils.FadeOutObject(selectedModelPanel));
    }

}
