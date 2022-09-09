using UnityEngine;


/**
 * Author      : Joshua Reynolds
 * Email       : joshuare@mtu.edu
 * Description : This class houses the function calls for the debugging feature which allows a double press to be active.
 *             : Note - This class isn't currently being used.
 */
public class doublePressDebug : MonoBehaviour
{
    // Initialize variables
    public GameObject realF;
    public GameObject fakeF;
    public GameObject realQ;
    public GameObject fakeQ;
    
    /**
     * Description : This method is called when the double press button on the debugging menu is pushed.
     *             : It turns the double press on and off. 
     */
    public void onPush()
    {
        // If midair condition, enable/disable the double press
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
        
        // If QR condition, enable/disable the double press
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
