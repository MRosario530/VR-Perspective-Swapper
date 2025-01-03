using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RetrieveFromBarrel : MonoBehaviour
{
    public GameObject radioactiveMaterialPrefab;
    public GameObject radioactiveMaterial;
    public Transform spawnPosition;
    public ThrowBarrel throwBarrel;

    public TMP_Text description;
    private string dropDescription = "Current Objective:\r\nDispose of the current barrel.";
    private string retrieveDescription = "Current Objective:\r\nRetrieve the radioactive material from the barrel.";

    public void SpawnMaterial()
    {
        radioactiveMaterial = Instantiate(radioactiveMaterialPrefab, spawnPosition);
    }

    public void DropObject()
    {
        radioactiveMaterial.transform.parent = null;
        radioactiveMaterial.GetComponent<Rigidbody>().useGravity = true;
        radioactiveMaterial.GetComponent<Collider>().isTrigger = false;
        description.SetText(dropDescription);
    }

    public void ThrowBarrel()
    {
        throwBarrel.ReleaseObject();
        description.SetText(retrieveDescription);

    }
}
