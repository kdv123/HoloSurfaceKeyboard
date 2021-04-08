using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using TMPro;
using UnityEngine;

public class EnableDisableKeyboard : MonoBehaviour
{
    public GameObject keyboard;
    public BoundsControl boundsControl;
    public GameObject plane;
    public Collider collider;
    
    public TextMeshPro text;
  
    public void onClick()
    {

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
