using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteMusic : MonoBehaviour
{
    private Sprite musicOnImage;
    public Sprite musicOffImage;
    public Button button;
    private bool isOn = true;

    // Start is called before the first frame update
    void Start()
    {
        musicOnImage = button.image.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked()
    {
        if(isOn)
        {
            button.image.sprite = musicOffImage;
            isOn = false;
            FindObjectOfType<AudioManager>().Mute("theme");
        }
        else
        {
            button.image.sprite = musicOnImage;
            isOn = true;
            FindObjectOfType<AudioManager>().PlaySound("theme");
        }
    }
}
