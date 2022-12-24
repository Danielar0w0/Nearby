using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{

    [SerializeField]
    private Canvas canvas;

    private GameObject modelSelectedPanel;

    private void Awake()
    {
        modelSelectedPanel = canvas.transform.Find("ModelSelectedPanel").gameObject;
    }

    public void showModelSelectedMsg()
    {

        showModelSelectedPanel();
        Invoke("hideModelSelectedPanel", 5000);
        
    }

    private void hideModelSelectedPanel()
    {
        modelSelectedPanel.SetActive(false);
    }

    private void showModelSelectedPanel()
    {
        modelSelectedPanel.SetActive(true);
    }

}
