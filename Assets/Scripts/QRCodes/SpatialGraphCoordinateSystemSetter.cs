using System;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;
using UnityEngine.XR.WSA;
#if WINDOWS_UWP
using Windows.Perception.Spatial;
#endif

namespace MRTKExtensions.QRCodes
{
    
    /**
    * Author : Joshua Reynolds
    * Adapted from : Joost van Schaik
     * https://localjoost.github.io/Positioning-QR-codes-in-space-with-HoloLens-2-building-a-'poor-man's-Vuforia'/
     * https://localjoost.github.io/Reading-QR-codes-with-an-MRTK2-Extension-Service/
    * Description : gets local coordinates of qr code then adds keyboard object to it
    */
    public class SpatialGraphCoordinateSystemSetter : MonoBehaviour
    {
        public qrRaiseLower qrrl;
        public sentenceScript ss;

        public GameObject camera;

        public EventHandler<Pose> PositionAcquired;
        public EventHandler PositionAcquisitionFailed;

        private Tuple<Guid, float> locationIdSize = null;

        private PositionalLocatorState CurrentState { get; set; }

        public float starterHeight = 3.0f; // old value: 0.025f


        void Awake()
        {
            CurrentState = PositionalLocatorState.Unavailable;
        }

        void Start()
        {
            WorldManager.OnPositionalLocatorStateChanged += WorldManager_OnPositionalLocatorStateChanged;
            CurrentState = WorldManager.state;
        }

        private void WorldManager_OnPositionalLocatorStateChanged(PositionalLocatorState oldState, PositionalLocatorState newState)
        {
            CurrentState = newState;
            gameObject.SetActive(newState == PositionalLocatorState.Active);
        }

        public void SetLocationIdSize(Guid spatialGraphNodeId, float physicalSideLength)
        {
            if (locationIdSize == null)
            {
                locationIdSize = new Tuple<Guid, float>(spatialGraphNodeId, physicalSideLength);
            }
        }

        void Update()
        {
            if (locationIdSize != null)
            {
                UpdateLocation(locationIdSize.Item1, locationIdSize.Item2);
                locationIdSize = null;
            }
        }

        private void UpdateLocation(Guid spatialGraphNodeId, float physicalSideLength)
        {
            if (CurrentState != PositionalLocatorState.Active)
            {
                PositionAcquisitionFailed?.Invoke(this, null);
                return;
            }

            System.Numerics.Matrix4x4? relativePose = System.Numerics.Matrix4x4.Identity;
#if WINDOWS_UWP

            SpatialCoordinateSystem coordinateSystem = Windows.Perception.Spatial.Preview.SpatialGraphInteropPreview.CreateCoordinateSystemForNode(spatialGraphNodeId);

            if (coordinateSystem == null)
            {
                PositionAcquisitionFailed?.Invoke(this, null);
                return;
            }

            SpatialCoordinateSystem rootSpatialCoordinateSystem = (SpatialCoordinateSystem)System.Runtime.InteropServices.Marshal.GetObjectForIUnknown(WorldManager.GetNativeISpatialCoordinateSystemPtr());

            // Get the relative transform from the unity origin
            relativePose = coordinateSystem.TryGetTransformTo(rootSpatialCoordinateSystem);
#endif

            if (relativePose == null)
            {
                PositionAcquisitionFailed?.Invoke(this, null);
                return;
            }

            System.Numerics.Matrix4x4 newMatrix = relativePose.Value;

            // Platform coordinates are all right handed and unity uses left handed matrices. so we convert the matrix
            // from rhs-rhs to lhs-lhs 
            // Convert from right to left coordinate system
            newMatrix.M13 = -newMatrix.M13;
            newMatrix.M23 = -newMatrix.M23;
            newMatrix.M43 = -newMatrix.M43;

            newMatrix.M31 = -newMatrix.M31;
            newMatrix.M32 = -newMatrix.M32;
            newMatrix.M34 = -newMatrix.M34;

            System.Numerics.Vector3 scale;
            System.Numerics.Quaternion rotation1;
            System.Numerics.Vector3 translation1;

            System.Numerics.Matrix4x4.Decompose(newMatrix, out scale, out rotation1, out translation1);
            var translation = new Vector3(translation1.X, translation1.Y, translation1.Z);
            var rotation = new Quaternion(rotation1.X, rotation1.Y, rotation1.Z, rotation1.W);
            var pose = new Pose(translation, rotation);
            

            // If there is a parent to the camera that means we are using teleport and we should not apply the teleport
            // to these objects so apply the inverse
            if (CameraCache.Main.transform.parent != null)
            {
                pose = pose.GetTransformedBy(CameraCache.Main.transform.parent);
            }
            // Rotate 90 degrees 'forward' over 'right' so 'up' is pointing straight up from the QR code
            
            
            if (ss.ht.horizontalSwitch.activeSelf == true)
                pose.rotation *= Quaternion.Euler(-180, 0, 0);
            else if (ss.ht.verticalSwitch.activeSelf == true)
                pose.rotation *= Quaternion.Euler(90, 0, 0);
            else if (ss.ht.freeSwitch.activeSelf == true)
                pose.rotation *= Quaternion.Euler(-195, 0, 0);
            

            // // Move the anchor point to the *center* of the QR code
            // var deltaToCenter = physicalSideLength * 0.5f;
            // pose.position += (pose.rotation * (deltaToCenter * Vector3.right) -
            //                   pose.rotation * (deltaToCenter * Vector3.forward));
            // gameObject.transform.SetPositionAndRotation(pose.position, pose.rotation);
            // PositionAcquired?.Invoke(this, pose);
            
            // move the anchor point to the *top right* of the qr code
            var sideLength = physicalSideLength;
            if (ss.ht.horizontalSwitch.activeSelf == true)
            {
                pose.position += (pose.rotation * ((4.0f * sideLength) * Vector3.right) - // right
                                  pose.rotation * ((sideLength * .75f) * Vector3.up) - // down
                                  //pose.rotation * ((starterHeight * .75f) * Vector3.forward)); // into wall
                                  pose.rotation * (0.025f * Vector3.forward));
            }
            else if (ss.ht.verticalSwitch.activeSelf == true)
            {
                pose.position += (pose.rotation * ((4.0f * sideLength) * Vector3.right) - // right
                                  pose.rotation * ((sideLength * 3.0f) * Vector3.down) -
                                  //pose.rotation * ((starterHeight * .75f) * Vector3.forward)); // into wall
                                  pose.rotation * (0.025f * Vector3.back));
                
            }
            else if (ss.ht.freeSwitch.activeSelf == true)
            {
                pose.position += (pose.rotation * ((4.0f * sideLength) * Vector3.right) - // right
                                  pose.rotation * ((sideLength * 1.4f) * Vector3.up) -
                                  //pose.rotation * ((starterHeight * .75f) * Vector3.forward)); // into wall
                                  pose.rotation * (0.13f * Vector3.forward));
            }
            
            gameObject.transform.SetPositionAndRotation(pose.position, pose.rotation);
            qrrl.grabLocation();
            ss.whatToDoObjectQ.SetActive(false);
            ss.whatToDoObjectF.SetActive(false);

            PositionAcquired?.Invoke(this, pose);
        }
    }
}