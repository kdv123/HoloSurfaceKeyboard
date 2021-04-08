using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using TMPro;
using UnityEngine;

public class GestureHandler : MonoBehaviour, IMixedRealityGestureHandler
{

    public GameObject keyboard;
    public GameObject plane;
    
    public TextMeshPro text;
    

    public void OnGestureStarted(InputEventData eventData)
    {
        Debug.Log("Gesture Started");
    }

    public void OnGestureUpdated(InputEventData eventData)
    {
        Debug.Log("Gesture Updated");
    }

    public void OnGestureCompleted(InputEventData eventData)
    {
        
        Debug.Log("Gesture Completed");
        
        var action = eventData.MixedRealityInputAction.Description;

        if (action == "Select")
        {
            
            keyboard.gameObject.SetActive(true);
            plane.gameObject.SetActive(false);
            text.color = Color.green;

        }

    }

    public void OnGestureCanceled(InputEventData eventData)
    {
        Debug.Log("Gesture Cancelled");
    }
}
