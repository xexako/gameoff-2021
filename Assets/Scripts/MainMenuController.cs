using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    private SoundManager sounds;

    private void Start()
    {
        Time.timeScale = 1;
        sounds = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    public void Exit()
    {
        sounds.PlayEffect("BUTTON");
        Application.Quit();
    }

    public void LoadLevel(int idLevel)
    {
        sounds.PlayEffect("BUTTON");
        SceneManager.LoadScene(idLevel);
    }
}
