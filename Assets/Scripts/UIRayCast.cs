using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRayCast : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject StartPos, EndPos;
    LineRenderer LineRenderer;
    public VRInputModule vRInputModule;
    float Lenght = 5;
    void Start()
    {

    }
    private RaycastHit CreateRaycast(float lenght)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, Lenght);
        return hit;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
