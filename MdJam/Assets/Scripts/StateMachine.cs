using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum State
{
    Menu,
    LaunchingGame,
    ChapterSelection,
    HistoireStats,
    ExitGame,
    Paper,
    QuestionPatient,
    QuestionMerePatient,
    ContinuationTraitement,
    BilanFinJeu
}

public class StateMachine : MonoBehaviour
{
    #region singleton
    private static StateMachine instance;
    public static StateMachine Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<StateMachine>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "StateMachine";
                    instance = go.AddComponent<StateMachine>();
                }
            }
            return instance;
        }
    }
    #endregion

    #region fields
    [SerializeField]
    protected State currentState = State.Menu;
    public State CurrentState
    {
        get { return currentState; }
    }
    
    #endregion

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        onMenuEnterState();
    }


    /// <summary>
    /// Fonction pour changer l'etat actuel de la state machine. Appelé par les boutons du menus ou les interactions en jeu
    /// </summary>
    /// <param name="newState">Nouvel etat de la state machine</param>
    public void SetNewState(State newState)
    {
        if(newState != currentState)
        {
            currentState = newState;
            switch (currentState) //TODO : lancer les affichages correspondants
            {
                case State.Menu:    //afficher les boutons du menu
                    onMenuEnterState();
                    break;
                case State.LaunchingGame:   //charger la nouvelle scene
                    onLaunchingGameEnterState();
                    break;
                case State.ChapterSelection: //Montrer les differents chapitres, charger le correspondant
                    onChapterSelectionEnterState();
                    break;
                case State.HistoireStats: //les résultats en local. Possibilité de les effacer
                    onHistoireStatEnterState();
                    break;
                case State.ExitGame: //quitter l'application
                    onExitGameEnterState();
                    break;
                case State.Paper: // premier chapitre du jeu
                    onPaperEnterState();
                    break;
                case State.QuestionPatient: // Second chapitre du jeu
                    onQuestionPatientEnterState();
                    break;
                case State.QuestionMerePatient: //troisieme chapitre du jeu
                    onQuestionMereEnterState();
                    break;
                case State.ContinuationTraitement: // quatrieme chapitre du jeu
                    onContinuationTraitementEnterState();
                    break;
                case State.BilanFinJeu: //Comparaison des stats du joueur avec l'historique
                    onBilanFinJeuEnterState();
                    break;
                default: //normalement non appele mais place par securite
                    break;
            }
        }
    }


    #region enterStateFunction
    protected void onMenuEnterState()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        //SetNewState(State.QuestionPatient);
    }
    protected void onLaunchingGameEnterState()
    {
        SceneManager.LoadScene("Chapter1");
    }
    protected void onChapterSelectionEnterState()
    {
        //Launch Chapter Selection Menu
        //Update : gere en interne dans le script MainMenu
    }
    protected void onHistoireStatEnterState()
    {
        //Launch Stat Menu
        //Update : gere en interne dans le script MainMenu
    }
    protected void onExitGameEnterState()
    {
        //Exit Game
        Application.Quit();
    }
    protected void onPaperEnterState()
    {
        SceneManager.LoadScene("Chapter1");
    }
    protected void onQuestionPatientEnterState()
    {
        //Launch "Question Patient Mini Game" Mini Game
        Debug.Log("QuestionPatient");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Chapter2");
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += onQuestionSceneLoaded;
    }



    protected void onQuestionMereEnterState()
    {
        //Launch "Question Mother Mini Game" Mini Game
        UnityEngine.SceneManagement.SceneManager.LoadScene("Chapter3");
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += onQuestionSceneLoaded;
    }
    protected void onContinuationTraitementEnterState()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Chapter4");

    }
    protected void onBilanFinJeuEnterState()
    {
        //Launch End Game
    }
    #endregion

    #region sceneLoadedCallbacks
    private void onQuestionSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= onQuestionSceneLoaded;
    }
    #endregion
}
