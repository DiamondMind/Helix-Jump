using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] private Text txtScore;
    [SerializeField] private Text txtBest;
    [SerializeField] private Text txtGameMode;
    [SerializeField] private Text txtTime;

    private bool showTime;

    private void Start()
    {
    }
    void Update()
    {
        txtBest.text = "Best: " + GameManager.singleton.best;
        txtScore.text = "Score: " + GameManager.singleton.score;

        showTime = GameManager.singleton.isTimeRunning;

        if (showTime)
        {
            txtGameMode.text = "Game Mode: Time Limit";

            txtTime.gameObject.SetActive(true);
            txtTime.text = "Time Left: " + Mathf.Round(GameManager.singleton.currentTimeLimit);
        }
        else
        {
            txtTime.gameObject.SetActive(false);
            txtGameMode.text = "Game Mode: Normal";
        }
    }

}
