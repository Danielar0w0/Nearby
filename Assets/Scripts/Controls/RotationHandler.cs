using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Touch touch;
        Quaternion rotationY;
        float rotateSpeedModifier = 0.1f;

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                rotationY = Quaternion.Euler(-touch.deltaPosition.y * rotateSpeedModifier, -touch.deltaPosition.x * rotateSpeedModifier, 0f);
                transform.rotation = rotationY * transform.rotation;
            }

        }

    }

}
