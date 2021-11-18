using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject nextLevelButton;
    public GameObject startPanel;

    private bool paused;

    private void Start()
    {
        pausePanel.SetActive(false);
        nextLevelButton.SetActive(false);
        gameOverPanel.SetActive(false);
        startPanel.SetActive(true);
        paused = true;
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePausePanel();
        }
        if (Input.GetButtonDown("Fire1") && paused)
        {
            ResumeGame();
        }
        /*
        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadLevel(SceneManager.GetActiveScene().buildIndex);
        }
        */
    }

    public void DisplayPausePanel(bool display) {
        pausePanel.SetActive(display);
    }

    public void DisplayGameOverPanel(bool display)
    {
        gameOverPanel.SetActive(display);
    }

    public void DisplayNextLevelButton(bool display)
    {
        nextLevelButton.SetActive(display);
    }

    public void LoadLevel(int levelId)
    {
        SceneManager.LoadScene(levelId);
    }
    
    public void ResumeGame()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }

    public void TogglePausePanel()
    {
        if (!gameOverPanel.activeSelf)
        {
            Time.timeScale = 0;
            paused = CalculateScale(true);
            startPanel.SetActive(paused);
            DisplayPausePanel(!pausePanel.activeSelf);
        }
    }

    public void ToggleGameOverPanel(bool win)
    {
        Time.timeScale = 0;
        DisplayPausePanel(false);
        paused = CalculateScale(false);
        startPanel.SetActive(paused);
        DisplayGameOverPanel(!gameOverPanel.activeSelf);
        DisplayNextLevelButton(win);
    }

    private bool CalculateScale(bool togglePausePanel)
    {
        return (togglePausePanel && pausePanel.activeSelf && !gameOverPanel.activeSelf)
            || (!togglePausePanel && !pausePanel.activeSelf && gameOverPanel.activeSelf);
    }
}
