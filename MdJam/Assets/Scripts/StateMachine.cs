﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    protected State currentState = State.BilanFinJeu;
    public State CurrentState
    {
        get { return currentState; }
    }
    
    #endregion

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SetNewState(State.Menu);
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
        SetNewState(State.QuestionPatient);
    }
    protected void onLaunchingGameEnterState()
    {

    }
    protected void onChapterSelectionEnterState()
    {

    }
    protected void onHistoireStatEnterState()
    {

    }
    protected void onExitGameEnterState()
    {
        Application.Quit();
    }
    protected void onPaperEnterState()
    {

    }
    protected void onQuestionPatientEnterState()
    {
        QuestionManager.Instance.StartQuestions();
    }
    protected void onQuestionMereEnterState()
    {
        QuestionManager.Instance.StartQuestions();
    }
    protected void onContinuationTraitementEnterState()
    {

    }
    protected void onBilanFinJeuEnterState()
    {

    }


    #endregion
}
