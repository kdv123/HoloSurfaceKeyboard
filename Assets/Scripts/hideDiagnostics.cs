using UnityEngine;


/**
 * Author      : Joshua Reynolds
 * Email       : joshuare@mtu.edu
 * Description : This class houses the function for hiding the diagnostic menu
 */
public class hideDiagnostics : MonoBehaviour
{
    /**
     * Description : Continual hide the menu
     */
    void Update()
    {
        Debug.developerConsoleVisible = false;
    }
}
