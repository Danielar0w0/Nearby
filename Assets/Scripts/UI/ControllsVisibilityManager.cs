using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllsVisibilityManager : MonoBehaviour
{

    [SerializeField]
    private GameObject hideableControls;

    void OnEnable()
    {
        EventManager.OnMenuItemClickedEvent += ToogleUIControllsVisibility;
    }

    void OnDisable()
    {
        EventManager.OnMenuItemClickedEvent -= ToogleUIControllsVisibility;
    }

    void ToogleUIControllsVisibility()
    {

        CanvasGroup controlsCanvasGroup = hideableControls.GetComponentInChildren<CanvasGroup>();

        if (controlsCanvasGroup == null) {
            Debug.LogWarning("Unable to find CanvasGroup in Controls object. This will most likely break the controls!!!");
            return;
        }

        bool areControlsVisible = controlsCanvasGroup.alpha == 1f;

        hideableControls.SetActive(true);

        if (!areControlsVisible)
        {
            StartCoroutine(FadeUtils.FadeInObject(hideableControls, 1));
        } else
        {
            StartCoroutine(FadeUtils.FadeOutObject(hideableControls, 2));
        }

    }

}
