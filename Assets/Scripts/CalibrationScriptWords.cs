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
    public TextMeshPro typedDisplay;
    
    public bool isCalibrating = false;
    
    public float lowestZHeight = int.MinValue;
    
    public GameObject calibrationMenu;
    public GameObject calibrateButton;
    public GameObject calibrationPhase;
    public GameObject keyBoardQR;
    public GameObject extraDebuggers;

    public qrRaiseLower qrrl;
    public sentenceScript ss;
    public ButtonScript bs;
    public handTracker ht;

    public void Start()
    {
        typedDisplay.text = "_";
    }

    public void Awake()
    {
        if (ht.horizontalSwitch.activeSelf == true)
            ht.outWordsQH = ht.outWordsQH + (TimeSpan.FromMilliseconds(DateTimeOffset.Now.ToUnixTimeMilliseconds()).TotalSeconds 
                                             + ",Start Calibrating\n");
        
        if (ht.verticalSwitch.activeSelf == true)
            ht.outWordsQV = ht.outWordsQV + (TimeSpan.FromMilliseconds(DateTimeOffset.Now.ToUnixTimeMilliseconds()).TotalSeconds 
                                             + ",Start Calibrating\n");
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
            ht.outWordsQH = ht.outWordsQH + (TimeSpan.FromMilliseconds(DateTimeOffset.Now.ToUnixTimeMilliseconds()).TotalSeconds 
                                             + ",End Calibrating\n");
        
        if (ht.verticalSwitch.activeSelf == true)
            ht.outWordsQV = ht.outWordsQV + (TimeSpan.FromMilliseconds(DateTimeOffset.Now.ToUnixTimeMilliseconds()).TotalSeconds 
                                             + ",End Calibrating\n");
        
        if (typedDisplay.text.Substring(0, typedDisplay.text.Length-1).Equals("calibrate"))
        {
            isCalibrating = false;
            Invoke("SpawnButton", 1f);
        }
    }

    public void SpawnButton()
    {
        calibrateButton.SetActive(true);
    }

    public void Calibrate()
    {
        if (ht.horizontalSwitch.activeSelf == true)
        {
            ht.outWordsQH = ht.outWordsQH + "Button Pushed: Calibrate\n\n";
            qrrl.CustomPosition((lowestZHeight / 2.63) * -1);
        }

        if (ht.verticalSwitch.activeSelf == true)
        {
            ht.outWordsQV = ht.outWordsQV + "Button Pushed: Calibrate\n\n";
            qrrl.CustomPosition((lowestZHeight / 2.66) * -1);
        }

        calibrateButton.SetActive(false);
        calibrationPhase.SetActive(false);
        keyBoardQR.SetActive(true);
        extraDebuggers.SetActive(true);

        ss.textTypeQ.text = "_";
        text.text = "Lowest Height: ";
        bs.clear();
    }

    public void Update()
    {
        if (isCalibrating == true)
        {
            HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Both, out MixedRealityPose pose);
            
            Vector4 baseVec4F = new Vector4(pose.Position.x, pose.Position.y, pose.Position.z, 1);
            Vector4 modVec4F = calibrationMenu.transform.worldToLocalMatrix * baseVec4F;

            if (modVec4F.z > lowestZHeight)
            {
                lowestZHeight = modVec4F.z;
                text.text = "Lowest Height: " + lowestZHeight.ToString("F4");
            }
        }
    }
}
