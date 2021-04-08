using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if WINDOWS_UWP
    using Windows.Storage;
    using System.Threading.Tasks;
    using Windows.Data.Xml.Dom;
    using System;
#endif

public class exportFile : MonoBehaviour
{
    
    public GameObject gameManager;
    private bool isActive = false;

    public void click1()
    {
        #if WINDOWS_UWP
        click2();
        #endif
    }
    
    #if WINDOWS_UWP

    public async void click2()
    {

        
        // Create sample file; replace if exists.
        Windows.Storage.StorageFolder storageFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
        Windows.Storage.StorageFile sampleFile =
            await storageFolder.CreateFileAsync("xy_rftp_coordinates.txt",
                Windows.Storage.CreationCollisionOption.ReplaceExisting);

        Invoke("write", 2);

        // do
        // {
        //     //InvokeRepeating("checkIfActive", 0, 0.1f);
        //     //Invoke("checkIfActive", 5);
        //     checkIfActive();
        // } while (isActive == false);
    }

    //#endif

    // private void checkIfActive()
    // {
    //     if (gameManager.activeSelf == true)
    //     {
    //         isActive = true;
    //         //#if WINDOWS_UWP
    //         write();
    //         //#endif
    //     }
    //     else
    //     {
    //         return;
    //     }
    // }

    //#if WINDOWS_UWP
    
    public async void write()
    {
        
        Windows.Storage.StorageFolder storageFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
        Windows.Storage.StorageFile sampleFile =
            await storageFolder.GetFileAsync("xy_rftp_coordinates.txt");
        
        await Windows.Storage.FileIO.WriteTextAsync(sampleFile, "it worked");
        
    }
     #endif
}

// using UnityEngine;
// // using Windows.Storage;
//
// #if WINDOWS_UWP
//     using Windows.Storage;
//     using System.Threading.Tasks;
//     using Windows.Data.Xml.Dom;
//     using System;
// #endif
//
// public class exportFile : MonoBehaviour
// {
//     
//     #if WINDOWS_UWP
//     private string _systemInfo;
//
//     private void Start ()
//     {
//         string deviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier;
//         string graphicsDeviceID = SystemInfo.graphicsDeviceID.ToString();
//         _systemInfo = deviceUniqueIdentifier + " : " + graphicsDeviceID;
//
//         WriteFileAsync();
//
//         ReadFileAsync();
//     }
//
//     // read
//     private async System.Threading.Tasks.Task ReadFileAsync()
//     {
//         Windows.Storage.StorageFolder folder;
//         folder = Windows.Storage.ApplicationData.Current.RoamingFolder;
//         Windows.Storage.StorageFile file = await folder.TryGetItemAsync("SystemInfo.xml") as Windows.Storage.StorageFile;
//         if (file != null)
//         {
//             string positionstring = await Windows.Storage.FileIO.ReadTextAsync(file);
//             if (_systemInfo != positionstring)
//             {
//                 Application.Quit();
//             }
//         }
//         else
//         {
//             Application.Quit();
//         }
//     }
//
//     // write
//     private async System.Threading.Tasks.Task WriteFileAsync()
//     {
//         Windows.Storage.StorageFolder folder;
//         folder = Windows.Storage.ApplicationData.Current.RoamingFolder;
//         Windows.Storage.StorageFile file = await folder.CreateFileAsync("SystemInfo_backup.xml", Windows.Storage.CreationCollisionOption.ReplaceExisting);
//         using (Windows.Storage.StorageStreamTransaction transaction = await file.OpenTransactedWriteAsync())
//         {
//             using (Windows.Storage.Streams.DataWriter dataWriter = new Windows.Storage.Streams.DataWriter(transaction.Stream))
//             {
//                 dataWriter.WriteString("TEST");
//                 transaction.Stream.Size = await dataWriter.StoreAsync();
//                 await transaction.CommitAsync();
//             }
//         }
//     }
//     #endif
// }
