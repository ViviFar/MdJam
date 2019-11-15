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
    protected Question[] questionsPourMereDePatient;

    private int currentQuestion = 0;

    protected int score = 0;
    public int Score { get { return score; } }

    //[SerializeField]
    //protected GameObject questionPrefab;
    

    

    private void Awake()
    {
        /*----------Pour l'instant, ReadCsv est trop chiant a adapter, a voir selon le temps restant-------------------------*/
        //questionsPourPatient = ReadCSV.Instance.QuestionsPatient;
        //questionsPourMereDePatient = ReadCSV.Instance.QuestionsMerePatient;

        foreach(Question qt in questionsPourPatient)
        {
            qt.gameObject.SetActive(false);
        }
        foreach (Question qt in questionsPourMereDePatient)
        {
            qt.gameObject.SetActive(false);
        }
    }

    public void StartQuestions()
    {
        currentQuestion = 0;
        if(StateMachine.Instance.CurrentState == State.QuestionPatient)
        {
            if (questionsPourPatient.Length == 0)
            {
                Debug.LogError("pas de questions pour le patient");
                return;
            }
            questionsPourPatient[0].gameObject.SetActive(true);
        }
        else if (StateMachine.Instance.CurrentState == State.QuestionMerePatient)
        {
            if (questionsPourMereDePatient.Length == 0)
            {
                Debug.LogError("pas de questions pour la mere du patient");
                return;
            }
            questionsPourMereDePatient[0].gameObject.SetActive(true);
        }
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
        if (StateMachine.Instance.CurrentState == State.QuestionPatient)
        {
            questionsPourPatient[currentQuestion - 1].gameObject.SetActive(false);
            if (currentQuestion == questionsPourPatient.Length)
            {
                StateMachine.Instance.SetNewState(State.QuestionMerePatient);
                return;
            }
            questionsPourPatient[currentQuestion].gameObject.SetActive(true);
        }
        else if (StateMachine.Instance.CurrentState == State.QuestionMerePatient)
        {
            questionsPourMereDePatient[currentQuestion - 1].gameObject.SetActive(false);
            if (currentQuestion == questionsPourMereDePatient.Length)
            {
                StateMachine.Instance.SetNewState(State.ContinuationTraitement);
                return;
            }
            questionsPourMereDePatient[currentQuestion].gameObject.SetActive(true);
        }
    }
}
