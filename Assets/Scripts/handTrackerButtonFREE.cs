using System;
using System.IO;
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
 * Author : Joshua Reynolds
 * Description : Enables and disables handtracking for the free movement keyboard (via button) of the keyboards keys
 */
public class handTrackerButtonFREE : MonoBehaviour
{
    private string fileName = "FREE_xy_pftp_coordinates_Unity.txt";
    public GameObject GameManager;
    public String outWords = "Coordinates of the key push via a pointer finger tip position (FREE tests): \n" +
                             "Where X position is left and right \n" +
                             "Where Y position is up and down \n" +
                             "------------------------------------------------------- \n \n";

    public GameObject keyboard; 
    public int globalcounter = 0;
    
    public handTrackerButtonQR HandTrackerButtonQR;

    public sentenceScript SentenceScript;
    
    public void Start()
    {
        //do nothing
    }
    
    public void Awake()
    {
        if (HandTrackerButtonQR.isActiveAndEnabled == false)
        {
            #if WINDOWS_UWP
                createH();
            #endif
        }
    }

    public void starter(string key)
    {
        if (HandTrackerButtonQR.isActiveAndEnabled == false)
        {
            HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose);

            Vector4 baseVec4 = new Vector4(pose.Position.x, pose.Position.y, pose.Position.z, 1);
            Vector4 modVec4 = keyboard.transform.worldToLocalMatrix * baseVec4;

            #if WINDOWS_UWP
                repeatH(key, modVec4);
            #endif

            if (globalcounter == 0)
                create();
            write(modVec4, key);
        }
    }

    void create()
    {
        globalcounter++;
        string filePathway = "Assets/FREE_xy_pftp_coordinates_Unity.txt";
        File.WriteAllText(filePathway, String.Empty);
    }
    
    void write(Vector4 modVec4, string key)
    {
        if (GameManager.activeSelf == true)
        {
            outWords = outWords + "Key Pushed: \t" + key + "\t\t(X: " + modVec4.x.ToString("F4") + ", Y: " + modVec4.y.ToString("F4") + ")\n";
        }
    }

    public void writeOutFile()
    {
        string filePathway = "Assets/FREE_xy_pftp_coordinates_Unity.txt";
        StreamWriter sw = new StreamWriter(filePathway, true);
        
        sw.WriteLine(outWords);
        sw.WriteLine("Time in milliseconds: " + SentenceScript.finalTime);
        
        sw.Close();
        globalcounter = 0;
    }
    
    public void writeOutHolo()
    {
        #if WINDOWS_UWP
            writeOut();
        #endif
    }

    #if WINDOWS_UWP
    
    public void repeatH(string key, Vector4 modVec4)
    {
        if (GameManager.activeSelf == true)
        {
            strCat(modVec4, key);
        }
        else
        {
            writeOut();
        }
    }

    public async void createH()
    {
        Windows.Storage.StorageFolder storageFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
        Windows.Storage.StorageFile sampleFile =
            await storageFolder.CreateFileAsync("FREE_xy_pftp_coordinates.txt",
                Windows.Storage.CreationCollisionOption.ReplaceExisting);
    }
    
    public async void strCat(Vector4 modVec4, string key)
    {
        outWords = outWords + ("Key Pushed: \t" + key + "\t\t(X: " + modVec4.x.ToString("F4") + ", Y: " + modVec4.y.ToString("F4") + ")\n\n");
    }
    
    public async void writeOut()
    {
        Windows.Storage.StorageFolder storageFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
        Windows.Storage.StorageFile sampleFile =
            await storageFolder.GetFileAsync("FREE_xy_pftp_coordinates.txt");
        
        outWords = outWords + ("Time in milliseconds: " + SentenceScript.finalTime + "\n");
        await Windows.Storage.FileIO.WriteTextAsync(sampleFile, outWords);
    }
    
    #endif
    
}
