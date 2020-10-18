using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenusManager : MonoBehaviour
{
    public static bool isPaused = false;
    public Text killScoreObject;

    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject pauseBtn;

    public void pause ()
    {
        pausePanel.SetActive(true);
        pauseBtn.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void resume ()
    {
        pausePanel.SetActive(false);
        pauseBtn.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void quit ()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void gameOver ()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        killScoreObject.text = "YOUR SCORE: " + GameStateManager.killScore;
    }

    public void playAgain()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("GamePlay");
    }
}
