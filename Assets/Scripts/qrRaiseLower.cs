using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class qrRaiseLower : MonoBehaviour
{
    // just lifts and lowers the individual keyboard not the whole unit
    public GameObject qrHolder;
    public handTracker ht;
    public preSceneTimers pst;

    private Vector3 homePosition;
    public int globalCounter = 0;

    public TextMeshPro debuggerText;

    public void Start()
    {
        debuggerText.text = 0f.ToString();
    }

    public void grabLocation()
    {
        // Vector3 cameraPosition = pst.ss.camera.transform.position;
        // Vector3 qrHolderLocationPosition = qrHolder.transform.position;
        //
        // if (ht.verticalSwitch.activeSelf == true)
        // {
        //     qrHolder.transform.position = new Vector3(qrHolderLocationPosition.x, cameraPosition.y, qrHolderLocationPosition.z);
        // }
        // else if (ht.horizontalSwitch.activeSelf == true)
        // {
        //     // do nothing yet... keep same position
        // }
        
        
        homePosition = qrHolder.transform.position;
    }

    public void raiseQR()
    {
        if (ht.horizontalSwitch.activeSelf == true)
            qrHolder.transform.position = qrHolder.transform.position - (qrHolder.transform.forward * 0.005f);
        else if (ht.verticalSwitch.activeSelf == true)
            qrHolder.transform.position = qrHolder.transform.position - (qrHolder.transform.forward * 0.005f);
        
        debuggerText.text = qrHolder.transform.position.ToString("F4");
    }

    public void lowerQR()
    {
        if (ht.horizontalSwitch.activeSelf == true)
            qrHolder.transform.position = qrHolder.transform.position + (qrHolder.transform.forward * 0.005f);
        else if (ht.verticalSwitch.activeSelf == true)
            qrHolder.transform.position = qrHolder.transform.position + (qrHolder.transform.forward * 0.005f);
        
        debuggerText.text = qrHolder.transform.position.ToString("F4");
    }

    public void resetQRPosition()
    {
        qrHolder.transform.localPosition = homePosition;
    }

    public void CustomPosition(object height)
    {
        Debug.Log(height.ToString());

        if (globalCounter == 0)
        {
            homePosition = qrHolder.transform.localPosition;
            globalCounter = 1;
        }

        if (ht.horizontalSwitch.activeSelf == true)
            qrHolder.transform.localPosition = homePosition - (qrHolder.transform.forward * float.Parse(height.ToString()));
        else if (ht.verticalSwitch.activeSelf == true)
            qrHolder.transform.localPosition = homePosition - (qrHolder.transform.forward * float.Parse(height.ToString()));
    }
}
