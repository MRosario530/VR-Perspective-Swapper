using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrievalCollider : MonoBehaviour
{
    public Animator retrievalAnimator;

    private void OnTriggerEnter(Collider other)
    {
        retrievalAnimator.SetTrigger("Retrieve");
    }
}
