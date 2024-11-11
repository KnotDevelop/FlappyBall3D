using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target to follow
    public float smoothSpeed = 0.125f; // The smoothness of the camera movement
    public Vector3 offset; // The offset from the target's position

    void LateUpdate()
    {
        if (target != null)
        {
            // Get the desired position for the camera
            Vector3 desiredPosition = target.position + offset;

            // Set the desired position's Y and Z coordinates to the camera's current position
            desiredPosition.y = transform.position.y;
            desiredPosition.z = transform.position.z;

            // Smoothly move the camera towards the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime * TimeManager.instance.GetTimeScale());
            transform.position = smoothedPosition;
        }
    }
}
