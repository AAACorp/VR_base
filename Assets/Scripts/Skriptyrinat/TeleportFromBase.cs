using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportFromBase : MonoBehaviour
{
    public Transform BaseTeleport;
    public GameObject player;
    public int i = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")

        {
            switch (i)
            {
                case 0:
                    player.transform.position = BaseTeleport.position;
                    break;
                case 1:
                    if (PlayerPrefs.GetInt(i.ToString()) == 1)
                    {
                        player.transform.position = BaseTeleport.position;
                    }
                    break;
                case 2:
                    if (PlayerPrefs.GetInt(i.ToString()) == 1)
                    {
                        player.transform.position = BaseTeleport.position;
                    }
                    break;
               

            }
        }
    }
}
