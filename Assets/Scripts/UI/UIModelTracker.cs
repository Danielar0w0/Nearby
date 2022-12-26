using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIModelTracker : MonoBehaviour
{

    [SerializeField]
    private Text modelSelectedTextUI;

    void OnEnable()
    {
        EventManager.OnModelSelectedEvent += DisplayModelSelected;
    }

    void OnDisable()
    {
        EventManager.OnModelSelectedEvent -= DisplayModelSelected;
    }

    void DisplayModelSelected(GameObject gameObject)
    {
        if (modelSelectedTextUI == null) return;
        modelSelectedTextUI.text = gameObject.name;
    }

}
