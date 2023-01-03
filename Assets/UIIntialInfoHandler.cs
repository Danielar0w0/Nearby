using UnityEngine;

public class UIIntialInfoHandler : MonoBehaviour
{

    [SerializeField]
    private GameObject initialInfoObject;

    [SerializeField]
    private GameObject currentModelPanel;

    void OnEnable()
    {
        EventManager.OnTrackedImageInitiatedEvent += RemoveInitialInfoFromCanvas;    
    }

    void OnDisable()
    {
        EventManager.OnTrackedImageInitiatedEvent -= RemoveInitialInfoFromCanvas;
    }

    void RemoveInitialInfoFromCanvas()
    {
        initialInfoObject.SetActive(false);
        currentModelPanel.SetActive(true);
    }

}
