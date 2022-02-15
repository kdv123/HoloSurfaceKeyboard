using System;
using Microsoft.MixedReality.Toolkit;
using MRTKExtensions.QRCodes;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.WSA;

/**
 * Author : Joshua Reynolds
 * Adapted from : Joost van Schaik
  * https://localjoost.github.io/Positioning-QR-codes-in-space-with-HoloLens-2-building-a-'poor-man's-Vuforia'/
  * https://localjoost.github.io/Reading-QR-codes-with-an-MRTK2-Extension-Service/
 * Description : tracks qr code and spawns object in when necessary and if isAllowed=true
 */
public class QRTrackerController : MonoBehaviour
{
    [SerializeField]
    private SpatialGraphCoordinateSystemSetter spatialGraphCoordinateSystemSetter;

    [SerializeField]
    private string locationQrValue = string.Empty;

    private Transform markerHolder;
    private AudioSource audioSource;
    private GameObject markerDisplay;
    private QRInfo lastMessage;
    private int trackingCounter;

    public GameObject keyBoard;
    public GameObject QRKeyBoard;
    public GameObject CalibrationPhase;
    public GameObject extraDebuggers;
    public sentenceScript ss;
    public CalibrationScript cs;
    public CalibrationScriptWords csw;

    public bool IsTrackingActive { get; private set; } = true;

    private IQRCodeTrackingService qrCodeTrackingService;
    private IQRCodeTrackingService QRCodeTrackingService
    {
        get
        {
            while (!MixedRealityToolkit.IsInitialized && Time.time < 5) ;
            return qrCodeTrackingService ??
                   (qrCodeTrackingService = MixedRealityToolkit.Instance.GetService<IQRCodeTrackingService>());
        }
    }

    private void Start()
    {
        if (!QRCodeTrackingService.IsSupported)
        {
            return;
        }

        markerHolder = spatialGraphCoordinateSystemSetter.gameObject.transform;
        markerDisplay = markerHolder.GetChild(0).gameObject;
        markerDisplay.SetActive(false);

        audioSource = markerHolder.gameObject.GetComponent<AudioSource>();

        QRCodeTrackingService.QRCodeFound += ProcessTrackingFound;
        spatialGraphCoordinateSystemSetter.PositionAcquired += SetScale;
        spatialGraphCoordinateSystemSetter.PositionAcquisitionFailed += 
            (s,e) => ResetTracking();


        if (QRCodeTrackingService.IsInitialized)
        {
            StartTracking();
        }
        else
        {
            QRCodeTrackingService.Initialized += QRCodeTrackingService_Initialized;
        }
    }

    private void QRCodeTrackingService_Initialized(object sender, EventArgs e)
    {
        StartTracking();
    }

    private void StartTracking()
    {
        QRCodeTrackingService.Enable();
    }

    public void ResetTracking()
    {
        if (QRCodeTrackingService.IsInitialized)
        {
            markerDisplay.SetActive(false);
            IsTrackingActive = true;
            trackingCounter = 0;
        }
        
        keyBoard.gameObject.SetActive(false); // my line
        ss.whatToDoObjectQ.SetActive(true); // my line
        ss.whatToDoObjectF.SetActive(true);
        //QRKeyBoard.gameObject.SetActive(true);
        QRKeyBoard.gameObject.SetActive(false);
        CalibrationPhase.gameObject.SetActive(true);
        extraDebuggers.SetActive(false);

        ss.qrrl.globalCounter = 0;
        csw.calibrateButtonQ.SetActive(false);
        csw.calibrateButtonF.SetActive(false);
        csw.isCalibrating = false;
        csw.typedDisplayQ.text = "_";
        csw.typedDisplayF.text = "_";
        csw.text.text = "Lowest Height: ";
        csw.bsQ.clear();
        csw.bsF.clear();
        // cs.Starter();
    }

    private void ProcessTrackingFound(object sender, QRInfo msg)
    {
        if ( msg == null || !IsTrackingActive)
        {
            return;
        }

        lastMessage = msg;

        if (msg.Data == locationQrValue)
        {
            if (trackingCounter++ == 2)
            {
                IsTrackingActive = false;
                spatialGraphCoordinateSystemSetter.SetLocationIdSize(msg.SpatialGraphNodeId,
                    msg.PhysicalSideLength);
            }
        }
    }


    private void SetScale(object sender, Pose pose)
    {
        markerHolder.localScale = Vector3.one * lastMessage.PhysicalSideLength;
        markerDisplay.SetActive(true);
        PositionSet?.Invoke(this, pose);
        audioSource.Play();
    }

    public EventHandler<Pose> PositionSet;
}
