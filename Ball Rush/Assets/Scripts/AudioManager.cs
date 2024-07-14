using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // public GameObject soundControlButton;
    // public Sprite audioOffSprite;
    // public Sprite audioOnSprite;

    // Start is called before the first frame update
    void Start()
    {//below if else me
        // if(AudioSource.Pause==true)
        // {
        //     soundControlButton.GetComponent<Image>().Sprite = audioOffSprite;
        // }
        // else
        // {
        //     soundControlButton.GetComponent<Image>().Sprite = audioOnSprite;
        // }

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }

    }

    public void PlaySound(string name)
    {
        foreach(Sound s in sounds)
        {
            if(s.name == name)
                s.source.Play();
        }
    }

    public void StopSound(string name)
    {
        foreach(Sound s in sounds)
        {
            if(s.name == name)
                s.source.Pause();
        }
    }

    public void ResumeSound(string name)
    {
        foreach(Sound s in sounds)
        {
            if(s.name == name)
                s.source.UnPause();
        }
    }

    public void StopAll(string name)
    {
        foreach(Sound s in sounds)
        {
            if(s.name == name)
                s.source.Stop();
        }
    }

    public void Mute(string name)
    {
        foreach(Sound s in sounds)
        {
            if(s.name == name)
                s.source.Stop();
        }
    }

}
