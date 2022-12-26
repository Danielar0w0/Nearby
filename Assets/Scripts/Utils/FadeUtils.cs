using System.Collections;
using UnityEngine;

public class FadeUtils : MonoBehaviour
{
   
    // Requires a Game Object with a Canvas Group
    public static IEnumerator FadeOutObject(GameObject obj)
    {
        CanvasGroup objectCanvasGroup = obj.GetComponent<CanvasGroup>();
        while (objectCanvasGroup.alpha > 0)
        {
            objectCanvasGroup.alpha = objectCanvasGroup.alpha - (1 * Time.deltaTime);
            yield return null;
        }
    }

    // Requires a Game Object with a Canvas Group
    public static IEnumerator FadeInObject(GameObject obj)
    {
        CanvasGroup objectCanvasGroup = obj.GetComponent<CanvasGroup>();
        while (objectCanvasGroup.alpha < 1)
        {
            objectCanvasGroup.alpha = objectCanvasGroup.alpha + (1 * Time.deltaTime);
            yield return null;

        }
    }

}
