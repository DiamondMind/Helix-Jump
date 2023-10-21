using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text inputScore;
    [SerializeField] private InputField inputName;
    public UnityEvent<string, int> submitScoreEvent;

    public void SubmitScore()
    {
        //submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
        submitScoreEvent.Invoke(inputName.text, GameManager.singleton.score);
    }
}
