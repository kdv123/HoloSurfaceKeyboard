using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Diagnostics;
using UnityEngine;

public class FPSTracker : MonoBehaviour
{
    [SerializeField] private int avgFrameRate;
    [SerializeField] private String fpsText;
 
    public String FPS_Text()
    {
        float current = 0;
        current = (int) (1f / Time.unscaledDeltaTime);
        
        avgFrameRate = (int) current; 
        fpsText = avgFrameRate.ToString() + " FPS";
        
        return fpsText;
    }
}