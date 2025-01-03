using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.Splines;

public class LoaderEvent : MonoBehaviour
{
    public GameObject pallet;
    public GameObject loadingFork;
    public TMP_Text description;
    [SerializeField] private SplineAnimate splineToPallet;
    [SerializeField] private SplineAnimate splineToInside;

    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(RetrievePallet());
    }

    public void AttachPallet()
    {
        pallet.transform.parent = loadingFork.transform;
    }

    private IEnumerator RetrievePallet()
    {
        // Drive to retrieve pallet
        animator.SetTrigger("MoveForward");
        splineToPallet.Play();
        yield return new WaitForSeconds(5f);
        // Loading the pallet onto the fork
        animator.SetTrigger("Load");
        yield return new WaitForSeconds(7f);
        // Driving through the door
        description.SetText("Current Objective:\r\nDeliver pallet to conveyor.");
        animator.SetTrigger("MoveForward");
        splineToInside.Play();
        yield return new WaitForSeconds(10f);
        // Dropping the pallet inside
        animator.SetTrigger("Stop");
        pallet.transform.parent = null;
        pallet.GetComponent<Collider>().enabled = true;
        pallet.AddComponent<Rigidbody>();

    }
}
