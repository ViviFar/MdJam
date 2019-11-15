using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnswerState
{
    GoodAnswer,
    NeutralAnswer,
    BadAnswer
}

public class Answer : MonoBehaviour
{
    [SerializeField]
    protected AnswerState state;

    public AnswerState State { get { return state; } }
}
