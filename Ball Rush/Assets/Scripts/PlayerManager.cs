using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public GameObject pauseMenuScreen;
    public static bool isGameOver;
    public GameObject GameOverScreen;

    public static int numberOfStars;
    

    // void Start(){
    //     numberOfStars = 0;
    // }

    void Start()
    {
        LoadTotalStars(); // Load the total stars at the start of the game
    }

    //public GameObject starttext;     //me

    // //last try
    // private void Start()
    // {
    //     Time.timeScale = 0;
    // }

    // private void Update()
    // {
    //     if(input.touchCount>0)
    //     {
    //         Time.timeScale = 1;
    //     }
    // }

    private void Awake()
    {
        
        isGameOver = false;
    }

    void Update()
    {
        //Me start
        // if(Input.touchCount>0)
        // {
        //     Time.timeScale = 1;
        //     FindObjectOfType<AudioManager>().PlaySound("theme");
        //     Destroy(starttext);
        // }

        if(isGameOver)
        {
            GameOverScreen.SetActive(true);

            
            SaveTotalStars();
        }

    }

    private void LoadTotalStars()
    {
        numberOfStars = PlayerPrefs.GetInt("TotalStars", 0);
    }

    private void SaveTotalStars()
    {
        PlayerPrefs.SetInt("TotalStars", numberOfStars);
        PlayerPrefs.Save();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        FindObjectOfType<AudioManager>().StopSound("theme");
        pauseMenuScreen.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().ResumeSound("theme");
        pauseMenuScreen.SetActive(false);
    }

    public void Home()
    {
        Time.timeScale = 1f;
        Score.ResetScore();
        SceneManager.LoadScene(0);
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        Score.ResetScore();
        SceneManager.LoadScene(1);

        LoadTotalStars(); // Load the total stars when replaying
        
    }

//mee
    // public void Stopme()
    // {
    //     //Time.timeScale = 0f;
    //     FindObjectOfType<AudioManager>().StopAll("theme");
    //     //pauseMenuScreen.SetActive(true);
    // }

}