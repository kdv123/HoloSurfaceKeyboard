using System;
using Microsoft.MixedReality.QR;

namespace MRTKExtensions.QRCodes
{
    /**
    * Author : Joshua Reynolds
    * Adapted from : Joost van Schaik
     * https://localjoost.github.io/Positioning-QR-codes-in-space-with-HoloLens-2-building-a-'poor-man's-Vuforia'/
     * https://localjoost.github.io/Reading-QR-codes-with-an-MRTK2-Extension-Service/
    * Description : gets qr code information
    */
	public class QRInfo
	{
        public QRInfo(QRCode code)
        {
            Id = code.Id;
            SpatialGraphNodeId = code.SpatialGraphNodeId;
            Version = code.Version;
            PhysicalSideLength = code.PhysicalSideLength;
            Data = code.Data;
            SystemRelativeLastDetectedTime = code.SystemRelativeLastDetectedTime;
            LastDetectedTime = code.LastDetectedTime;
        }

        public Guid Id { get; }
        public Guid SpatialGraphNodeId { get; }
        public QRVersion Version { get; }
        public float PhysicalSideLength { get; }
        public string Data { get; }
        public TimeSpan SystemRelativeLastDetectedTime { get; }
        public DateTimeOffset LastDetectedTime { get; }

    }
}