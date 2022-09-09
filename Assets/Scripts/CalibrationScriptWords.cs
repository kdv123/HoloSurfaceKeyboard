using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using TMPro;
using UnityEngine;


/**
 * Author      : Joshua Reynolds
 * Email       : joshuare@mtu.edu
 * Description : This class houses the function calls for properly calibrating the height of the keyboard.
 */
public class CalibrationScriptWords : MonoBehaviour
{
    // Initialize starting variables
    public TextMeshPro text;
    public TextMeshPro typedDisplayQ;
    public TextMeshPro typedDisplayF;
    
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
    
    public bool isCalibrating = false;
    
    public float lowestZHeight = int.MinValue;

    /**
     * Description : This method is called at the start of the app.
     */
    public void Start()
    {
        // Start the displayed text with the cursor
        typedDisplayQ.text = "_";
        typedDisplayF.text = "_";
    }

    /**
     * Description : This method is called when the script wakes up.
     */
    public void Awake()
    {
        // Start calibration process for the horizontal keyboard
        if (ht.horizontalSwitch.activeSelf == true)
            ht.sbQH.Append(ss.Time() + ",Start Calibrating\n");
        
        // Start calibration process for the vertical keyboard
        if (ht.verticalSwitch.activeSelf == true)
            ht.sbQV.Append(ss.Time() + ",Start Calibrating\n");
        
        // Start calibration process for the midair keyboard
        if (ht.freeSwitch.activeSelf == true)
            ht.sbF.Append(ss.Time() + ",Start Calibrating\n");
    }

    /**
     * Description : This method starts the calibration process
     */
    public void CButtonStart()
    {
        if (isCalibrating == false)
        {
            isCalibrating = true;
            lowestZHeight = int.MinValue;
        }
    }

    /**
     * Description : This method ends the calibration process
     */
    public void EButtonEnd()
    {
        // End calibration process for the horizontal keyboard
        if (ht.horizontalSwitch.activeSelf == true)
            ht.sbQH.Append(ss.Time() + ",End Calibrating\n");
        
        // End calibration process for the vertical keyboard
        if (ht.verticalSwitch.activeSelf == true)
            ht.sbQV.Append(ss.Time() + ",End Calibrating\n");
        
        // End calibration process for the midair keyboard
        if (ht.freeSwitch.activeSelf == true)
            ht.sbF.Append(ss.Time() + ",End Calibrating\n");
        
        
        // End calibration process if the word typed says calibrate
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

    /**
     * Description : This method spawns the calibrate progression button
     */
    public void SpawnButton()
    {
        // Spawn in the button for the correct condition
        if ((ht.verticalSwitch.activeSelf == true) || (ht.horizontalSwitch.activeSelf == true))
            calibrateButtonQ.SetActive(true);
        else if (ht.freeSwitch.activeSelf == true)
            calibrateButtonF.SetActive(true);
    }

    /**
     * Description : This method does the actual calibration
     */
    public void Calibrate()
    {
        // Depending on the condition disable and enable certain features
        if (ht.horizontalSwitch.activeSelf == true)
        {
            ht.sbQH.Append("Button Pushed: Calibrate\n\n");
            qrrl.CustomPosition((lowestZHeight / 2.66) * -1);
            
            calibrateButtonQ.SetActive(false);
            calibrationPhaseQ.SetActive(false);
            keyBoardQR.SetActive(true);
            extraDebuggersQ.SetActive(true);
            ss.textTypeQ.text = "_";
            bsQ.Clear();
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
            bsQ.Clear();
        }
        
        if (ht.freeSwitch.activeSelf == true)
        {
            ht.sbF.Append("Button Pushed: Calibrate\n\n");
            
            calibrateButtonF.SetActive(false);
            calibrationPhaseF.SetActive(false);
            keyBoardF.SetActive(true);
            extraDebuggersF.SetActive(true);
            ss.textTypeF.text = "_";
            bsF.Clear();
        }
        
        text.text = "Lowest Height: ";
    }

    /**
     * Description : This method is called every frame. 
     */
    public void Update()
    {
        // If calibrating, record the deepest push and mark it
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
