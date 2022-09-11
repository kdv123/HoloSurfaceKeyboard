using TMPro;
using UnityEngine;


/**
 * Author      : Joshua Reynolds
 * Email       : joshuare@mtu.edu
 * Description : This class houses the function for lifting and setting the keyboard on the wall
 */
public class qrRaiseLower : MonoBehaviour
{
    // just lifts and lowers the individual keyboard not the whole unit
    public GameObject qrHolder;
    public handTracker ht;
    public preSceneTimers pst;

    private Vector3 homePosition;
    public int globalCounter = 0;

    public TextMeshPro debuggerText;

    /**
     * Description : This method sets the debugging text to 0
     */
    public void Start()
    {
        debuggerText.text = 0f.ToString();
    }

    /**
     * Description : This method grabs the starting location of the keyboard and saves it value
     */
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

    /**
     * Description : This method raises the keyboard when the debugging button is pushed.
     */
    public void raiseQR()
    {
        if (ht.horizontalSwitch.activeSelf == true)
            qrHolder.transform.position = qrHolder.transform.position - (qrHolder.transform.forward * 0.005f);
        else if (ht.verticalSwitch.activeSelf == true)
            qrHolder.transform.position = qrHolder.transform.position - (qrHolder.transform.forward * 0.005f);
        
        debuggerText.text = qrHolder.transform.position.ToString("F4");
    }

    /**
     * Description : This method lowers the keyboard when the debugging button is pushed.
     */
    public void lowerQR()
    {
        if (ht.horizontalSwitch.activeSelf == true)
            qrHolder.transform.position = qrHolder.transform.position + (qrHolder.transform.forward * 0.005f);
        else if (ht.verticalSwitch.activeSelf == true)
            qrHolder.transform.position = qrHolder.transform.position + (qrHolder.transform.forward * 0.005f);
        
        debuggerText.text = qrHolder.transform.position.ToString("F4");
    }

    /**
     * Description : This method resets the keyboard height back to the original location.
     */
    public void resetQRPosition()
    {
        qrHolder.transform.localPosition = homePosition;
    }

    /**
     * Description : This method sets the custom height for the keyboard once its spawned in
     */
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
