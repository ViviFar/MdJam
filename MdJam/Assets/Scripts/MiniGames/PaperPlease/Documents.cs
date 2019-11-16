using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Documents : MonoBehaviour
{
    public delegate void DocumentSelectorHandler(bool isSelected, Documents doc);
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

    [SerializeField]
    protected TextMeshProUGUI nameLabel;
    [SerializeField]
    protected TextMeshProUGUI descriptionLabel;
    [SerializeField]
    protected TextMeshProUGUI inclusionLabel;
    [SerializeField]
    protected TextMeshProUGUI exclusionLabel;

    public string docName;
    [SerializeField]
    protected string docDescription;
    [SerializeField]
    protected string docInclusion;
    [SerializeField]
    protected string docExclusion;

    protected float initialYPos;

    // Start is called before the first frame update
    private void Awake()
    {
        DoAction = DoActionVoid;
    }
    void Start()
    {
        Debug.Log("coucou");
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        initialYPos = transform.position.y;
    }

    protected void LateUpdate()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = new Vector3(rayPoint.x, initialYPos + 0.5f, rayPoint.z);
        }
    }

    public void SetDoc()
    {
        nameLabel.text = docName;
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
        transform.localPosition = Vector3.Lerp(transform.localPosition , target, 0.1f);
    }
    
    protected void DoActionVoid()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Validation"))
        {
            OnSelected?.Invoke(true,this);
            Destroy(gameObject);
        } else if (other.CompareTag("Negative"))
        {
            OnSelected?.Invoke(false, this);
            Destroy(gameObject);
        }
    }
}
