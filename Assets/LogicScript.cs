using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using Unity.IO.LowLevel.Unsafe;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    public AudioSource airWhooshSound;
    public BirdScript bird;
    public TextMeshProUGUI highscoreText;
    public static bool gameIsPaused = false;
    public GameObject pauseMenu;

    private void Start()
    {
        airWhooshSound = GetComponent<AudioSource>();

        highscoreText.text = "High Score: " + PlayerPrefs.GetInt("Highscore").ToString();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        if (gameOverScreen.activeSelf)
        {
            return;
        }
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void addScore()
    {
        playerScore += 1;
        scoreText.text = playerScore.ToString();
        airWhooshSound.Play();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);

        int highscore = PlayerPrefs.GetInt("Highscore");
        if (playerScore > highscore)
        {
            PlayerPrefs.SetInt("Highscore", playerScore);
        }

        highscoreText.text = "High Score: " + PlayerPrefs.GetInt("Highscore").ToString();
    }

    public void quitToTittleScreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
