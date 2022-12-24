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

        // TODO: Handle gesture.

    }

}
