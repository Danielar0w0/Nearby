using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectButton : MonoBehaviour
{

    [SerializeField]
    private UnityEvent OnClick = new UnityEvent();

    void OnMouseDown()
    {
        OnClick.Invoke();   
    }

}
