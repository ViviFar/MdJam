using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum Speaker
{
    Narrator,
    Chercheur,
    Soignant,
    Maman,
    Fille,
}

public class Textbox : MonoBehaviour
{
    [SerializeField]
    protected TextAsset inkAsset;
    protected Story _inkStory;
    [SerializeField]
    protected Speaker speaker;

    [SerializeField]
    protected TextMeshProUGUI textbox;
    protected bool canContinue = true;
    [SerializeField] 
    protected RectTransform choice;
    [SerializeField] 
    protected GameObject buttonChoicePrefab;
    protected bool ischoice;

    void Awake()
    {
        _inkStory = new Story(inkAsset.text);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!ischoice)
            {
                NextText();
            }
        }
    }

    protected void NextText()
    {
        if (canContinue)
        {
            if (_inkStory.canContinue)
            {
                StartCoroutine(EnumText(_inkStory.Continue()));
            }
        }
    }

    protected IEnumerator EnumText(string text)
    {
        string str = text.Substring(0, 2);
        text = text.Remove(0, 3);
        if (str == "n:")
        {
            speaker = Speaker.Narrator;
        }
        else if (str == "c:")
        {
            speaker = Speaker.Chercheur;
        }
        else if (str == "f:")
        {
            speaker = Speaker.Fille;

        }
        else if (str == "m:")
        {
            speaker = Speaker.Maman;

        }
        else if (str == "s:") 
        { 
            speaker = Speaker.Soignant;
        }

        canContinue = false;
        textbox.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            textbox.text += text[i];
            yield return new WaitForSeconds(0.05f);
        }
        if (_inkStory.currentChoices.Count > 0)
        {
            ischoice = true;
            for (int i = 0; i < _inkStory.currentChoices.Count; ++i)
            {
                ChoiceButton button = Instantiate(buttonChoicePrefab, this.choice).GetComponent<ChoiceButton>();
                button.index = i;
                Choice choice = _inkStory.currentChoices[i];
                button.SetText(choice.text);
                Debug.Log("Choice " + (i + 1) + ". " + choice.text);
            }
        }
        canContinue = true;
    }

    public void GetChoice(int choice)
    {
        ischoice = false;
        _inkStory.ChooseChoiceIndex(choice);
        NextText();
        foreach (ChoiceButton button in FindObjectsOfType<ChoiceButton>())
        {
            Destroy(button.gameObject);
        }
    }
}
