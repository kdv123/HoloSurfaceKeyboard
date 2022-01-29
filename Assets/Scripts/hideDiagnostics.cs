using UnityEngine;

/**
 * Author : Joshua Reynolds
 * Description : Enables and disables diagnostics (the debugger window)
 */
public class hideDiagnostics : MonoBehaviour
{
    void Update()
    {
        Debug.developerConsoleVisible = false;
    }
}
