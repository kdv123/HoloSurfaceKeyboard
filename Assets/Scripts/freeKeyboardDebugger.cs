using TMPro;
using UnityEngine;


/**
 * Author      : Joshua Reynolds
 * Email       : joshuare@mtu.edu
 * Description : This class houses the function calls for the rotation feature in the debug menu.
 *             : Note - this class is not in use
 */
public class freeKeyboardDebugger : MonoBehaviour
{
    // Initialize variables
    public GameObject freeHolder;
    
    public TextMeshPro debuggerText;
    
    /**
     * Description : This method rotates the keyboard feature forward 5 degrees
     */
    public void RotateForward()
    {
        freeHolder.transform.eulerAngles = new Vector3(freeHolder.transform.eulerAngles.x + 5f, 0, 0);
        debuggerText.text = freeHolder.transform.eulerAngles.ToString("F4");
    }

    /**
     * Description : This method rotates the keyboard feature backward 5 degrees
     */
    public void RotateBack()
    {
        freeHolder.transform.eulerAngles = new Vector3(freeHolder.transform.eulerAngles.x - 5f, 0, 0);
        debuggerText.text = freeHolder.transform.eulerAngles.ToString("F4");
    }
}
