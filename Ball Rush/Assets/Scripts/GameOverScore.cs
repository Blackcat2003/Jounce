using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameOverScore : MonoBehaviour
{
    public TMP_Text CurrentScoreText; // Use TMP_Text instead of Text
    public TMP_Text HighScoreText;
    public Text StarText;
    void Start()
    {
        // Retrieve the final score from PlayerPrefs
        int CurrentScore = PlayerPrefs.GetInt("FinalScore", 0);

        // Display the final score on the TextMeshPro element
        CurrentScoreText.text = "Score: " + CurrentScore.ToString();


        // int Stars=PlayerPrefs.GetInt("NumberOfStars",0);
        // StarText.text = Stars.ToString() ;

        int totalStars = PlayerPrefs.GetInt("TotalStars", 0);
        StarText.text = totalStars.ToString();


        // Call HighScoreUpdate function to update and display high score
        HighScoreUpdate(CurrentScore);
    }

    void HighScoreUpdate(int CurrentScore)
    {
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            int savedHighScore = PlayerPrefs.GetInt("SavedHighScore");

            if (CurrentScore > savedHighScore)
            {
                // set a new high score
                PlayerPrefs.SetInt("SavedHighScore", CurrentScore);
            }
        }
        else
        {
            // if there is no high score set it
            PlayerPrefs.SetInt("SavedHighScore", CurrentScore);
        }

        // Update TMP directly
        HighScoreText.text = "High Score: " + PlayerPrefs.GetInt("SavedHighScore").ToString();
    }

}