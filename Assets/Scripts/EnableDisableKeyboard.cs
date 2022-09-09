using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using TMPro;
using UnityEngine;


/**
 * Author      : Joshua Reynolds
 * Email       : joshuare@mtu.edu
 * Description : This class houses the function calls for the debugging feature which allows the keyboard to be active.
 *             : Note - This class isn't currently being used.
 */
public class EnableDisableKeyboard : MonoBehaviour
{
    // Initialize variables
    public GameObject keyboard;
    public GameObject plane;
    public BoundsControl boundsControl;
    public Collider collider;
    public TextMeshPro text;
  
    /**
     * Description : This method triggers when the debugging button is pushed.
     *             : This method enables and disables the keyboard
     */
    public void onClick()
    {
        // Enable/Disable the keyboard
        if (keyboard.gameObject.activeSelf == true)
        {
            keyboard.gameObject.SetActive(false);
            boundsControl.Active = false;
            plane.gameObject.SetActive(true);
            text.color = Color.white;
        }
        else if (keyboard.gameObject.activeSelf == false)
        {
            keyboard.gameObject.SetActive(true);
            plane.gameObject.SetActive(false);
            collider.enabled = false;
            text.color = Color.green;
        }
    }
}
