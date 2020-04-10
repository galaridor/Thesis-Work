using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    private float currentTime = 0f;

    private float startingTime = 0f;

    private float timer;

    public TextMeshProUGUI strikes;

    public TextMeshProUGUI timerText;

    private int minutes;
    private int seconds;

    private string niceTime = "";

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            GameObject theGM = GameObject.Find("GameManagerLevel01");
            GameManagerLevel01 gm = theGM.GetComponent<GameManagerLevel01>();
            startingTime = gm.levelOneTimeLeft;
            currentTime = startingTime;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            GameObject theGM = GameObject.Find("GameManagerLevel02");
            GameManagerLevel02 gm = theGM.GetComponent<GameManagerLevel02>();
            startingTime = gm.levelTwoTimeLeft;
            currentTime = startingTime;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            GameObject theGM = GameObject.Find("GameManagerLevel03");
            GameManagerLevel03 gm = theGM.GetComponent<GameManagerLevel03>();
            startingTime = gm.levelThreeTimeLeft;
            currentTime = startingTime;
        }
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        timer = currentTime;

        minutes = Mathf.FloorToInt(timer / 60F);
        seconds = Mathf.FloorToInt(timer - minutes * 60);
        niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        timerText.text = "TIME: " + niceTime;

        if (currentTime < 0)
        {
            currentTime = 0;
        }

        if(currentTime < 60 && currentTime > 0)
        {
            timerText.color = new Color32(255, 0, 0, 255);
        }

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            GameObject theGM = GameObject.Find("GameManagerLevel01");
            GameManagerLevel01 gm = theGM.GetComponent<GameManagerLevel01>();
            if (gm.levelOneStrikes > 0)
            {
                strikes.color = new Color32(255, 0, 0, 255);
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            GameObject theGM = GameObject.Find("GameManagerLevel02");
            GameManagerLevel02 gm = theGM.GetComponent<GameManagerLevel02>();
            if (gm.levelTwoStrikes > 0)
            {
                strikes.color = new Color32(255, 0, 0, 255);
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            GameObject theGM = GameObject.Find("GameManagerLevel03");
            GameManagerLevel03 gm = theGM.GetComponent<GameManagerLevel03>();
            if (gm.levelThreeStrikes > 0)
            {
                strikes.color = new Color32(255, 0, 0, 255);
            }
        }
    }
}