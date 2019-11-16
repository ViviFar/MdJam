using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    protected Button play;
    [SerializeField]
    protected Button chapter;
    [SerializeField]
    protected Button historic;
    [SerializeField]
    protected Button quit;

    private static MainMenu instance;
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
    }

    private void Quit()
    {
        StateMachine.Instance.SetNewState(State.ExitGame);
    }

    private void Historic()
    {
        StateMachine.Instance.SetNewState(State.HistoireStats);
    }

    private void Chapter()
    {
        StateMachine.Instance.SetNewState(State.ChapterSelection);
    }

    private void Play()
    {
        StateMachine.Instance.SetNewState(State.LaunchingGame);
    }

    private void OnDestroy()
    {
        play.onClick.RemoveListener(Play);
        chapter.onClick.RemoveListener(Chapter);
        historic.onClick.RemoveListener(Historic);
        quit.onClick.RemoveListener(Quit);
        if (this == instance) instance = null;
    }
}
