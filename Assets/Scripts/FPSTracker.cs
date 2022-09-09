using System;
using UnityEngine;


/**
 * Author      : Joshua Reynolds
 * Email       : joshuare@mtu.edu
 * Description : This class houses the function calls for the FPS tracking functionality.
 *             : Note - this class is not in use
 */
public class FPSTracker : MonoBehaviour
{
    // Initialize variables
    [SerializeField] private int avgFrameRate;
    [SerializeField] private String fpsText;
 
    /**
     * Description : This method is for tracking the fps and displaying it.
     */
    public String FPS_Text()
    {
        float current = 0;
        current = (int) (1f / Time.unscaledDeltaTime);
        
        avgFrameRate = (int) current; 
        fpsText = avgFrameRate.ToString() + " FPS";
        
        return fpsText;
    }
}