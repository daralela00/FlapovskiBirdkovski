using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenLogic : MonoBehaviour
{
    public string sceneName;
    public Text highscoreText;

    private void Start()
    {
        highscoreText.text = "High Score: " + PlayerPrefs.GetInt("Highscore").ToString();
    }
    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void resetHighScore()
    {
        PlayerPrefs.SetInt("Highscore", 0);
        highscoreText.text = "High Score: 0";
    }
}
