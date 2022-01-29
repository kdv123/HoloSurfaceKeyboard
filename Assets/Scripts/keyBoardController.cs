using UnityEngine;

/**
 * Author : Joshua Reynolds
 * Adapted from : Joost van Schaik
  * https://localjoost.github.io/Positioning-QR-codes-in-space-with-HoloLens-2-building-a-'poor-man's-Vuforia'/
  * https://localjoost.github.io/Reading-QR-codes-with-an-MRTK2-Extension-Service/
 * Description : Spawns keyboard at qr location
 */
public class keyBoardController : MonoBehaviour
{
    [SerializeField]
    private QRTrackerController trackerController;

    private void Start()
    {
        trackerController.PositionSet += PoseFound;
    }

    private void PoseFound(object sender, Pose pose)
    {
        var childObj = transform.GetChild(0);
        childObj.SetPositionAndRotation(pose.position, pose.rotation);
        childObj.gameObject.SetActive(true);
    }
}