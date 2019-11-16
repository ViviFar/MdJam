using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoiceButton : MonoBehaviour
{
    public int index;
    protected Button button;
    [SerializeField]
    protected TextMeshProUGUI textLabel;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Click);
    }

    public void SetText(string text)
    {
        textLabel.text = text;
    }

    private void Click()
    {
        Debug.Log(index);
        FindObjectOfType<Textbox>().GetChoice(index);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        button.onClick.RemoveAllListeners();

    }
}
