using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static HeroMovement;
using static UnityEngine.Color;

public class DayNight : MonoBehaviour
{
    public GameObject blackBG, whiteBG, healthBar, menu;
    public float timeRemaining = 3f, timeRemainingN = 20f;
    private float nightTime = 20f;
    private static bool timerIsRunning;
    public static bool timerIsRunningN, forOpacity, DAY;
    private GameObject[] toDestroy;
    public Text timer, Score;
    private SpriteRenderer hpBar;


    private void Start()
    {
        hpBar = healthBar.GetComponent<SpriteRenderer>();
        timerIsRunning = true;
        DAY = true;
    }


    private void Update()
    {
        if (score >= 10 && score <= 40)
            nightTime = 15f;
        if (score >= 40 && score <= 70)
            nightTime = 10f;
        if (score >= 70 && score <= 100)
            nightTime = 10f;
        if (score >= 100)
            nightTime = 5f;

        timer.text = "00:" + Mathf.Round(timeRemainingN);
        Score.text = "Score: " + score;

        if (timerIsRunning)
            if (timeRemaining > 0)
                timeRemaining -= Time.deltaTime;
            else
            {
                whiteBG.SetActive(false);
                blackBG.SetActive(true);
                forOpacity = true;
                DAY = false;
                
                timeRemaining = 0;
                timerIsRunning = false;
                timerIsRunningN = true;
                timer.color = white;
                Score.color = white;
                hpBar.color = white;
            }

        if (!timerIsRunningN) return;
        if (timeRemainingN > 0)
            timeRemainingN -= Time.deltaTime;

        else
        {                
            timeRemainingN = 0;
            timerIsRunningN = false;
            HP = 0;
        }
    }

    public void NextButton()
    {
        toDestroy = GameObject.FindGameObjectsWithTag("Dark");
        foreach (var t in toDestroy) Destroy(t);
        
        spheresCollected = 0;
        SphereSpawner.readyToSpawn = true;
        forOpacity = false;
        DAY = true;
        timeRemaining = 5;
        timeRemainingN = nightTime;
        timerIsRunning = true;

        whiteBG.SetActive(true);
        blackBG.SetActive(false);
        timer.color = black;
        Score.color = black;
        hpBar.color = gray;
    }

    public void RestartButton()
    {
        score = 0;
        SphereSpawner.readyToSpawn = true;
        SceneManager.LoadScene(1);
        HP = 3;
        timerIsRunningN = false;

        spheresCollected = 0;
        forOpacity = false;
        DAY = true;
        timeRemaining = 5;
        timeRemainingN = nightTime;
        timerIsRunning = true;

        whiteBG.SetActive(true);
        blackBG.SetActive(false);
        timer.color = black;
        Score.color = black;
        hpBar.color = gray;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}

