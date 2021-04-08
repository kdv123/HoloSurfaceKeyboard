using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartEndExperiment : MonoBehaviour
{

    public GameObject GameManager;
    public handTracker HandTrackerScript;
    public TextMeshPro text;


    public void onClick()
    {

        if (GameManager.activeSelf == true && HandTrackerScript.isActiveAndEnabled == true)
        {
            GameManager.SetActive(false);
            HandTrackerScript.enabled = false;
            text.color = Color.white;

        }
        else if (GameManager.activeSelf == false && HandTrackerScript.isActiveAndEnabled == false)
        {
            GameManager.SetActive(true);
            HandTrackerScript.enabled = true;
            text.color = Color.green;
            HandTrackerScript.starter();
        }
        
    }

}
