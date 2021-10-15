using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnBase : MonoBehaviour
{
    public Transform BaseTeleport;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Hand")
        {
            player.transform.position = BaseTeleport.position;
        }
    }

}
