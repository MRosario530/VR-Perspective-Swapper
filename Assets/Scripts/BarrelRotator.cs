using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRotator : MonoBehaviour
{
    public float duration = 1.0f; // Time in seconds for the rotation

    private Quaternion targetRotation;

    void Start()
    {
        // Set the target rotation to upright
        targetRotation = Quaternion.Euler(0, 0, 0);
    }

    public void StartRotation()
    {
        float y = transform.rotation.y;
        targetRotation = Quaternion.Euler(0, y, 0);
        StartCoroutine(RotateToTarget());
    }

    private IEnumerator RotateToTarget()
    {
        Quaternion startRotation = transform.rotation; // Save the current rotation
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / duration;
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, progress);
            yield return null; // Wait for the next frame
        }

        // Ensure the final rotation is exact
        transform.rotation = targetRotation;
    }
}
