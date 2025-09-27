using UnityEngine;
[System.Serializable]
public class User 
{
    public string userName;
    public int userScore;

    public User()
    {
        userName = PlayerScores.playerName;
        userScore = PlayerScores.playerScore;
    }
}
