using UnityEngine;
using System.Collections;
// Attach this script to the camera that you want to follow the target
public class FollowTarget : MonoBehaviour
{
    public Transform targetToFollow;
    public Quaternion targetRot;                      // The rotation of the device camera from Frame.Pose.rotation    
    public float distanceToTargetXZ = 10.0f;    // The distance in the XZ plane to the target
    public float heightOverTarget = 5.0f;
    public float heightSmoothingSpeed = 2.0f;
    public float rotationSmoothingSpeed = 2.0f;
    // Use lateUpdate to assure that the camera is updated after the target has been updated.


    void LateUpdate()
    {
        if (!targetToFollow)
            return;
        Vector3 targetEulerAngles = targetRot.eulerAngles;
        // Calculate the current rotation angle around the Y axis we want to apply to the camera.
        // We add 180 degrees as the device camera points to the negative Z direction
        float rotationToApplyAroundY = targetEulerAngles.y + 180.0f;
        float heightToApply = targetToFollow.position.y + heightOverTarget;
        // Smooth interpolation between current camera rotation angle and the rotation angle we want to apply.
        // Use LerpAngle to handle correctly when angles > 360
        float newCamRotAngleY = Mathf.LerpAngle(transform.eulerAngles.y, rotationToApplyAroundY, rotationSmoothingSpeed * Time.deltaTime);
        float newCamHeight = Mathf.Lerp(transform.position.y, heightToApply, heightSmoothingSpeed * Time.deltaTime);
        Quaternion newCamRotYQuat = Quaternion.Euler(0, newCamRotAngleY, 0);
        // Set camera position the same as the target position
        transform.position = targetToFollow.position;
        // Move the camera back in the direction defined by newCamRotYQuat and the amount defined by distanceToTargetXZ
        transform.position -= newCamRotYQuat * Vector3.forward * distanceToTargetXZ;
        // Finally set the camera height
        transform.position = new Vector3(transform.position.x, newCamHeight, transform.position.z);
        // Keep the camera looking to the target to apply rotation around X axis
        transform.LookAt(targetToFollow);
    }
}