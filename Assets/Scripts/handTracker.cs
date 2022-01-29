using System;
using System.IO;
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

public class handTracker : MonoBehaviour
{
    public String outWordsF = "# Coordinates of the key push via a pointer finger tip position (FIXED MID-AIR tests): #\n" +
                              "# Where X position is left and right #\n" +
                              "# Where Y position is up and down #\n" +
                              "# Where Z position is forward and backward #\n" +
                              "# ------------------------------------------------------- #\n \n";
    public String outWordsQH = "# Coordinates of the key push via a pointer finger tip position (HORIZONTAL QR tests): #\n" +
                               "# Where X position is left and right #\n" +
                               "# Where Y position is up and down #\n" +
                               "# Where Z position is forward and backward #\n" +
                               "# ------------------------------------------------------- #\n \n";
    
    public String outWordsQV = "# Coordinates of the key push via a pointer finger tip position (VERTICAL QR tests): #\n" +
                               "# Where X position is left and right #\n" +
                               "# Where Y position is up and down #\n" +
                               "# Where Z position is forward and backward #\n" +
                               "# ------------------------------------------------------- #\n \n";
    
    public String outWordsFC = "# Continual coordinates of the key push via a pointer finger tip position (FIXED MID-AIR tests): #\n" +
                               "# Where X position is left and right #\n" +
                               "# Where Y position is up and down #\n" +
                               "# Where Z position is forward and backward #\n" +
                               "# ------------------------------------------------------- #\n \n";
    public String outWordsQHC = "# Continual coordinates of the key push via a pointer finger tip position (HORIZONTAL QR tests): #\n" +
                                "# Where X position is left and right #\n" +
                                "# Where Y position is up and down #\n" +
                                "# Where Z position is forward and backward #\n" +
                                "# ------------------------------------------------------- #\n \n";
    
    public String outWordsQVC = "# Continual coordinates of the key push via a pointer finger tip position (VERTICAL QR tests): #\n" +
                                "# Where X position is left and right #\n" +
                                "# Where Y position is up and down #\n" +
                                "# Where Z position is forward and backward #\n" +
                                "# ------------------------------------------------------- #\n \n";

    public GameObject keyboardFree;
    public GameObject keyboardQr;

    public GameObject freeScene;
    public GameObject qrScene;
    
    public GameObject horizontalSwitch;
    public GameObject verticalSwitch;
    public GameObject freeSwitch;

    public sentenceScript ss;
    public FPSTracker fps;
    private DateTime currentTime;
    private string dateString;


    public void createF()
    {
        currentTime = DateTime.Now;
        dateString = currentTime.ToString("hh.mm.ss");
        
        string filePathwayF = "Assets/" + ss.odd_even_num + "_" + dateString + "_MIDAIR_FIXED_xy_pftp_coordinates_Unity.txt";
        File.WriteAllText(filePathwayF, String.Empty);
        
        string filePathwayFC = "Assets/" + ss.odd_even_num + "_" + dateString + "_MIDAIR_FIXED_xy_pftp_continual_coordinates_Unity.txt";
        File.WriteAllText(filePathwayFC, String.Empty);
        
        #if WINDOWS_UWP
            createH2();
            createH4();
        #endif
        
        InvokeRepeating("repeat1", 0f, .033f); // 1/30th of a second
    }
    
    public void createQH()
    {
        currentTime = DateTime.Now;
        dateString = currentTime.ToString("hh.mm.ss");

        string filePathwayQH = "Assets/" + ss.odd_even_num + "_" + dateString + "_HORIZONTAL_QR_xy_pftp_coordinates_Unity.txt";
        File.WriteAllText(filePathwayQH, String.Empty);

        string filePathwayQHC = "Assets/" + ss.odd_even_num + "_" + dateString + "_HORIZONTAL_QR_xy_pftp_continual_coordinates_Unity.txt";
        File.WriteAllText(filePathwayQHC, String.Empty);

        #if WINDOWS_UWP
            createH1();
            createH3();
        #endif
        
        InvokeRepeating("repeat1", 0f, .033f); // 1/30th of a second
    }
    
    public void createQV()
    {
        currentTime = DateTime.Now;
        dateString = currentTime.ToString("hh.mm.ss");

        string filePathwayQV = "Assets/" + ss.odd_even_num + "_" + dateString + "_VERTICAL_QR_xy_pftp_coordinates_Unity.txt";
        File.WriteAllText(filePathwayQV, String.Empty);

        string filePathwayQVC = "Assets/" + ss.odd_even_num + "_" + dateString + "_VERTICAL_QR_xy_pftp_continual_coordinates_Unity.txt";
        File.WriteAllText(filePathwayQVC, String.Empty);

        #if WINDOWS_UWP
            createH5();
            createH6();
        #endif
        
        InvokeRepeating("repeat1", 0f, .033f); // 1/30th of a second
    }
    
    public void create()
    {
        currentTime = DateTime.Now;
        dateString = currentTime.ToString("hh.mm.ss");

        string filePathwayQH = "Assets/" + ss.odd_even_num + "_" + dateString + "_HORIZONTAL_QR_xy_pftp_coordinates_Unity.txt";
        File.WriteAllText(filePathwayQH, String.Empty);
        
        string filePathwayQV = "Assets/" + ss.odd_even_num + "_" + dateString + "_VERTICAL_QR_xy_pftp_coordinates_Unity.txt";
        File.WriteAllText(filePathwayQV, String.Empty);
        
        string filePathwayF = "Assets/" + ss.odd_even_num + "_" + dateString + "_MIDAIR_FIXED_xy_pftp_coordinates_Unity.txt";
        File.WriteAllText(filePathwayF, String.Empty);
        
        string filePathwayQHC = "Assets/" + ss.odd_even_num + "_" + dateString + "_HORIZONTAL_QR_xy_pftp_continual_coordinates_Unity.txt";
        File.WriteAllText(filePathwayQHC, String.Empty);
        
        string filePathwayQVC = "Assets/" + ss.odd_even_num + "_" + dateString + "_VERTICAL_QR_xy_pftp_continual_coordinates_Unity.txt";
        File.WriteAllText(filePathwayQVC, String.Empty);
        
        string filePathwayFC = "Assets/" + ss.odd_even_num + "_" + dateString + "_MIDAIR_FIXED_xy_pftp_continual_coordinates_Unity.txt";
        File.WriteAllText(filePathwayFC, String.Empty);
        
        #if WINDOWS_UWP
            createH1();
            createH2();
            createH3();
            createH4();
            createH5();
            createH6();
        #endif
        
        InvokeRepeating("repeat1", 0f, .033f); // 1/30th of a second
    }
    
    public void writeKey(string key)
    {
        HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Both, out MixedRealityPose pose);

        if (freeScene.activeSelf == true)
        {
            Vector4 baseVec4F = new Vector4(pose.Position.x, pose.Position.y, pose.Position.z, 1);
            Vector4 modVec4F = keyboardFree.transform.worldToLocalMatrix * baseVec4F;

            outWordsF += ss.Time() + ",Key Pushed," + key + ",(X: " + modVec4F.x.ToString("F4") + 
                                                             " Y: " + modVec4F.y.ToString("F4") + 
                                                             " Z: " + modVec4F.z.ToString("F4") + ")," + fps.FPS_Text() + "\n";
        } 
        else if (qrScene.activeSelf == true)
        {
            Vector4 baseVec4Q = new Vector4(pose.Position.x, pose.Position.y, pose.Position.z, 1);
            Vector4 modVec4Q = keyboardQr.transform.worldToLocalMatrix * baseVec4Q;

            if (horizontalSwitch.activeSelf == true)
                outWordsQH += ss.Time() + ",Key Pushed," + key + ",(X: " + modVec4Q.x.ToString("F4") + 
                                                                  " Y: " + modVec4Q.y.ToString("F4") + 
                                                                  " Z: " + modVec4Q.z.ToString("F4") + ")," + fps.FPS_Text() + "\n";
            
            if (verticalSwitch.activeSelf == true)
                outWordsQV += ss.Time() + ",Key Pushed," + key + ",(X: " + modVec4Q.x.ToString("F4") + 
                                                                    " Y: " + modVec4Q.y.ToString("F4") + 
                                                                    " Z: " + modVec4Q.z.ToString("F4") + ")," + fps.FPS_Text() + "\n";
        }
    }

    public void writeOut()
    {
        if (freeScene.activeSelf == true)
        {
            string filePathwayF = "Assets/" + ss.odd_even_num + "_" + dateString + "_MIDAIR_FIXED_xy_pftp_coordinates_Unity.txt";
            StreamWriter swf = new StreamWriter(filePathwayF, true);
        
            swf.WriteLine(outWordsF);

            swf.Close();
            
            string filePathwayFC = "Assets/" + ss.odd_even_num + "_" + dateString + "_MIDAIR_FIXED_xy_pftp_continual_coordinates_Unity.txt";
            StreamWriter swfc = new StreamWriter(filePathwayFC, true);
        
            swfc.WriteLine(outWordsFC);

            swfc.Close();
            
            #if WINDOWS_UWP
                writeOutH();
            #endif
        }
        else if (qrScene.activeSelf == true)
        {
            if (horizontalSwitch.activeSelf == true)
            {
                string filePathwayQH = "Assets/" + ss.odd_even_num + "_" + dateString + "_HORIZONTAL_QR_xy_pftp_coordinates_Unity.txt";
                StreamWriter swqh = new StreamWriter(filePathwayQH, true);
                
                string filePathwayQHC = "Assets/" + ss.odd_even_num + "_" + dateString + "_HORIZONTAL_QR_xy_pftp_continual_coordinates_Unity.txt";
                StreamWriter swqhc = new StreamWriter(filePathwayQHC, true);
                
                swqh.WriteLine(outWordsQH);
                swqhc.WriteLine(outWordsQHC);
                
                swqh.Close();
                swqhc.Close();
            }

            if (verticalSwitch.activeSelf == true)
            {
                string filePathwayQV = "Assets/" + ss.odd_even_num + "_" + dateString + "_VERTICAL_QR_xy_pftp_coordinates_Unity.txt";
                StreamWriter swqv = new StreamWriter(filePathwayQV, true);
                
                string filePathwayQVC = "Assets/" + ss.odd_even_num + "_" + dateString + "_VERTICAL_QR_xy_pftp_continual_coordinates_Unity.txt";
                StreamWriter swqvc = new StreamWriter(filePathwayQVC, true);
                
                swqv.WriteLine(outWordsQV);
                swqvc.WriteLine(outWordsQVC);
                
                swqv.Close();
                swqvc.Close();
            }
            
            #if WINDOWS_UWP
                writeOutH();
            #endif
        }
    }

    public void finish()
    {
        CancelInvoke("repeat1");
    }

    void repeat1()
    {
        if (freeScene.activeSelf == true)
        {
            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose pose) == true)
            {
                Vector4 baseVec4F = new Vector4(pose.Position.x, pose.Position.y, pose.Position.z, 1);
                Vector4 modVec4F = keyboardFree.transform.worldToLocalMatrix * baseVec4F;

                outWordsFC += ss.Time() + ",(X: " + modVec4F.x.ToString("F4") + 
                                            " Y: " + modVec4F.y.ToString("F4") +
                                            " Z: " + modVec4F.z.ToString("F4") + "),"
                                            + "LEFT HAND," + fps.FPS_Text() + "\n";
            }
            else if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose pose2) == false)
            {
                Vector4 baseVec4F = new Vector4(pose2.Position.x, pose2.Position.y, pose2.Position.z, 1);
                Vector4 modVec4F = keyboardFree.transform.worldToLocalMatrix * baseVec4F;

                outWordsFC += ss.Time() + ",LEFT HANDTRACKING LOST," + fps.FPS_Text() + "\n";
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose3) == true)
            {
                Vector4 baseVec4F = new Vector4(pose3.Position.x, pose3.Position.y, pose3.Position.z, 1);
                Vector4 modVec4F = keyboardFree.transform.worldToLocalMatrix * baseVec4F;

                outWordsFC += ss.Time() + ",(X: " + modVec4F.x.ToString("F4") + 
                                            " Y: " + modVec4F.y.ToString("F4") +
                                            " Z: " + modVec4F.z.ToString("F4") + "),"
                                            + "RIGHT HAND," + fps.FPS_Text() + "\n";
            }
            else if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose4) == false)
            {
                Vector4 baseVec4F = new Vector4(pose4.Position.x, pose4.Position.y, pose4.Position.z, 1);
                Vector4 modVec4F = keyboardFree.transform.worldToLocalMatrix * baseVec4F;

                outWordsFC += ss.Time() + ",RIGHT HANDTRACKING LOST," + fps.FPS_Text() + "\n";
            }
        }
        else if (qrScene.activeSelf == true)
        {
            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose pose) == true)
            {
                Vector4 baseVec4F = new Vector4(pose.Position.x, pose.Position.y, pose.Position.z, 1);
                Vector4 modVec4F = keyboardFree.transform.worldToLocalMatrix * baseVec4F;

                if (horizontalSwitch.activeSelf == true)
                    outWordsQHC += ss.Time() + ",(X: " + modVec4F.x.ToString("F4") + 
                                                " Y: " + modVec4F.y.ToString("F4") +
                                                " Z: " + modVec4F.z.ToString("F4") + "),"
                                                + "LEFT HAND," + fps.FPS_Text() + "\n";
                
                if (verticalSwitch.activeSelf == true)
                    outWordsQVC += ss.Time() + ",(X: " + modVec4F.x.ToString("F4") + 
                                                " Y: " + modVec4F.y.ToString("F4") +
                                                " Z: " + modVec4F.z.ToString("F4") + "),"
                                                + "LEFT HAND," + fps.FPS_Text() + "\n";
            }
            else if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose pose2) == false)
            {
                Vector4 baseVec4F = new Vector4(pose2.Position.x, pose2.Position.y, pose2.Position.z, 1);
                Vector4 modVec4F = keyboardFree.transform.worldToLocalMatrix * baseVec4F;

                if (horizontalSwitch.activeSelf == true)
                    outWordsQHC += ss.Time() + ",LEFT HANDTRACKING LOST," + fps.FPS_Text() + "\n";
                
                if (verticalSwitch.activeSelf == true)
                    outWordsQVC += ss.Time() + ",LEFT HANDTRACKING LOST," + fps.FPS_Text() + "\n";
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose3) == true)
            {
                Vector4 baseVec4F = new Vector4(pose3.Position.x, pose3.Position.y, pose3.Position.z, 1);
                Vector4 modVec4F = keyboardFree.transform.worldToLocalMatrix * baseVec4F;

                if (horizontalSwitch.activeSelf == true)
                    outWordsQHC += ss.Time() + ",(X: " + modVec4F.x.ToString("F4") + 
                                                " Y: " + modVec4F.y.ToString("F4") +
                                                " Z: " + modVec4F.z.ToString("F4") + "),"
                                                + "RIGHT HAND," + fps.FPS_Text() + "\n";
                
                if (verticalSwitch.activeSelf == true)
                    outWordsQVC += ss.Time() + ",(X: " + modVec4F.x.ToString("F4") + 
                                                " Y: " + modVec4F.y.ToString("F4") +
                                                " Z: " + modVec4F.z.ToString("F4") + "),"
                                                + "RIGHT HAND," + fps.FPS_Text() + "\n";
            }
            else if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose4) == false)
            {
                Vector4 baseVec4F = new Vector4(pose4.Position.x, pose4.Position.y, pose4.Position.z, 1);
                Vector4 modVec4F = keyboardFree.transform.worldToLocalMatrix * baseVec4F;

                if (horizontalSwitch.activeSelf == true)
                    outWordsQHC += ss.Time() + ",RIGHT HANDTRACKING LOST," + fps.FPS_Text() + "\n";
                
                if (verticalSwitch.activeSelf == true)
                    outWordsQVC += ss.Time() + ",RIGHT HANDTRACKING LOST," + fps.FPS_Text() + "\n";
            }
        }
    }
    
    #if WINDOWS_UWP
    public async void createH1()
    {
        Windows.Storage.StorageFolder storageFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
        Windows.Storage.StorageFile sampleFile =
            await storageFolder.CreateFileAsync(ss.odd_even_num + "_" + dateString + "_HORIZONTAL_QR_xy_pftp_coordinates_Unity.txt",
                Windows.Storage.CreationCollisionOption.ReplaceExisting);
    }
    
    public async void createH2()
    {
        Windows.Storage.StorageFolder storageFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
        Windows.Storage.StorageFile sampleFile = 
            await storageFolder.CreateFileAsync(ss.odd_even_num + "_" + dateString + "_MIDAIR_FIXED_xy_pftp_coordinates_Unity.txt",
                Windows.Storage.CreationCollisionOption.ReplaceExisting);
    }
    
    public async void createH3()
    {
        Windows.Storage.StorageFolder storageFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
        Windows.Storage.StorageFile sampleFile =
            await storageFolder.CreateFileAsync(ss.odd_even_num + "_" + dateString + "_HORIZONTAL_QR_xy_pftp_continual_coordinates_Unity.txt",
                Windows.Storage.CreationCollisionOption.ReplaceExisting);
    }
    
    public async void createH4()
    {
        Windows.Storage.StorageFolder storageFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
        Windows.Storage.StorageFile sampleFile = 
            await storageFolder.CreateFileAsync(ss.odd_even_num + "_" + dateString + "_MIDAIR_FIXED_xy_pftp_continual_coordinates_Unity.txt",
                Windows.Storage.CreationCollisionOption.ReplaceExisting);
    }

    public async void createH5()
    {
        Windows.Storage.StorageFolder storageFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
        Windows.Storage.StorageFile sampleFile = 
            await storageFolder.CreateFileAsync(ss.odd_even_num + "_" + dateString + "_VERTICAL_QR_xy_pftp_coordinates_Unity.txt",
                Windows.Storage.CreationCollisionOption.ReplaceExisting);
    }
    
    public async void createH6()
    {
        Windows.Storage.StorageFolder storageFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
        Windows.Storage.StorageFile sampleFile = 
            await storageFolder.CreateFileAsync(ss.odd_even_num + "_" + dateString + "_VERTICAL_QR_xy_pftp_continual_coordinates_Unity.txt",
                Windows.Storage.CreationCollisionOption.ReplaceExisting);
    }
    
    public async void writeOutH()
    {
        if (freeScene.activeSelf == true)
        {
            Windows.Storage.StorageFolder storageFolder =
                Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile =
                await storageFolder.GetFileAsync(ss.odd_even_num + "_" + dateString + "_MIDAIR_FIXED_xy_pftp_coordinates_Unity.txt");
        
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, outWordsF);
            
            Windows.Storage.StorageFolder storageFolder1 =
                Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile1 =
                await storageFolder1.GetFileAsync(ss.odd_even_num + "_" + dateString + "_MIDAIR_FIXED_xy_pftp_continual_coordinates_Unity.txt");
        
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile1, outWordsFC);
        }
        else if (qrScene.activeSelf == true)
        {

            if (horizontalSwitch.activeSelf == true)
            {
                Windows.Storage.StorageFolder storageFolder =
                    Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile sampleFile =
                    await storageFolder.GetFileAsync(ss.odd_even_num + "_" + dateString + "_HORIZONTAL_QR_xy_pftp_coordinates_Unity.txt");
            
                await Windows.Storage.FileIO.WriteTextAsync(sampleFile, outWordsQH);
                
                Windows.Storage.StorageFolder storageFolder1 =
                    Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile sampleFile1 =
                    await storageFolder1.GetFileAsync(ss.odd_even_num + "_" + dateString + "_HORIZONTAL_QR_xy_pftp_continual_coordinates_Unity.txt");
            
                await Windows.Storage.FileIO.WriteTextAsync(sampleFile1, outWordsQHC);
            }
            
            if (verticalSwitch.activeSelf == true)
            {
                Windows.Storage.StorageFolder storageFolder2 =
                    Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile sampleFile2 =
                    await storageFolder2.GetFileAsync(ss.odd_even_num + "_" + dateString + "_VERTICAL_QR_xy_pftp_coordinates_Unity.txt");
            
                await Windows.Storage.FileIO.WriteTextAsync(sampleFile2, outWordsQV);
                
                Windows.Storage.StorageFolder storageFolder3 =
                    Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile sampleFile3 =
                    await storageFolder3.GetFileAsync(ss.odd_even_num + "_" + dateString + "_VERTICAL_QR_xy_pftp_continual_coordinates_Unity.txt");
            
                await Windows.Storage.FileIO.WriteTextAsync(sampleFile3, outWordsQVC);
            }
        }
    }
    #endif
}
