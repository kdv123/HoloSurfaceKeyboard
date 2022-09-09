using Microsoft.MixedReality.Toolkit.Input;
using TMPro;
using UnityEngine;


/**
 * Author      : Joshua Reynolds
 * Email       : joshuare@mtu.edu
 * Description : This class houses the function calls for the gesture feature in the debug menu.
 *             : Note - this class is not in use
 */
public class GestureHandler : MonoBehaviour, IMixedRealityGestureHandler
{
    // Initialize variables
    public GameObject keyboard;
    public GameObject plane;
    public GameObject camera;
    
    public TextMeshPro text;
    
    public void OnGestureStarted(InputEventData eventData)
    {
        Debug.Log("Gesture Started");
    }

    public void OnGestureUpdated(InputEventData eventData)
    {
        Debug.Log("Gesture Updated");
    }

    /**
     * Description : When the airtap gesture completes select the text on the keyboard
     */
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
