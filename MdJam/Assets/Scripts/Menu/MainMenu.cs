using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Boutons de l'ecran principal")]
    [SerializeField]
    protected Button play;
    [SerializeField]
    protected Button chapter, historic, quit;
    [Header("Boutons de l'ecran de selection des chapitres")]
    [SerializeField]
    protected Button chapitre1;
    [SerializeField]
    protected Button chapitre2, chapitre3, chapitre4, chapterReturn;
    [Header("Boutons de l'ecran de l'historique de jeu")]
    [SerializeField]
    protected Button cleanData;
    [SerializeField]    
    protected Button analitycsReturn;

    [Header("les differents ecrans du menu")]
    [SerializeField]
    protected GameObject firstScreen;
    [SerializeField]
    protected GameObject chapterList, analytics;

    protected static MainMenu instance;
    public static MainMenu Instance { get { return instance; } }

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
    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(Play);
        chapter.onClick.AddListener(Chapter);
        historic.onClick.AddListener(Historic);
        quit.onClick.AddListener(Quit);
        chapitre1.onClick.AddListener(goToChapter1);
        chapitre2.onClick.AddListener(goToChapter2);
        chapitre3.onClick.AddListener(goToChapter3);
        chapitre4.onClick.AddListener(goToChapter4);
        chapterReturn.onClick.AddListener(backToMenu);
        analitycsReturn.onClick.AddListener(backToMenu);
        backToMenu();
    }

    #region fonctionDesBoutons
    private void Quit()
    {
        StateMachine.Instance.SetNewState(State.ExitGame);
    }

    private void Historic()
    {
        firstScreen.SetActive(false);
        chapterList.SetActive(false);
        analytics.SetActive(true);
        StateMachine.Instance.SetNewState(State.HistoireStats);
    }

    private void Chapter()
    {
        firstScreen.SetActive(false);
        chapterList.SetActive(true);
        analytics.SetActive(false);
        StateMachine.Instance.SetNewState(State.ChapterSelection);
    }

    private void Play()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        Debug.Log("launching game");
        StateMachine.Instance.SetNewState(State.LaunchingGame);
    }

    private void goToChapter1()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        Debug.Log("launching game at chapter 1");
        StateMachine.Instance.SetNewState(State.LaunchingGame);
    }
    private void goToChapter2()
    {
       // Debug.Log("launching game at chapter 2");
        StateMachine.Instance.SetNewState(State.QuestionPatient);
    }
    private void goToChapter3()
    {
        //Debug.Log("launching game at chapter 3");
        StateMachine.Instance.SetNewState(State.QuestionMerePatient);
    }
    private void goToChapter4()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        Debug.Log("launching game at chapter 4");
        StateMachine.Instance.SetNewState(State.ContinuationTraitement);
    }

    private void backToMenu()
    {
        firstScreen.SetActive(true);
        chapterList.SetActive(false);
        analytics.SetActive(false);
        StateMachine.Instance.SetNewState(State.Menu);
    }
    #endregion

    private void OnDestroy()
    {
        play.onClick.RemoveListener(Play);
        chapter.onClick.RemoveListener(Chapter);
        historic.onClick.RemoveListener(Historic);
        quit.onClick.RemoveListener(Quit);
        chapitre1.onClick.RemoveListener(goToChapter1);
        chapitre2.onClick.RemoveListener(goToChapter2);
        chapitre3.onClick.RemoveListener(goToChapter3);
        chapitre4.onClick.RemoveListener(goToChapter4);
        chapterReturn.onClick.RemoveListener(backToMenu);
        analitycsReturn.onClick.RemoveListener(backToMenu);
        if (this == instance) instance = null;
    }
}
