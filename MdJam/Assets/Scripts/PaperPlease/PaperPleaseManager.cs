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
    [SerializeField]
    protected List<string> docs = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        Documents.OnSelected += Documents_OnSelected;
        SpawnPrefab();
    }

    private void Documents_OnSelected(bool isSelected, Documents doc)
    {
        if (isSelected)
        {
            Debug.Log("Selectionner");
            docs.Add(doc.docName);
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

    // Update is called once per frame
    void Update()
    {

    }
}
