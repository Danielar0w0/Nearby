using UnityEngine;

public class ScaleGestureHandler : MonoBehaviour
{

    float initialFingersDistance;
    Vector3 initialScale;

    // Update is called once per frame
    void Update()
    {

        GameObject selectedGameObject = SelectedModelData.getInstance().SelectedModel;

        int fingersOnScreen = 0;
        // If there are two touches on the device...
        foreach (Touch touch in Input.touches)
        {
            fingersOnScreen++;

            if (fingersOnScreen == 2)
            {
                //First set the initial distance between fingers so you can compare.
                if (touch.phase == TouchPhase.Began)
                {
                    initialFingersDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                    initialScale = selectedGameObject.transform.localScale;
                }
                else
                {
                    var currentFingersDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                    var scaleFactor = currentFingersDistance / initialFingersDistance;
                    selectedGameObject.transform.localScale = initialScale * scaleFactor;
                }
            }
        }
    }
}
