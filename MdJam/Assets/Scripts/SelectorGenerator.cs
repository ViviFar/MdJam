using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorGenerator : MonoBehaviour
{

    
    static public List<string> criteres = new List<string>();

    [SerializeField]
    protected string critere1;
    [SerializeField]
    protected string critere2;
    [SerializeField]
    protected string critere3;
    [SerializeField]
    protected string critere4;
    [SerializeField]
    protected string critere5;
    [SerializeField]
    protected string critere6;
    [SerializeField]
    protected string critere7;
    [SerializeField]
    protected string critere8;
    // Start is called before the first frame update
    void Start()
    {
        criteres.Clear();
        criteres.Add(critere1);
        criteres.Add(critere2);
        criteres.Add(critere3);
        criteres.Add(critere4);
        criteres.Add(critere5);
        criteres.Add(critere6);
        criteres.Add(critere7);
        criteres.Add(critere8);
    }

    public static string GenerateCritere(int numberOfCriteres)
    {
        string sentence = "";
        int index;
        for (int i = 0; i < numberOfCriteres; i++)
        {
            index = Random.Range(0, criteres.Count);
            sentence += "- " + criteres[index] + "\n";
        }
        return sentence;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
