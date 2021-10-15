using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pointer : MonoBehaviour
{
    public float LenghtOfLine = 5f;
    GameObject StartPos, EndPos;
    public GameObject Sphere;
    public LineRenderer LineRenderer;
    public VRInputModule vRInputModule;

    float Lenght = 5;
    void Start()
    {
        LineRenderer = GetComponent<LineRenderer>();
    }
    public void UpdateLine()
    {
        PointerEventData data = vRInputModule.GetData();

        float targetLenght = data.pointerCurrentRaycast.distance == 0 ? LenghtOfLine : data.pointerCurrentRaycast.distance;
        //float targetLenght = LenghtOfLine;
        RaycastHit hit = CreateRaycast(targetLenght);

        Vector3 endPos = transform.position + (transform.forward * targetLenght);
        if (hit.collider != null)
        {
            endPos = hit.point;
        }
        Sphere.transform.position = endPos;
        //LineRenderer.SetPosition(0, transform.position);
        //LineRenderer.SetPosition(1, endPos);
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
        UpdateLine();
    }
}
