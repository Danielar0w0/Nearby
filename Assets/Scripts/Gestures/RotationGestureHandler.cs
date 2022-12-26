using UnityEngine;

public class RotationGestureHandler : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        GameObject selectedGameObject = SelectedModelData.getInstance().SelectedModel;

        Touch touch;
        Quaternion rotationY;
        float rotateSpeedModifier = 0.1f;

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                rotationY = Quaternion.Euler(-touch.deltaPosition.y * rotateSpeedModifier, -touch.deltaPosition.x * rotateSpeedModifier, 0f);
                selectedGameObject.transform.rotation = rotationY * selectedGameObject.transform.rotation;
            }

        }

    }

}
