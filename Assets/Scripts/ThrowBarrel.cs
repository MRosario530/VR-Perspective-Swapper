using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBarrel : MonoBehaviour
{
    private Rigidbody barrel;
    private void OnCollisionEnter(Collision collision)
    {
        barrel = collision.gameObject.GetComponent<Rigidbody>();
    }

    public void ReleaseObject()
    {
        barrel.AddForce(new Vector3(0, 10, 10), ForceMode.Impulse);
    }

}
