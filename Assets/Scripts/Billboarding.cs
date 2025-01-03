using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboarding : MonoBehaviour
{
    // Reference to the camera (user).
    public Camera userCamera;

    public GameObject image;

    // Distance at which the object is considered visible.
    public float visibilityDistance;

    public float detectionAngle = 70f;


    void Start()
    {
        // If no camera is assigned, use the main camera.
        if (userCamera == null)
        {
            userCamera = Camera.main;
        }
    }

    void Update()
    {
        if (userCamera != null)
        {
            // Calculate direction to the camera.
            Vector3 direction = userCamera.transform.position - transform.position;

            // Determine if the object is within the visibility distance and in front of the camera.
            float distance = direction.magnitude;
            Vector3 directionNormalized = direction.normalized;

            float angleToCamera = Vector3.Angle(userCamera.transform.forward, -directionNormalized);

            bool isVisible = distance <= visibilityDistance && angleToCamera <= detectionAngle / 2;

            // Enable or disable the object based on visibility.
            image.SetActive(isVisible);

            if (isVisible)
            {
                // Make the object face the camera.
                direction.y = 0; // Optional: Keep the object upright, ignore vertical rotation.
                transform.rotation = Quaternion.LookRotation(-direction);
            }
        }
    }
}
