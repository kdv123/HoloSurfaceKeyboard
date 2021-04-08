using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using TMPro;
using UnityEngine;


public class EnableDisableTTP : MonoBehaviour
{
    
    public TapToPlace tapToPlaceO;

    public GameObject keyboard;
    public Collider collider;
    
    public TextMeshPro text;

    public void onClickHolder()
    {

        if (keyboard.gameObject.activeSelf == true)
        {

            if (tapToPlaceO.enabled == true)
            {
                    
                Debug.Log("O: setting false");
                tapToPlaceO.enabled = false;
                collider.enabled = false;
                text.color = Color.white;

            }
            else if (tapToPlaceO.enabled == false)
            {

                Debug.Log("O: setting true");
                tapToPlaceO.enabled = true;
                collider.enabled = true;
                text.color = Color.green;

            }

        }

    }

}
