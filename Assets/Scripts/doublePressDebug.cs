using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class doublePressDebug : MonoBehaviour
{
    public GameObject realF;
    public GameObject fakeF;
    
    public GameObject realQ;
    public GameObject fakeQ;
    
    public void onPush()
    {
        if (realF.activeSelf == true)
        {
            realF.SetActive(false);
            fakeF.SetActive(true);
        }
        else if (fakeF.activeSelf == true)
        {
            fakeF.SetActive(false);
            realF.SetActive(true);
        }
        
        if (realQ.activeSelf == true)
        {
            realQ.SetActive(false);
            fakeQ.SetActive(true);
        }
        else if (fakeQ.activeSelf == true)
        {
            fakeQ.SetActive(false);
            realQ.SetActive(true);
        }
    }
}
