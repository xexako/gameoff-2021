using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject gameOverPanel;

    private void Start()
    {
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePausePanel();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadLevel(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void DisplayPausePanel(bool display) {
        pausePanel.SetActive(display);
    }

    public void DisplayGameOverPanel(bool display)
    {
        gameOverPanel.SetActive(display);
    }

    public void LoadLevel(int levelId)
    {
        SceneManager.LoadScene(levelId);
    }

    public void TogglePausePanel()
    {
        Time.timeScale = CalculateScale(true);
        DisplayPausePanel(!pausePanel.activeSelf);
    }

    public void ToggleGameOverPanel()
    {
        Time.timeScale = CalculateScale(false);
        DisplayGameOverPanel(!gameOverPanel.activeSelf);
    }

    private int CalculateScale(bool togglePausePanel)
    {
        return (togglePausePanel && pausePanel.activeSelf && !gameOverPanel.activeSelf)
            || (!togglePausePanel && !pausePanel.activeSelf && gameOverPanel.activeSelf) ? 1 : 0;
    }
}
