using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using UnityEngine;


/**
 * Author      : Joshua Reynolds
 * Email       : joshuare@mtu.edu
 * Description : This class houses the function calls for the debugging feature which allows the bounding box to be active.
 *             : Note - This class isn't currently being used.
 */
public class EnableDisableBounds : MonoBehaviour
{
    // Initialize variables
    public GameObject keyboard;

    public BoundsControl boundsControl;
    
    public ObjectManipulator objectManipulator;
    public ObjectManipulator keyBoardObjectManip;

    /**
     * Description : This method is called at the start of the app.
     */
    public void Start()
    {
        boundsControl.Active = false;
    }

    /**
     * Description : This method runs on click when the debugging button is pushed.
     *             : This turns the bounds on and off.
     */
    public void onClick()
    {
        // Enable/Disable bounds when the keyboard is active
        if (keyboard.gameObject.activeSelf == true)
        {
            if (boundsControl.Active == true)
            {
                boundsControl.Active = false;
                boundsControl.enabled = false;
                objectManipulator.enabled = false;
                keyBoardObjectManip.enabled = true;
            }
            else if (boundsControl.Active == false)
            {
                boundsControl.Active = true;
                boundsControl.enabled = true;
                objectManipulator.enabled = true;
                keyBoardObjectManip.enabled = false;
            }
        }
    }
}
