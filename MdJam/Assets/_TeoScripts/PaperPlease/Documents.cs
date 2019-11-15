using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Documents : MonoBehaviour
{
    protected Camera cam;
    protected bool dragging = false;
    protected float distance;
    protected Vector3 initialMousePos;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    protected void LateUpdate()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = new Vector3(rayPoint.x, transform.position.y,rayPoint.z);
        }
    }

    protected void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, cam.transform.position);
        dragging = true;
    }

    protected void OnMouseUp()
    {
        dragging = false;
    }
}
