using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPleaseManager : MonoBehaviour
{
    public delegate void PaperPleaseEventHandler(PaperPleaseManager sender);
    static public event PaperPleaseEventHandler MiniGameEnd;
    [SerializeField]
    protected GameObject documentPrefab;
    protected int index;
    [SerializeField]
    protected int docMax;
    [SerializeField]
    protected List<string> docs = new List<string>();
    protected static PaperPleaseManager instance;
    public static PaperPleaseManager Instance { get { return instance; } }
    #region singleton
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
    #endregion


    void Start()
    {
        Documents.OnSelected += Documents_OnSelected;
        

    }

    public void BeginGame()
    {
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
        } else
        {
            MiniGameEnd?.Invoke(this);
        }
    }

    protected void SpawnPrefab()
    {
        index++;
        GameObject document = Instantiate(documentPrefab, transform);
        Documents doc = document.GetComponent<Documents>();
        document.transform.localPosition += Vector3.forward * 20;
        doc.docName = NameSave.GetName((Name)index - 1);
        //doc.docInclusion = SelectorGenerator.GenerateCritere(4);
        doc.SetDoc();
        doc.target = Vector3.zero;
        doc.SetGotoTarget();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
