using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum GameMode
    {
        Normal, TimeLimit
    }

    public static GameManager singleton;
    public int best;
    public int score;
    public int currentStage = 0;
    public float currentTimeLimit;
    public int timeLimit = 20;
    public bool isTimeRunning = false;
    public static List<BallController> ballControllers = new List<BallController>();
    private void Awake()
    {
        if (singleton == null)
            singleton = this;
        else if (singleton != this)
            Destroy(gameObject);

        // Load the saved highscore
        best = PlayerPrefs.GetInt("Highscore");
    }

    public static void RegisterBallController(BallController ballController)
    {
        ballControllers.Add(ballController);
    }

    private void Update()
    {

        if (isTimeRunning)
        {
            currentTimeLimit -= Time.deltaTime; // Decrease the time limit by the time elapsed since the last frame

            if (currentTimeLimit <= 0)
            {
                // Time's up, restart the level
                RestartLevel();
            }
        }
    }

    public void NextLevel()
    {
        currentStage++;
        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentStage);

        // Randomly select a new game mode for the next level.
        SetRandomGameMode();
    }

    public void RestartLevel()
    {
        // Show Ads Advertisement.Show();
        if(isTimeRunning)
        {
            currentTimeLimit = timeLimit;
        }
        else
        {
            currentTimeLimit = 9999;
        }
        Debug.Log("Restarting Level");
        singleton.score = 0;
        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentStage);
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;

        if (score > best)
        {
            PlayerPrefs.SetInt("Highscore", score);
            best = score;
        }
    }


    public void SetGameMode(int id)
    {
        if (id == 0)
        {
            currentTimeLimit = 9999;
            isTimeRunning = false;
        }
        else if (id == 1)
        {
            currentTimeLimit = timeLimit;
            isTimeRunning = true;

        }
    }

    public void SetRandomGameMode()
    {
        // Generate a random index between 0 and 1 (the number of available game modes).
        int randomIndex = Random.Range(0, 2);

        // Assign the selected game mode based on the random index.
        if (randomIndex == 0)
        {
            SetGameMode((int)GameMode.Normal);
        }
        else
        {
            SetGameMode((int)GameMode.TimeLimit);
        }
    }
}
