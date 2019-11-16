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
    }

    private void PaperPleaseManager_MiniGameEnd(PaperPleaseManager sender)
    {
        director.Play();
    }

    public void OnChapter1End()
    {
        StateMachine.Instance.SetNewState(State.QuestionPatient);
    }

    public void StartMiniGameChapter1()
    {
        director.Pause();
        PaperPleaseManager.Instance.BeginGame();
    }

}
