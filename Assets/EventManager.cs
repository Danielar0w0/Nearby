using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public static EventManager current;

    public delegate void ModelSelected(GameObject selectedModel);
    public static event ModelSelected OnModelSelectedEvent;

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

}
