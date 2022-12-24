using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotData
{

    private static SpotData instance;

    public GameObject SpotInteractableModel { get; set; }
    public bool IsBeingDisplayed { get; set; }

    private SpotData() { }

    public static SpotData getInstance()
    {
        if (instance == null)
            instance = new SpotData();
        return instance;
    }

}
