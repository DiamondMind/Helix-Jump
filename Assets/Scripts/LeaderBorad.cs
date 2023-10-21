using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dan.Main;

public class LeaderBorad : MonoBehaviour
{
    [SerializeField] private List<Text> names;
    [SerializeField] private List<Text> scores;

    private string publicKey = "eb15179f653c4784f9581d32e0abb5b2a191bff60cb4cf98853c299f1b6615c4";

    private void Start()
    {
        GetLeaderBoard();
    }

    public void GetLeaderBoardd()
    {
        LeaderboardCreator.GetLeaderboard(publicKey, (msg) =>
        {
            for (int i = 0; i < names.Count - 1; i++)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        });

    }

    public void GetLeaderBoard()
    {
        LeaderboardCreator.GetLeaderboard(publicKey, (msg) =>
        {
            int count = Mathf.Min(names.Count, scores.Count, msg.Length); // Get the minimum count
            //int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;

            for (int i = 0; i < count; i++)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        });
    }


    public void SetLeaderBoardEntry(string userName, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicKey, userName, score, (msg) =>
        {
            userName.Substring(0, 4);
            GetLeaderBoard();
        });
    }

}
