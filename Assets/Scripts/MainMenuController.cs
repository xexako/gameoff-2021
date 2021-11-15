using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadLevel(int idLevel)
    {
        SceneManager.LoadScene(idLevel);
    }
}
