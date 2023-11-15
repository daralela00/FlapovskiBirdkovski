using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogicScript : MonoBehaviour
{
    public TextMeshProUGUI HighScoreText;
    public GameObject confirmationMenu;
    public SettingsMenuLogic settingsMenuLogic;


    private void Start()
    {
        settingsMenuLogic = GameObject.FindGameObjectWithTag("SettingsMenu").GetComponent<SettingsMenuLogic>();
        HighScoreText.text = "High score: " + PlayerPrefs.GetInt("Highscore").ToString();
    }

    private void Update()
    {
        if (confirmationMenu.activeSelf)
        {
            settingsMenuLogic.backgroundMusic.Pause();
        }else
        {
            settingsMenuLogic.backgroundMusic.UnPause();
        }
    }

    public void resetHighScore()
    {
        PlayerPrefs.SetInt("Highscore", 0);
        HighScoreText.text = "High score: 0";
    }
    public void playGame()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
