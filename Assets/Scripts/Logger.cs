using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Logger : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI logAreaText;

    [SerializeField]
    private int maxLines = 15;

    [SerializeField]
    private bool enableLog = false;

    void onEnable()
    {
        logAreaText.enabled = enableLog;
        enabled = enableLog;
    }
    
    private void ClearLines()
    {
        // Count number of log lines
        if (logAreaText.text.Split('\n').Length > maxLines)
        {
            logAreaText.text = "";
        }
    }

    public void LogInfo(string message)
    {
        ClearLines();
        logAreaText.text += $"{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")} <color=\"white\">{message}</color>\n";      
    }

    public void LogError(string message)
    {
        ClearLines();
        logAreaText.text += $"{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")} <color=\"red\">{message}</color>\n";
    }   
}
