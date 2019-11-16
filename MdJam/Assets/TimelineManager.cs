using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineManager : MonoBehaviour
{
    [SerializeField]
    protected PlayableDirector director;

    private void Start()
    {
        PaperPleaseManager.MiniGameEnd += PaperPleaseManager_MiniGameEnd;
        QuestionManager.QuestionFinish += QuestionManager_QuestionFinish;
    }

    private void QuestionManager_QuestionFinish()
    {
        director.Play();
    }

    private void PaperPleaseManager_MiniGameEnd(PaperPleaseManager sender)
    {
        director.Play();
    }

    public void OnChapter1End()
    {
        StateMachine.Instance.SetNewState(State.QuestionPatient);
    }

    public void OnChapter2End()
    {
        StateMachine.Instance.SetNewState(State.QuestionMerePatient);
    }

    public void OnChapter3End()
    {
        StateMachine.Instance.SetNewState(State.ContinuationTraitement);
    }

    public void StartMiniGameChapter1()
    {
        director.Pause();
        PaperPleaseManager.Instance.BeginGame();
    }

    public void StartMiniGameChapter2()
    {
        director.Pause();
        QuestionManager.Instance.Begin();
    }

    public void StartMiniGameChapter3()
    {
        director.Pause();
        QuestionManager.Instance.Begin();
    }

    private void OnDestroy()
    {
        PaperPleaseManager.MiniGameEnd -= PaperPleaseManager_MiniGameEnd;
        QuestionManager.QuestionFinish -= QuestionManager_QuestionFinish;
    }

}
