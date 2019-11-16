using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    #region singleton
    private static QuestionManager instance;
    public static QuestionManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<QuestionManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "StateMachine";
                    instance = go.AddComponent<QuestionManager>();
                }
            }
            return instance;
        }
    }
    #endregion

    [SerializeField]
    protected Question[] questionsPourPatient;

    [SerializeField]
    protected State nextState;
    

    private int currentQuestion = 0;

    protected int score = 0;
    public int Score { get { return score; } }
    
    

    

    private void Start()
    {
        /*----------Pour l'instant, ReadCsv est trop chiant a adapter, a voir selon le temps restant-------------------------*/
        //questionsPourPatient = ReadCSV.Instance.QuestionsPatient;
        //questionsPourMereDePatient = ReadCSV.Instance.QuestionsMerePatient;
        
        Debug.Log("entering start function");
        foreach (Question qt in questionsPourPatient)
        {
            qt.gameObject.SetActive(false);
        }
        StartQuestions();
    }



    public void StartQuestions()
    {
        Debug.Log("enter startQuestionFunction");
        currentQuestion = 0;
            if (questionsPourPatient.Length == 0)
            {
                Debug.LogError("pas de questions pour le patient");
                return;
            }
            questionsPourPatient[0].gameObject.SetActive(true);
    }



    public void NextQuestion(AnswerState state)
    {
        switch (state)
        {
            case AnswerState.BadAnswer:
                score--;
                break;
            case AnswerState.GoodAnswer:
                score++;
                break;
            default:
                break;
        }

        currentQuestion++;
        questionsPourPatient[currentQuestion - 1].gameObject.SetActive(false);
        if (currentQuestion == questionsPourPatient.Length)
        {
            StateMachine.Instance.SetNewState(nextState);
            return;
        }
        questionsPourPatient[currentQuestion].gameObject.SetActive(true);
    }
}
