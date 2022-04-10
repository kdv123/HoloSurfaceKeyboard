using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using MRTKExtensions.QRCodes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalibrationScriptWords : MonoBehaviour
{
    public TextMeshPro text;
    public TextMeshPro typedDisplayQ;
    public TextMeshPro typedDisplayF;
    
    public bool isCalibrating = false;
    
    public float lowestZHeight = int.MinValue;
    
    public GameObject calibrationMenuQ;
    public GameObject calibrateButtonQ;
    public GameObject calibrateButtonF;
    public GameObject calibrationPhaseQ;
    public GameObject calibrationPhaseF;
    public GameObject keyBoardQR;
    public GameObject keyBoardF;
    public GameObject extraDebuggersQ;
    public GameObject extraDebuggersF;

    public qrRaiseLower qrrl;
    public sentenceScript ss;
    public ButtonScript bsQ;
    public ButtonScript bsF;
    public handTracker ht;

    public void Start()
    {
        typedDisplayQ.text = "_";
        typedDisplayF.text = "_";
    }

    public void Awake()
    {
        if (ht.horizontalSwitch.activeSelf == true)
            ht.sbQH.Append(ss.Time() + ",Start Calibrating\n");
        
        if (ht.verticalSwitch.activeSelf == true)
            ht.sbQV.Append(ss.Time() + ",Start Calibrating\n");
        
        if (ht.freeSwitch.activeSelf == true)
            ht.sbF.Append(ss.Time() + ",Start Calibrating\n");
    }

    public void CButtonStart()
    {
        if (isCalibrating == false)
        {
            isCalibrating = true;
            lowestZHeight = int.MinValue;
        }
    }

    public void EButtonEnd()
    {
        if (ht.horizontalSwitch.activeSelf == true)
            ht.sbQH.Append(ss.Time() + ",End Calibrating\n");
        
        if (ht.verticalSwitch.activeSelf == true)
            ht.sbQV.Append(ss.Time() + ",End Calibrating\n");
        
        if (ht.freeSwitch.activeSelf == true)
            ht.sbF.Append(ss.Time() + ",End Calibrating\n");
        
        if (typedDisplayQ.text.Substring(0, typedDisplayQ.text.Length-1).Equals("calibrate"))
        {
            isCalibrating = false;
            Invoke("SpawnButton", 1f);
        }
        
        if (typedDisplayF.text.Substring(0, typedDisplayF.text.Length-1).Equals("calibrate"))
        {
            isCalibrating = false;
            Invoke("SpawnButton", 1f);
        }
    }

    public void SpawnButton()
    {
        if ((ht.verticalSwitch.activeSelf == true) || (ht.horizontalSwitch.activeSelf == true))
            calibrateButtonQ.SetActive(true);
        else if (ht.freeSwitch.activeSelf == true)
            calibrateButtonF.SetActive(true);
    }

    public void Calibrate()
    {
        if (ht.horizontalSwitch.activeSelf == true)
        {
            ht.sbQH.Append("Button Pushed: Calibrate\n\n");
            qrrl.CustomPosition((lowestZHeight / 2.66) * -1);
            
            calibrateButtonQ.SetActive(false);
            calibrationPhaseQ.SetActive(false);
            keyBoardQR.SetActive(true);
            extraDebuggersQ.SetActive(true);
            ss.textTypeQ.text = "_";
            bsQ.clear();
        }

        if (ht.verticalSwitch.activeSelf == true)
        {
            ht.sbQV.Append("Button Pushed: Calibrate\n\n");
            qrrl.CustomPosition((lowestZHeight / 2.66) * -1);
            
            calibrateButtonQ.SetActive(false);
            calibrationPhaseQ.SetActive(false);
            keyBoardQR.SetActive(true);
            extraDebuggersQ.SetActive(true);
            ss.textTypeQ.text = "_";
            bsQ.clear();
        }
        
        if (ht.freeSwitch.activeSelf == true)
        {
            ht.sbF.Append("Button Pushed: Calibrate\n\n");
            
            calibrateButtonF.SetActive(false);
            calibrationPhaseF.SetActive(false);
            keyBoardF.SetActive(true);
            extraDebuggersF.SetActive(true);
            ss.textTypeF.text = "_";
            bsF.clear();
        }
        
        text.text = "Lowest Height: ";
    }

    public void Update()
    {
        if (isCalibrating == true)
        {
            HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Both, out MixedRealityPose pose);
            
            Vector4 baseVec4F = new Vector4(pose.Position.x, pose.Position.y, pose.Position.z, 1);
            Vector4 modVec4F = calibrationMenuQ.transform.worldToLocalMatrix * baseVec4F;

            if (modVec4F.z > lowestZHeight)
            {
                lowestZHeight = modVec4F.z;
                text.text = "Lowest Height: " + lowestZHeight.ToString("F4");
            }
        }
    }
}
