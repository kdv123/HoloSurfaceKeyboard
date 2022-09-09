using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.WebCam;

/**
 * Author      : Joshua Reynolds
 * Email       : joshuare@mtu.edu
 * Description : This class houses the function for recording the experiment - No longer active in current program.
 */
public class recordScript : MonoBehaviour
{
    // VideoCapture m_VideoCapture = null;
    // public sentenceScript ss;
    // private DateTime currentTime;
    // private string dateString;
    
    public void buttonStartRecording()
    {
        // StartVideoCaptureTest();
    }

    void Update()
    {
        // if (m_VideoCapture == null || !m_VideoCapture.IsRecording)
        // {
        //     return;
        // }
    }

    void StartVideoCaptureTest()
    {
        //
        // Resolution cameraResolution = VideoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();
        // Debug.Log(cameraResolution);
        //
        // float cameraFramerate = VideoCapture.GetSupportedFrameRatesForResolution(cameraResolution).OrderByDescending((fps) => fps).First();
        // Debug.Log(cameraFramerate);
        //
        // VideoCapture.CreateAsync(true, delegate (VideoCapture videoCapture)
        // {
        //     if (videoCapture != null)
        //     {
        //         m_VideoCapture = videoCapture;
        //         Debug.Log("Created VideoCapture Instance!");
        //
        //         CameraParameters cameraParameters = new CameraParameters();
        //         cameraParameters.hologramOpacity = 1.0f;
        //         cameraParameters.frameRate = cameraFramerate;
        //         cameraParameters.cameraResolutionWidth = cameraResolution.width;
        //         cameraParameters.cameraResolutionHeight = cameraResolution.height;
        //         cameraParameters.pixelFormat = CapturePixelFormat.BGRA32;
        //
        //         m_VideoCapture.StartVideoModeAsync(cameraParameters,
        //                                            VideoCapture.AudioState.ApplicationAndMicAudio,
        //                                            OnStartedVideoCaptureMode);
        //     }
        //     else
        //     {
        //         Debug.LogError("Failed to create VideoCapture Instance!");
        //     }
        // });
    }

    void OnStartedVideoCaptureMode(VideoCapture.VideoCaptureResult result)
    {
        // currentTime = DateTime.Now;
        // dateString = currentTime.ToString("hh.mm.ss");
        //
        // Debug.Log("Started Video Capture Mode!");
        // string filename = string.Format("{0}_{1}_Coordinates_Video_Unity.mp4", ss.odd_even_num, dateString);
        // string filepath = System.IO.Path.Combine(Application.persistentDataPath, filename);
        // filepath = filepath.Replace("/", @"\");
        // m_VideoCapture.StartRecordingAsync(filepath, OnStartedRecordingVideo);
    }

    void OnStoppedVideoCaptureMode(VideoCapture.VideoCaptureResult result)
    {
        // Debug.Log("Stopped Video Capture Mode!");
    }

    void OnStartedRecordingVideo(VideoCapture.VideoCaptureResult result)
    {
        // Debug.Log("Started Recording Video!");
    }

    void OnStoppedRecordingVideo(VideoCapture.VideoCaptureResult result)
    {
        // Debug.Log("Stopped Recording Video!");
        // m_VideoCapture.StopVideoModeAsync(OnStoppedVideoCaptureMode);
    }

    public void buttonStopRecording()
    {
        // m_VideoCapture.StopRecordingAsync(OnStoppedRecordingVideo);
    }
}
