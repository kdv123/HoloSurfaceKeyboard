using System;
using Microsoft.MixedReality.Toolkit;

namespace MRTKExtensions.QRCodes
{ 
    /**
    * Author : Joshua Reynolds
    * Adapted from : Joost van Schaik
     * https://localjoost.github.io/Positioning-QR-codes-in-space-with-HoloLens-2-building-a-'poor-man's-Vuforia'/
     * https://localjoost.github.io/Reading-QR-codes-with-an-MRTK2-Extension-Service/
    * Description : Interface to hold qr actions
    */
    public interface IQRCodeTrackingService : IMixedRealityExtensionService
    {
        event EventHandler Initialized;
        event EventHandler<string> ProgressMessageSent;
        event EventHandler<QRInfo> QRCodeFound;
        bool InitializationFailed { get;}
        string ErrorMessage { get; }
        string ProgressMessages { get; }
        bool IsSupported { get; }
        bool IsTracking { get; }
        bool IsInitialized { get; }
    }
}