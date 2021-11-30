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

    public Image winTitle, defeatTitle;

    private SoundManager sounds;

    private bool paused;

    private void Start()
    {
        pausePanel.SetActive(false);
        nextLevelButton.SetActive(false);
        gameOverPanel.SetActive(false);
        startPanel.SetActive(true);
        paused = true;
        Time.timeScale = 0;
        sounds = GameObject.Find("SoundManager").GetComponent<SoundManager>();
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

    public void DisplayPanelTitle(bool win)
    {
        winTitle.gameObject.SetActive(win);
        defeatTitle.gameObject.SetActive(!win);
    }

    public void LoadLevel(int levelId)
    {
        sounds.PlayEffect("BUTTON");
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

    public void ToggleGameOverPanel(bool win, string sound)
    {
        if (sound != null)
        {
            sounds.PlayEffect(sound);
        }
        Time.timeScale = 0;
        DisplayPausePanel(false);
        paused = CalculateScale(false);
        startPanel.SetActive(paused);
        DisplayGameOverPanel(!gameOverPanel.activeSelf);
        DisplayNextLevelButton(win);
        DisplayPanelTitle(win);
    }

    private bool CalculateScale(bool togglePausePanel)
    {
        return (togglePausePanel && pausePanel.activeSelf && !gameOverPanel.activeSelf)
            || (!togglePausePanel && !pausePanel.activeSelf && gameOverPanel.activeSelf);
    }
}
