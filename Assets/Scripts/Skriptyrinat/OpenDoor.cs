using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public GameObject[] Spawner;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Open()
    {
        if (gameObject.name == "First")
        {
            PlayerPrefs.SetInt("2", 1);
        }
        if (gameObject.name == "Second")
        {
            PlayerPrefs.SetInt("3", 1);
        }       
        gameObject.SetActive(false);
    }

    private void Update()
    {
        for (int i = 0; i < Spawner.Length; i++)
        {
            if (Spawner[i] == null)
            {
                Open();
            }
        }
    }
}
