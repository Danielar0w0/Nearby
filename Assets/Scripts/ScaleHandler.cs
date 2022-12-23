using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Touch firstTouch = Input.GetTouch(0);
        Touch secondTouch = Input.GetTouch(1);

        // If any of the touches are cancelled or ended, do nothing
        if (firstTouch.phase == TouchPhase.Ended || firstTouch.phase == TouchPhase.Canceled ||
            secondTouch.phase == TouchPhase.Ended || secondTouch.phase == TouchPhase.Canceled)
        {
            return;
        }

        // Select placed object
        if (firstTouch.phase == TouchPhase.Began)
        {
            selectPlacedObject(firstTouch.position);
        }

        // Stop selecting placed object
        /*
        if(firstTouch.phase == TouchPhase.Ended)
        {
            lastSelectedObject.Selected = false;
        }
        */

        // Scale selected object
        if (arRaycastManager.Raycast(firstTouch.position, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            if (lastSelectedObject != null)
            {
                // Get the distance between the two touches
                float currentDistance = Vector2.Distance(firstTouch.position, secondTouch.position);

                // If this is the first frame of the pinch, store the distance
                if (initialDistance == 0)
                {
                    initialDistance = currentDistance;
                    initialScale = lastSelectedObject.transform.localScale;
                }
                else
                {
                    // Calculate the scale factor
                    float scaleFactor = currentDistance / initialDistance;

                    // Scale the object
                    lastSelectedObject.transform.localScale = initialScale * scaleFactor;
                }

            }
        }

    }

}
