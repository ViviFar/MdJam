using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    [SerializeField]
    protected Button answer1, answer2, answer3;

    [SerializeField]
    protected float baseTimer = 10;

    [SerializeField]
    protected Slider remainingTime;

    protected float timer;

    private void OnEnable()
    {
        timer = baseTimer;
        remainingTime.interactable = false;
        remainingTime.maxValue = baseTimer;
        remainingTime.value = baseTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
        }
        remainingTime.value = timer;
    }

    public void Answer(int score)
    {
        if (score > 0)
        {
            QuestionManager.Instance.NextQuestion(AnswerState.GoodAnswer);
        }
        else if (score < 0)
        {
            QuestionManager.Instance.NextQuestion(AnswerState.BadAnswer);
        }
        else
        {
            QuestionManager.Instance.NextQuestion(AnswerState.NeutralAnswer);
        }
    }
}
