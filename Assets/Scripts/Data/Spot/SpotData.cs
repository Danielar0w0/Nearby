using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotData
{
    private static SpotData instance = null;

    public GameObject SpotInteractableModel { get; set; }

    public GameObject SpotTrackedObject { get; set; }

    public bool IsBeingDisplayed { get; set; }

    private SpotData() { }

    public static SpotData getInstance()
    {
        if (instance == null)
        {
            instance = new SpotData();
        }
        return instance;
    }

}
