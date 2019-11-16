using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Name
{
    Benjamin,
    Charles,
    Sophie,
    Florence,
    Alice,
    Chloe,
    Emilie,
    Robert,
    Nathan,
    Thomas,
    Julien,
    Adele,
    Eve,
    Jean
}

enum LastName
{
    Nelson,
    Russell,
    Barreau,
    Escudero,
    Levesque,
    Lacombe,
    Clement,
    Dufour,
    Poto,
    Diaz,
    Noah,
    Larousse,
    Williams,
    Neymar
}

public class NameSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static string GetNameImage(Name name)
    {
        Debug.Log(name.ToString());
        return "";
    }
    public static string GetName(Name name)
    {
        return name.ToString() + " " + (LastName)name;
    }

    public static string GetNameDescription(Name name)
    {
        return "";

    }

    public static string GetNameInclusion(Name name)
    {
        return "";

    }

    public static string GetNameExclusion(Name name)
    {
        return "";
    }
}
