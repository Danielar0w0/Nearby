using System.Collections;
using UnityEngine;

public class FadeUtils : MonoBehaviour
{
   
    // Requires a Game Object with a Canvas Group
    public static IEnumerator FadeOutObject(GameObject obj)
    {
        CanvasGroup objectCanvasGroup;

        if (obj.GetComponent<CanvasGroup>() != null)
            objectCanvasGroup = obj.GetComponent<CanvasGroup>();
        else
            objectCanvasGroup = obj.GetComponentInChildren<CanvasGroup>();

        while (objectCanvasGroup.alpha > 0)
        {
            objectCanvasGroup.alpha = objectCanvasGroup.alpha - (1 * Time.deltaTime);
            yield return null;
        }
    }

    // Requires a Game Object with a Canvas Group
    public static IEnumerator FadeInObject(GameObject obj)
    {
        CanvasGroup objectCanvasGroup;

        if (obj.GetComponent<CanvasGroup>() != null)
            objectCanvasGroup = obj.GetComponent<CanvasGroup>();
        else
            objectCanvasGroup = obj.GetComponentInChildren<CanvasGroup>();

        while (objectCanvasGroup.alpha < 1)
        {
            objectCanvasGroup.alpha = objectCanvasGroup.alpha + (1 * Time.deltaTime);
            yield return null;

        }
    }

    // Requires a Game Object with a Canvas Group
    public static IEnumerator FadeOutObject(GameObject obj, int speed)
    {
        CanvasGroup objectCanvasGroup;

        if (obj.GetComponent<CanvasGroup>() != null)
            objectCanvasGroup = obj.GetComponent<CanvasGroup>();
        else
            objectCanvasGroup = obj.GetComponentInChildren<CanvasGroup>();

        while (objectCanvasGroup.alpha > 0)
        {
            objectCanvasGroup.alpha = objectCanvasGroup.alpha - (speed * Time.deltaTime);
            yield return null;
        }
    }

    // Requires a Game Object with a Canvas Group
    public static IEnumerator FadeInObject(GameObject obj, int speed)
    {
        CanvasGroup objectCanvasGroup;

        if (obj.GetComponent<CanvasGroup>() != null)
            objectCanvasGroup = obj.GetComponent<CanvasGroup>();
        else
            objectCanvasGroup = obj.GetComponentInChildren<CanvasGroup>();

        while (objectCanvasGroup.alpha < 1)
        {
            objectCanvasGroup.alpha = objectCanvasGroup.alpha + (speed * Time.deltaTime);
            yield return null;

        }
    }

}
