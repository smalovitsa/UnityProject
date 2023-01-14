using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text bestTxt;
    private void Start()
    {
        HeroMovement.bestScore = PlayerPrefs.GetInt("BestScore");
        bestTxt.text = "Best Score: " + HeroMovement.bestScore;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
