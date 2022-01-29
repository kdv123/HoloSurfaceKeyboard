using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class freeKeyboardDebugger : MonoBehaviour
{
    public GameObject freeHolder;
    
    public TextMeshPro debuggerText;
    
    public void RotateForward()
    {
        freeHolder.transform.eulerAngles = new Vector3(freeHolder.transform.eulerAngles.x + 5f, 0, 0);
        
        debuggerText.text = freeHolder.transform.eulerAngles.ToString("F4");
    }

    public void RotateBack()
    {
        freeHolder.transform.eulerAngles = new Vector3(freeHolder.transform.eulerAngles.x - 5f, 0, 0);
        
        debuggerText.text = freeHolder.transform.eulerAngles.ToString("F4");
    }
}
