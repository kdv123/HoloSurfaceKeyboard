using TMPro;
using UnityEngine;
using System;


/**
 * Author      : Joshua Reynolds
 * Email       : joshuare@mtu.edu
 * Description : This class houses the function for starting and ending the experiment of button based code - the handtrack start
 */

public class StartEndExperiment_Buttons : MonoBehaviour
{

    public GameObject GameManager;
    public handTrackerButtonQR HandTrackerButtonQR;
    public handTrackerButtonFREE HandTrackerButtonFREE;
    public TextMeshPro text;
    public TextMeshPro text2;
    
    private float timeStart;
    private float timeEnd;

    public float finalTime;


    public void onClickQ()
    {
        if (GameManager.activeSelf == true && HandTrackerButtonQR.isActiveAndEnabled == true)
        {
            GameManager.SetActive(false);
            HandTrackerButtonQR.enabled = false;
            text.color = Color.white;
            
            timeEnd = DateTime.Now.Millisecond;
            finalTime = timeEnd - timeStart;
            HandTrackerButtonQR.writeOutFile();
        }
        else if (GameManager.activeSelf == false && HandTrackerButtonQR.isActiveAndEnabled == false)
        {
            GameManager.SetActive(true);
            HandTrackerButtonQR.enabled = true;
            text.color = Color.green;
            
            timeStart = DateTime.Now.Second;
        }
    }

    public void onClickF()
    {
        if (GameManager.activeSelf == true && HandTrackerButtonFREE.isActiveAndEnabled == true)
        {
            GameManager.SetActive(false);
            HandTrackerButtonFREE.enabled = false;
            text2.color = Color.white;
            
            timeEnd = DateTime.Now.Millisecond;
            finalTime = timeEnd - timeStart;
            HandTrackerButtonFREE.writeOutFile();
        }
        else if (GameManager.activeSelf == false && HandTrackerButtonFREE.isActiveAndEnabled == false)
        {
            GameManager.SetActive(true);
            HandTrackerButtonFREE.enabled = true;
            text2.color = Color.green;
            
            timeStart = DateTime.Now.Second;
        }
    }
}