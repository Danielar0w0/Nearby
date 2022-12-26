using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedModelData
{

    private static SelectedModelData instance;

    public GameObject SelectedModel { get; set; }

    private SelectedModelData() { }

    public static SelectedModelData getInstance()
    {
        if (instance == null)
            instance = new SelectedModelData();
        return instance;
    }

}
