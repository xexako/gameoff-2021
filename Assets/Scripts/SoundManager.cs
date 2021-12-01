using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    static SoundManager soundManager;
   
    public AudioSource menu;
    public AudioSource loop;
    public AudioSource button;
    public AudioSource victory;
    public AudioSource defeat;

    private void Awake()
    {
        if (soundManager)
        {
            Destroy(gameObject);
        }
        else
        {
            InitManager();
        }
    }

    public void InitManager() {
        soundManager = this;
        DontDestroyOnLoad(gameObject);
        CheckCurrentTheme();
    }

    private void Update()
    {
        CheckCurrentTheme();
    }

    public void PlayEffect(string idEffect)
    {
        switch (idEffect)
        {
            case "MENU":
                menu.Play();
                break;
            case "LOOP":
                loop.Play();
                break;
            case "BUTTON":
                button.Play();
                break;
            case "VICTORY":
                victory.Play();
                break;
            case "DEFEAT":
                defeat.Play();
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    private void CheckCurrentTheme() {
        if (SceneManager.GetActiveScene().name == "MainMenuScene")
        {
            if (!menu.isPlaying)
            {
                loop.Stop();
                menu.Play();
            }
        }
        else
        {
            if (!loop.isPlaying)
            {
                loop.Play();
                menu.Stop();
            }
        }
    }
}
