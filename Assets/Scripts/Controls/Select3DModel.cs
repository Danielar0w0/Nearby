using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Select3DModel : MonoBehaviour
{

    [SerializeField]
    private GameObject selectedModelPanel;
    
    [SerializeField]
    private GameObject selectedModelRepresentation;

    private void OnMouseDown()
    {

        GameObject childObject = transform.GetChild(0).gameObject;

        Debug.Log("Selected Model With Box Click: " + childObject.name);

        showModelSelectedMsg();

        if (selectedModelRepresentation.transform == null)
            Debug.Log("Transform is Null");

        GameObject uiInstance = Instantiate(childObject, selectedModelRepresentation.transform);

        uiInstance.SetActive(true);

        uiInstance.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);

        Debug.Log("Selected Model With Box Click: " + selectedModelRepresentation.transform.childCount);

        DataStore.getInstance().CurrentModel = childObject;

    }

    public void showModelSelectedMsg()
    {
        
        selectedModelPanel.SetActive(true);

        StartCoroutine(FadeInObject(selectedModelPanel));
        Invoke("hideModelSelectedMsg", 4);

    }

    private void hideModelSelectedMsg()
    {
        StartCoroutine(FadeOutObject(selectedModelPanel));
    }

    IEnumerator FadeOutObject(GameObject obj)
    {
        CanvasGroup objectCanvasGroup = obj.GetComponent<CanvasGroup>();
        while (objectCanvasGroup.alpha > 0)
        {
            objectCanvasGroup.alpha = objectCanvasGroup.alpha - (1 * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator FadeInObject(GameObject obj)
    {
        CanvasGroup objectCanvasGroup = obj.GetComponent<CanvasGroup>();
        while (objectCanvasGroup.alpha < 1)
        {
            objectCanvasGroup.alpha = objectCanvasGroup.alpha + (1 * Time.deltaTime);
            yield return null;

        }
    }

}
