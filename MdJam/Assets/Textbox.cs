using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Cinemachine;

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
    [SerializeField]
    protected TextMeshProUGUI nameLabel;
    protected bool canContinue = true;
    [SerializeField] 
    protected RectTransform choice;
    [SerializeField] 
    protected GameObject buttonChoicePrefab;
    protected bool ischoice;

    [SerializeField]
    protected Animator SceneLab1Anim;
    [SerializeField]
    protected Animator TransitionAnim;
    protected float timeText = 0;
    [SerializeField]
    protected GameObject soignant;
    [SerializeField]
    protected Transform soignantPosition;
    void Awake()
    {
        _inkStory = new Story(inkAsset.text);
        _inkStory.BindExternalFunction("EnterSoignant", EnterSoignant);
        _inkStory.BindExternalFunction("LeaveSoignant", LeaveSoignant);
        _inkStory.BindExternalFunction("SetFontSize", (int size) => { SetFontSize(size);});
        _inkStory.BindExternalFunction("TextAlignment", (int size) => { SetAlignement(size);});
        _inkStory.BindExternalFunction("NextScene", (int scene) => { NextScene(scene); });
        _inkStory.BindExternalFunction("SetTransition", (int transition) => { SetTransition(transition); });
        _inkStory.BindExternalFunction("CritereDisappear", CritereDisappear);
        _inkStory.BindExternalFunction("CritereAppear", CritereAppear);
    }

    private void CritereAppear()
    {
        TransitionAnim.SetTrigger("CritereAppear");

    }

    private void CritereDisappear()
    {
        TransitionAnim.SetTrigger("CritereDisappear");
    }

    private void NextScene(int scene)
    {
        SceneLab1Anim.SetTrigger("Part" + scene);
    }

    protected string SetFontSize(int size)
    {
        textbox.fontSize = size;
        return "";
    }

    protected void SetTransition(int transition)
    {
        if (transition == 0)
        {
            TransitionAnim.SetTrigger("TransitionIn");

        }
        else
        {
            TransitionAnim.SetTrigger("TransitionOut");

        }
    }

    protected string SetAlignement(int alignement)
    {
        textbox.alignment = (TextAlignmentOptions)alignement;
        return "";
    }

    protected void EnterSoignant()
    {
        GameObject gameObject = Instantiate(soignant, soignantPosition);
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localPosition += transform.up* gameObject.GetComponent<Renderer>().bounds.size.y/2;
    }

    protected void LeaveSoignant()
    {
        SceneLab1Anim.SetTrigger("Part5");
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
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!canContinue)
            {
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
            nameLabel.text = "Narrateur";
        }
        else if (str == "c:")
        {
            speaker = Speaker.Chercheur;
            nameLabel.text = "Paul";
        }
        else if (str == "f:")
        {
            speaker = Speaker.Fille;
            nameLabel.text = "Emilie";

        }
        else if (str == "m:")
        {
            speaker = Speaker.Maman;
            nameLabel.text = "Stephanie";

        }
        else if (str == "s:") 
        { 
            speaker = Speaker.Soignant;
            nameLabel.text = "Jacqueline";
        }

        canContinue = false;
        textbox.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            textbox.text += text[i];
            yield return new WaitForSeconds(timeText);
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
        timeText = 0.001f;

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
