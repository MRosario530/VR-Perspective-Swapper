using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public Transform door;
    public Vector3 downPosition;
    public Vector3 upPosition;

    private void Start()
    {
        downPosition = door.localPosition;
        upPosition = door.localPosition + new Vector3(0, 3, 0);
    }

    private IEnumerator RaiseDoor()
    {
        while (Vector3.Distance(door.transform.localPosition, upPosition) > 0.1f) // Check if close enough
        {
            door.transform.localPosition = Vector3.MoveTowards(door.transform.localPosition, upPosition, 2 * Time.deltaTime);
            yield return null; // Wait for next frame

        }
    }

    private IEnumerator LowerDoor()
    {
        while (Vector3.Distance(door.transform.localPosition, downPosition) > 0.1f) // Check if close enough
        {
            door.transform.localPosition = Vector3.MoveTowards(door.transform.localPosition, downPosition, 2 * Time.deltaTime);
            yield return null; // Wait for next frame
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(RaiseDoor());
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(LowerDoor());
    }

}
