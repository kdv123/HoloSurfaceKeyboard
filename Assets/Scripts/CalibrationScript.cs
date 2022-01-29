using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using MRTKExtensions.QRCodes;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class CalibrationScript : MonoBehaviour
{
    public GameObject calibrationPlaneL1;
    public GameObject calibrationPlaneL2;
    public GameObject calibrationPlaneM1;
    public GameObject calibrationPlaneM2;
    public GameObject calibrationPlaneR1;
    public GameObject calibrationPlaneR2;
    public GameObject calibrateButton;
    public GameObject calibrationPhase;
    public GameObject KeyBoardQR;
    public GameObject extraDebuggers;

    public qrRaiseLower qrrl;
    public sentenceScript ss;

    public float calibrationPlaneL1StartHeight;
    public float calibrationPlaneL2StartHeight;
    public float calibrationPlaneM1StartHeight;
    public float calibrationPlaneM2StartHeight;
    public float calibrationPlaneR1StartHeight;
    public float calibrationPlaneR2StartHeight;
    public float newHeight;

    public PressableButton pbcL1;
    public PressableButton pbcL2;
    public PressableButton pbcM1;
    public PressableButton pbcM2;
    public PressableButton pbcR1;
    public PressableButton pbcR2;

    public GameObject horizontalSwitch;
    public GameObject verticalSwitch;

    public TextMeshPro debugText;
    public TextMeshPro debugText2;

    private float zPos = 0.0f;

    public void Start()
    {
        zPos = calibrationPlaneL1.transform.localPosition.z;
    }

    public void Update()
    {
        IsTouchingHelper(pbcL1, calibrationPlaneL1);
        IsTouchingHelper(pbcL2, calibrationPlaneL2);
        IsTouchingHelper(pbcM1, calibrationPlaneM1);
        IsTouchingHelper(pbcM2, calibrationPlaneM2);
        IsTouchingHelper(pbcR1, calibrationPlaneR1);
        IsTouchingHelper(pbcR2, calibrationPlaneR2);


        debugText.text = "Plane left 1: " + calibrationPlaneL1.transform.localPosition.z.ToString("F4") + "\n" +
                         "Plane left 2: " + calibrationPlaneL2.transform.localPosition.z.ToString("F4") + "\n" +
                         "Plane middle 1: " + calibrationPlaneM1.transform.localPosition.z.ToString("F4") + "\n" +
                         "Plane middle 2: " + calibrationPlaneM2.transform.localPosition.z.ToString("F4") + "\n" +
                         "Plane right 1: " + calibrationPlaneR1.transform.localPosition.z.ToString("F4") + "\n" +
                         "Plane right 2: " + calibrationPlaneR2.transform.localPosition.z.ToString("F4") + "\n";

        debugText2.text = "QR Holder: " + qrrl.qrHolder.transform.localEulerAngles.y.ToString("F4") + "\n";

        if (calibrationPlaneL1.GetComponent<Renderer>().material.color == Color.yellow && calibrationPlaneM1.GetComponent<Renderer>().material.color == Color.yellow && calibrationPlaneR1.GetComponent<Renderer>().material.color == Color.yellow &&
            calibrationPlaneL2.GetComponent<Renderer>().material.color == Color.yellow && calibrationPlaneM2.GetComponent<Renderer>().material.color == Color.yellow && calibrationPlaneR2.GetComponent<Renderer>().material.color == Color.yellow)
            calibrateButton.SetActive(true);
    }

    private void IsTouchingHelper(PressableButton pb, GameObject go)
    {
        if (pb.IsTouching)
            go.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        else if(go.transform.localPosition.z == zPos)
            go.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        else
            go.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
    }

    public void Starter()
    {
        calibrationPlaneL1StartHeight = calibrationPlaneL1.transform.localPosition.z;
        calibrationPlaneL2StartHeight = calibrationPlaneL2.transform.localPosition.z;
        
        calibrationPlaneM1StartHeight = calibrationPlaneM1.transform.localPosition.z;
        calibrationPlaneM2StartHeight = calibrationPlaneM2.transform.localPosition.z;
        
        calibrationPlaneR1StartHeight = calibrationPlaneR1.transform.localPosition.z;
        calibrationPlaneR2StartHeight = calibrationPlaneR2.transform.localPosition.z;
    }

    public void Calibrate()
    {
        newHeight = ((calibrationPlaneL1.transform.localPosition.z - calibrationPlaneL1StartHeight) + 
                     (calibrationPlaneL2.transform.localPosition.z - calibrationPlaneL2StartHeight) +
                     (calibrationPlaneM1.transform.localPosition.z - calibrationPlaneM1StartHeight) +
                     (calibrationPlaneM2.transform.localPosition.z - calibrationPlaneM2StartHeight) +
                     (calibrationPlaneR1.transform.localPosition.z - calibrationPlaneR1StartHeight) +
                     (calibrationPlaneR2.transform.localPosition.z - calibrationPlaneR2StartHeight)) / 6.0f;

        // if (qrrl.qrHolder.transform.position.z + newHeight > 0)
        //     newHeight = newHeight;
        // else if (qrrl.qrHolder.transform.position.z + newHeight < 0)
        //     newHeight = newHeight * -1;

        // if (qrrl.qrHolder.transform.localEulerAngles.y == 0)
        //     newHeight = newHeight * -1;
        // else if (qrrl.qrHolder.transform.localEulerAngles.y == 90)
        //     newHeight = newHeight * -1;
        // else if (qrrl.qrHolder.transform.localEulerAngles.y == 180)
        //     newHeight = newHeight * -1;
        // else if (qrrl.qrHolder.transform.localEulerAngles.y == 270)
        //     newHeight = newHeight * -1;


        if (horizontalSwitch.activeSelf == true)
            newHeight = newHeight * -1;

        // if (verticalSwitch.activeSelf == true)
        //     newHeight = newHeight * -1;
        
        ss.calibrationWriteout();

        Debug.Log(newHeight);

        qrrl.CustomPosition(newHeight);
        calibrateButton.SetActive(false);
        calibrationPhase.SetActive(false);
        KeyBoardQR.SetActive(true);
        extraDebuggers.SetActive(true);

        // reset calibration plane positions
        
        float csPlaneL1PosX = calibrationPlaneL1.transform.position.x;
        float csPlaneL1PosY = calibrationPlaneL1.transform.position.y;
        calibrationPlaneL1.transform.position.Set(csPlaneL1PosX, csPlaneL1PosY, 0);
        
        float csPlaneL2PosX = calibrationPlaneL2.transform.position.x;
        float csPlaneL2PosY = calibrationPlaneL2.transform.position.y;
        calibrationPlaneL2.transform.position.Set(csPlaneL2PosX, csPlaneL2PosY, 0);
        
        float csPlaneM1PosX = calibrationPlaneM1.transform.position.x;
        float csPlaneM1PosY = calibrationPlaneM1.transform.position.y;
        calibrationPlaneM1.transform.position.Set(csPlaneM1PosX, csPlaneM1PosY, 0);
        
        float csPlaneM2PosX = calibrationPlaneM2.transform.position.x;
        float csPlaneM2PosY = calibrationPlaneM2.transform.position.y;
        calibrationPlaneM2.transform.position.Set(csPlaneM2PosX, csPlaneM2PosY, 0);
        
        float csPlaneR1PosX = calibrationPlaneR1.transform.position.x;
        float csPlaneR1PosY = calibrationPlaneR1.transform.position.y;
        calibrationPlaneR1.transform.position.Set(csPlaneR1PosX, csPlaneR1PosY, 0);
        
        float csPlaneR2PosX = calibrationPlaneR2.transform.position.x;
        float csPlaneR2PosY = calibrationPlaneR2.transform.position.y;
        calibrationPlaneR2.transform.position.Set(csPlaneR2PosX, csPlaneR2PosY, 0);
    }
}
