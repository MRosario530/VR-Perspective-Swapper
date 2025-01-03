using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class InspectionCollider : MonoBehaviour
{
    public GameObject currentElement;
    public InspectionCharacter character;
    public Transform endPoint;
    public float timeToPosition;
    bool canInspect = true;

    private void OnTriggerEnter(Collider other)
    {
        if (canInspect)
        {
            currentElement = other.gameObject;
            StartCoroutine(MoveObject());
            StartCoroutine(Inspect());
            canInspect = false;
        }
    }

    private IEnumerator Inspect()
    {
        yield return new WaitForSeconds(2f);
        character.StartInspect(currentElement);
        yield return new WaitForSeconds(10f);
        canInspect = true;
    }

    private IEnumerator MoveObject()
    {
        Transform elementTransform = currentElement.transform;
        Transform startPoint = currentElement.transform;
        float elapsedTime = 0f;

        while (elapsedTime < timeToPosition)
        {
            elapsedTime += Time.deltaTime;

            // Calculate the interpolation factor (0 to 1)
            float t = elapsedTime / timeToPosition;

            // Interpolate position
            elementTransform.position = Vector3.Lerp(startPoint.position, endPoint.position, t);

            // Interpolate rotation
            elementTransform.rotation = Quaternion.Slerp(startPoint.rotation, endPoint.rotation, t);

            yield return null; // Wait for the next frame
        }

        // Ensure the object is exactly at the end position/rotation
        elementTransform.position = endPoint.position;
        elementTransform.rotation = endPoint.rotation;
    }
}
