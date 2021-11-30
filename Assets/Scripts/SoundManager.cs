using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static SoundManager soundManager;

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
            soundManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayEffect(string idEffect)
    {
        switch (idEffect)
        {
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
}
