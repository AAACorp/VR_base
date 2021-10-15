using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    PlayerStats player;
    void PickUpArmour(int value)
    {
        player.Armour += value;
    }
}

