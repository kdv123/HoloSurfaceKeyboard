using UnityEngine;

/**
 * Author : Joshua Reynolds
 * Description : Logs whether keyboard is moving and turns off and on the reactable buttons || currently not implemented
 */
public class update : MonoBehaviour
{
    // Initialize variables
    private Vector3 curPos;
    private Vector3 lastPos;
    
    public GameObject keyboard;
    public GameObject buttonCollectionReal;
    public GameObject buttonCollectionFake;
    
    public Collider collider;
    
    /**
     * Description : This method is updated every frame and makes sure the correct set of buttons is active
     */
    void Update()
    {
        curPos = keyboard.gameObject.transform.position;
        
        if(curPos == lastPos)
        {
            //Debug.Log("Not moving");
            buttonCollectionFake.SetActive(false);
            buttonCollectionReal.SetActive(true);
            collider.enabled = false;
        }
        else
        {
            //Debug.Log("moving");
            buttonCollectionFake.SetActive(true);
            buttonCollectionReal.SetActive(false);
            collider.enabled = true;
        }
        
        lastPos = curPos;
    }
}
