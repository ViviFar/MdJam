using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPleaseManager : MonoBehaviour
{

    [SerializeField]
    protected GameObject documentPrefab;
    protected int index;
    [SerializeField]
    protected int docMax; 
    // Start is called before the first frame update
    void Start()
    {
        Documents.OnSelected += Documents_OnSelected;
        SpawnPrefab();
    }

    private void Documents_OnSelected(bool isSelected)
    {
        if (isSelected)
        {
            Debug.Log("Selectionner");
        } else
        {
            Debug.Log("NonSelectionner");
        }
        if (index < 14)
        {
            SpawnPrefab();
        }
    }

    protected void SpawnPrefab()
    {
        index++;
        GameObject document = Instantiate(documentPrefab);
        Documents doc = document.GetComponent<Documents>();
        document.transform.position += Vector3.forward * 20;
        doc.target = Vector3.zero;
        doc.SetGotoTarget();
    }

    protected void GoToPoint(Transform objectTransform, Vector3 finalPos)
    {

    } 

    // Update is called once per frame
    void Update()
    {

    }
}
