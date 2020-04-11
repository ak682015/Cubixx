using UnityEngine;
using UnityEngine.Audio;
using System;

public class AUdioManager : MonoBehaviour
{

    public static int music;
    public Sound[] sound;
    public GameObject on;
    public GameObject off;

    private void Awake()
    {
        music = PlayerPrefs.GetInt("music", 1);

        foreach (Sound s in sound)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;
            if (music == 1)
            {
                s.source.volume = 1;
                on.SetActive(true);
                off.SetActive(false);
            }
            else
            {
                s.source.volume = 0;
                on.SetActive(false);
                off.SetActive(true);
            }

        }
    }

    public void chngaemusic()
    {
        if (music == 1)
        {
            PlayerPrefs.SetInt("music", 0);
            music = PlayerPrefs.GetInt("music", 1);
        }
        else
        {
            PlayerPrefs.SetInt("music", 1);
            music = PlayerPrefs.GetInt("music", 1);
        }
       
    }


    public void Play(string name)
    {
        foreach (Sound s in sound)
        {
            if (music == 1)
            {
                s.source.volume = 1;
            }
            else
            {
                s.source.volume = 0;
            }
            if (s.name == name)
            {
                s.source.Play();
            }
        }
    }

}

