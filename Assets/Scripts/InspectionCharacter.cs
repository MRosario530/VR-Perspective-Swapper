using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionCharacter : MonoBehaviour
{
    private Animator animator;
    public GameObject element;

    public Transform hand;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartInspect(GameObject currentElement)
    {
        animator.SetTrigger("Inspect");
        element = currentElement;
    }

    public void AttachElement()
    {
        element.transform.parent = hand;
        element.GetComponent<Rigidbody>().useGravity = false;
    }

    public void DropElement()
    {
        element.transform.parent = null;
        element.GetComponent<Rigidbody>().useGravity = true;
        Vector3 leftwardForce = Vector3.left * 5f;
        element.GetComponent<Rigidbody>().AddForce(leftwardForce, ForceMode.Impulse); // ForceMode.Impulse applies an instant force

    }
}
