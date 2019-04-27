namespace GoogleARCore.HelloAR
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Rendering;
    using GoogleARCore;
    using UnityEngine.UI;
    public class HelloARController : MonoBehaviour
    {
        public Text camPoseText;
        //public Text testText;
        public GameObject m_firstPersonCamera;
        public GameObject cameraTarget;   //SpherePointer
        private Vector3 m_prevARPosePosition;
        private bool trackingStarted = false;
        public void Start()
        {
            m_prevARPosePosition = Vector3.zero;
        }
        public void Update()
        {
            _QuitOnConnectionErrors();
            if (Session.Status != SessionStatus.Tracking)
            {
                trackingStarted = false;                      // if tracking lost or not initialized
                if(camPoseText!=null)
                    camPoseText.text = "Lost tracking, wait ...";
                const int LOST_TRACKING_SLEEP_TIMEOUT = 15;
                Screen.sleepTimeout = LOST_TRACKING_SLEEP_TIMEOUT;
                return;
            }
            else
            {
                // Clear camPoseText if no error
                //if(camPoseText != null)
                    //camPoseText.text = "CamPose: " + cameraTarget.transform.position;
                camPoseText.text = "" + cameraTarget.transform.position;

            }

                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Vector3 currentARPosition = Frame.Pose.position;
            if (!trackingStarted)
            {
                trackingStarted = true;
                m_prevARPosePosition = Frame.Pose.position;
            }
            //Remember the previous position so we can apply deltas
            Vector3 deltaPosition = currentARPosition - m_prevARPosePosition;
            m_prevARPosePosition = currentARPosition;
            if (cameraTarget != null)
            {
                // The initial forward vector of the sphere must be aligned with the initial camera direction in the XZ plane.
                // We apply translation only in the XZ plane.
                cameraTarget.transform.Translate(deltaPosition.x, 0.0f, deltaPosition.z);
                // Set the pose rotation to be used in the CameraFollow script
                //

                //m_firstPersonCamera.GetComponent<FollowTarget>().targetRot = Frame.Pose.rotation;
            }
        }
        private void _QuitOnConnectionErrors()
        {
            /*
            // Do not update if ARCore is not tracking.
            if (Session.ConnectionState == SessionConnectionState.DeviceNotSupported)
            {
                camPoseText.text = "This device does not support ARCore.";
                Application.Quit();
            }
            else if (Session.ConnectionState == SessionConnectionState.UserRejectedNeededPermission)
            {
                camPoseText.text = "Camera permission is needed to run this application.";
                Application.Quit();
            }
            else if (Session.ConnectionState == SessionConnectionState.ConnectToServiceFailed)
            {
                camPoseText.text = "ARCore encountered a problem connecting.  Please start the app again.";
                Application.Quit();
            }*/
        }
    }
}