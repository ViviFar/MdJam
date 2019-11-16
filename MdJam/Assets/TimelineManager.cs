using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class TimelineManager : MonoBehaviour
{
    public void StartMiniGameChapter1()
    {
        PaperPleaseManager.Instance.BeginGame();
    }

}
