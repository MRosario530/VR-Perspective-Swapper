using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadingManager : MonoBehaviour
{

    public LiftingCharacter character;

    private void OnTriggerEnter(Collider other)
    {
        character.StartLifting();
        gameObject.SetActive(false);
    }
}
