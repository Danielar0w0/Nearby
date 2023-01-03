using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePrefabData
{

    public static InteractivePrefabData instance;

    public bool RotationEnabled { get; set; }

    private InteractivePrefabData() { }

    public static InteractivePrefabData getInstance()
    {
        if (instance == null)
            instance = new InteractivePrefabData();
        return instance;
    }

}
