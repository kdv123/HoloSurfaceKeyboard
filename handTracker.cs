using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;

#if WINDOWS_UWP
    using Windows.Storage;
    using System.Threading.Tasks;
    using Windows.Data.Xml.Dom;
    using System;
#endif

/**
 * This can be changed to take coordinates of keys if the button script calls starter()... still have to log key tho
 */
public class handTracker : MonoBehaviour
{
    private string fileName = "xy_rftp_coordinates_Unity.txt";
    public GameObject GameManager;
    public String outWords = "Coordinates of the right pointer finger tip position: \n" +
                              "Where X position is left and right \n" +
                              "Where Y position is up and down \n" +
                              "Where Z position is forward and backward \n " +
                              "------------------------------------------------------- \n \n";

    public GameObject keyboard;
    
    public void starter()
    {
        
        #if WINDOWS_UWP
            create();
            InvokeRepeating("repeatH", 0, 1);
        #endif
        
        string filePathway = "Assets/xy_rftp_coordinates_Unity.txt";
        File.WriteAllText(filePathway, String.Empty);
        
        InvokeRepeating("repeat", 0, 1);
    }

    void repeat()
    {
        if (GameManager.activeSelf == true)
        {
            HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose);
            // Debug.Log(keyboard.transform.worldToLocalMatrix.GetColumn(3)); //position part of matrix
            // Vector4 vec4 = pose.Position; // vector 4 version of a vector 3 item
            // Debug.Log(vec4); // print it
            // Vector3 vec = keyboard.transform.localToWorldMatrix * pose.Position; // 
            // Debug.Log(vec);
            // Debug.Log(pose.Position);
            
            Debug.Log("X position: " + pose.Position.x.ToString("F"));
            Debug.Log("Y position: " + pose.Position.y.ToString("F"));

            write(pose);
        }
        else
        {
            CancelInvoke();
        }
    }

    void write(MixedRealityPose pose)
    {
        string filePathway = "Assets/xy_rftp_coordinates_Unity.txt";
        StreamWriter sw = new StreamWriter(filePathway, true);
        
        sw.WriteLine("X position: " + pose.Position.x.ToString("F"));
        sw.WriteLine("Y position: " + pose.Position.y.ToString("F"));
        sw.WriteLine();
        sw.Close();
    }
    
    #if WINDOWS_UWP
    
    public void repeatH()
    {
        if (GameManager.activeSelf == true)
        {
            HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose);
            strCat(pose);
        }
        else
        {
            CancelInvoke();
            writeOut();
        }
    }

    public async void create()
    {
        Windows.Storage.StorageFolder storageFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
        Windows.Storage.StorageFile sampleFile =
            await storageFolder.CreateFileAsync("xy_rftp_coordinates.txt",
                Windows.Storage.CreationCollisionOption.ReplaceExisting);
    }
    
    public async void strCat(MixedRealityPose pose)
    {
        outWords = outWords + ("X position: " + pose.Position.x.ToString("F") + "\n");
        outWords = outWords + ("Y position: " + pose.Position.y.ToString("F") + "\n");
        outWords = outWords + ("Z position: " + pose.Position.z.ToString("F") + "\n \n");
    }
    
    public async void writeOut()
    {
        Windows.Storage.StorageFolder storageFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
        Windows.Storage.StorageFile sampleFile =
            await storageFolder.GetFileAsync("xy_rftp_coordinates.txt");
        
        await Windows.Storage.FileIO.WriteTextAsync(sampleFile, outWords);
    }
    
    #endif
    
}
