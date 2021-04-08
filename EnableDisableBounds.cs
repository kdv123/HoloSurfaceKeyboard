using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using UnityEngine;

public class EnableDisableBounds : MonoBehaviour
{
    public GameObject keyboard;

    public BoundsControl boundsControl;
    
    public ObjectManipulator objectManipulator;
    public ObjectManipulator keyBoardObjectManip;

    public void Start()
    {
        
        boundsControl.Active = false;

    }

    public void onClick()
    {
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
