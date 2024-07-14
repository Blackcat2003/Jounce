using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    
    public Text scoreText;
    public static int myScore = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = myScore.ToString();
    }

    public void AddScore(int score){
        myScore = myScore + score;
    }

    public static void ResetScore()
    {
        myScore = 0;
    }

}
