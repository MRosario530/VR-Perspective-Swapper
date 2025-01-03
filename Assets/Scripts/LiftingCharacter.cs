using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

public class LiftingCharacter : MonoBehaviour
{
    [SerializeField] Animator animator;
    public Transform[] barrels;
    public int currentBarrel;

    public SplineAnimate[] paths;
    public int currentPath;

    public Transform spine;
    private float timeToLift = 2f;

    public TMP_Text description;

    private string deliverBarrelText = "Current Objective:\r\nDeliver barrel to conveyor.";
    private string returnText = "Current Objective:\r\nRetrieve another barrel for conveyor.";



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentBarrel = 0;
        currentPath = 0;
        transform.position = new Vector3(54.197422f, 0, 9.42128754f);
        transform.rotation = new Quaternion(1.89311876e-07f, -0.00112978555f, -4.08058787e-09f, 0.999999404f);
    }

    public void StartLifting()
    {
        StartCoroutine(Lift());
    }

    private IEnumerator Lift()
    {
        yield return new WaitForSeconds(timeToLift);
        animator.SetTrigger("Lift");
    }

    // Animation functions.

    public void PickUpBarrel()
    {
        barrels[currentBarrel].parent = spine;
        description.SetText(deliverBarrelText);
    }

    public void DropBarrel()
    {
        barrels[currentBarrel].parent = null;
        Rigidbody rb = barrels[currentBarrel].AddComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        barrels[currentBarrel].GetComponent<CapsuleCollider>().enabled = true;
        barrels[currentBarrel].GetComponent<BarrelRotator>().StartRotation();
        currentBarrel++;
        timeToLift = 5f;
        StartMovement();
        description.SetText(returnText);
        if (currentBarrel < barrels.Length)
        {
            StartCoroutine(Lift());
        }
    }

    public void StartMovement()
    {
        if (currentPath < paths.Length)
        {
            paths[currentPath].Play();
            currentPath++;
        }
    }
}
