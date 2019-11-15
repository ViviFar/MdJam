using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Documents : MonoBehaviour
{
    public delegate void DocumentSelectorHandler(bool isSelected);
    public static event DocumentSelectorHandler OnSelected;

    protected Camera cam;
    protected bool dragging = false;
    protected float distance;
    protected Vector3 initialMousePos;
    [HideInInspector]
    public Rigidbody rb;
    protected Action DoAction;
    [HideInInspector]
    public Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("coucou");
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    protected void LateUpdate()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = new Vector3(rayPoint.x, 1,rayPoint.z);
        }
    }

    protected void OnMouseDown()
    {
        SetVoid();
        distance = Vector3.Distance(transform.position, cam.transform.position);
        dragging = true;
        rb.isKinematic = true;
    }

    protected void OnMouseUp()
    {
        dragging = false;
        rb.isKinematic = false;
    }

    protected void Update()
    {
        DoAction();
    }

    public void SetGotoTarget()
    {
        DoAction = DoGoToTarget;
    }
    public void SetVoid()
    {
        DoAction = DoActionVoid;
    }

    protected void DoGoToTarget()
    {
        transform.position = Vector3.Lerp(transform.position, target, 0.1f);
    }
    
    protected void DoActionVoid()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Validation"))
        {
            OnSelected?.Invoke(true);
            Destroy(gameObject);
        } else if (other.CompareTag("Negative"))
        {
            OnSelected?.Invoke(false);
            Destroy(gameObject);
        }

    }
}
