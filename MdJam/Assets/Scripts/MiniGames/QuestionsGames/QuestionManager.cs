using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public delegate void QuestionManagerEventHandler();
    public static event QuestionManagerEventHandler QuestionFinish;

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
    protected Question[] questionsList;

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
        foreach (Question qt in questionsList)
        {
            qt.gameObject.SetActive(false);
        }
    }

    public void Begin()
    {
        StartQuestions();
    }



    public void StartQuestions()
    {
        currentQuestion = 0;
        if (questionsList.Length == 0)
        {
            Debug.LogError("pas de questions pour le patient");
            return;
        }
        questionsList[0].gameObject.SetActive(true);
    }



    public void NextQuestion(AnswerState state)
    {
        switch (state)
        {
            case AnswerState.GoodAnswer:
                score++;
                break;
            default:
                //TODO : lancer une ligne de dialogue pour corriger et donner la bonne reponse
                break;
        }

        currentQuestion++;
        questionsList[currentQuestion - 1].gameObject.SetActive(false);
        if (currentQuestion == questionsList.Length)
        {
            switch (StateMachine.Instance.CurrentState)
            {
                case State.QuestionPatient:
                    StatManager.Instance.UpdateScoreQuestionAdulte(score);
                    break;
                case State.QuestionMerePatient:
                    StatManager.Instance.UpdateScoreQuestionEnfant(score);
                    break;
                default:
                    break;
            }
            QuestionFinish?.Invoke();
            return;
        }
        questionsList[currentQuestion].gameObject.SetActive(true);
    }
}
