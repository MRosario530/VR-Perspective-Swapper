using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeigerCollider : MonoBehaviour
{
    public Animator geigerAnimator;
    public AudioSource geigerAudio;
    private void OnTriggerEnter(Collider other)
    {
        geigerAnimator.SetTrigger("Scan");
        geigerAudio.Play();
    }
}
