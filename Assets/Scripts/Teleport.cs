using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform player;
    public void TeleportUser(Transform locationToTP)
    {
        player.position = locationToTP.position;
    }
}
