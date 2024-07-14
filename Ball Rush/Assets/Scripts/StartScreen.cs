using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public static StartScreen StartScreenInstance;
    public bool GameState;
    public GameObject StartElement;
    // Start is called before the first frame update
    void Start()
    {
        GameState = false;
        StartScreenInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        GameState = true;
        StartElement.SetActive(false);
    }
}
