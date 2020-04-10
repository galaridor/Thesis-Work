using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MainMenu : MonoBehaviour
{
    public AudioSource backgroundAudio;

    private float levelOneFinalTime;
    private float levelTwoFinalTime;
    private float levelThreeFinalTime;

    private float levelOneBestTime;
    private float levelTwoBestTime;
    private float levelThreeBestTime;

    private string isLevelOnePassed;
    private string isLevelTwoPassed;
    private string isLevelThreePassed;

    public GameObject Level01;
    public GameObject Level02;
    public GameObject Level03;

    public GameObject HintButtonLevel01;
    public GameObject HintButtonLevel02;
    public GameObject HintButtonLevel03;

    public GameObject PadLcokLevel01;
    public GameObject PadLcokLevel02;
    public GameObject PadLcokLevel03;

    public GameObject Level01Info;
    public GameObject Level02Info;
    public GameObject Level03Info;

    public GameObject FinalPanel;

    public GameObject fillArea;

    public GameObject soundIcon;

    public GameObject muteSoundIcon;

    private int counterLevelOne;
    private int counterLevelTwo;
    private int counterLevelThree;

    Color32 levelCompletedColor = new Color32(0, 255, 0, 255);

    private int minutes;
    private int seconds;

    private string niceTime = "";

    public void PlayGame()
    {
        PlayerPrefs.SetString("LevelName", EventSystem.current.currentSelectedGameObject.name);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Start()
    {
        LoadSettings();
    }

    private void LoadSettings()
    {
        counterLevelOne = PlayerPrefs.GetInt("counterLevelOne");
        counterLevelTwo = PlayerPrefs.GetInt("counterLevelTwo");
        counterLevelThree = PlayerPrefs.GetInt("counterLevelThree");

        if (PlayerPrefs.GetString("isMainMenuAudioMuted") == "True")
        {
            backgroundAudio.volume = 0.0f;
            fillArea.SetActive(false);
            muteSoundIcon.SetActive(true);
            soundIcon.SetActive(false);
        }
        else if (PlayerPrefs.GetString("isMainMenuAudioMuted") == "False")
        {
            backgroundAudio.volume = 0.1f;
            fillArea.SetActive(true);
            muteSoundIcon.SetActive(false);
            soundIcon.SetActive(true);
        }

        isLevelOnePassed = PlayerPrefs.GetString("levelIsPassed");
        isLevelTwoPassed = PlayerPrefs.GetString("levelIsPassed2");
        isLevelThreePassed = PlayerPrefs.GetString("levelIsPassed3");

        levelOneFinalTime = PlayerPrefs.GetFloat("levelOneFinalTime");
        levelTwoFinalTime = PlayerPrefs.GetFloat("levelTwoFinalTime");
        levelThreeFinalTime = PlayerPrefs.GetFloat("levelThreeFinalTime");

        levelOneBestTime = PlayerPrefs.GetFloat("levelOneBestTime");
        levelTwoBestTime = PlayerPrefs.GetFloat("levelTwoBestTime");
        levelThreeBestTime = PlayerPrefs.GetFloat("levelThreeBestTime");

        if (levelOneBestTime <= levelOneFinalTime)
        {
            levelOneBestTime = levelOneFinalTime;
            minutes = Mathf.FloorToInt(levelOneBestTime / 60F);
            seconds = Mathf.FloorToInt(levelOneBestTime - minutes * 60);
            niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            Level01Info.GetComponent<TMPro.TextMeshProUGUI>().text += " " + niceTime + " TIME LEFT";
            PlayerPrefs.SetFloat("levelOneBestTime", levelOneBestTime);
            PlayerPrefs.Save();
        }
        else
        {
            minutes = Mathf.FloorToInt(levelOneBestTime / 60F);
            seconds = Mathf.FloorToInt(levelOneBestTime - minutes * 60);
            niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            Level01Info.GetComponent<TMPro.TextMeshProUGUI>().text += " " + niceTime + " TIME LEFT";
        }

        if (levelTwoBestTime <= levelTwoFinalTime)
        {
            levelTwoBestTime = levelTwoFinalTime;
            minutes = Mathf.FloorToInt(levelTwoBestTime / 60F);
            seconds = Mathf.FloorToInt(levelTwoBestTime - minutes * 60);
            niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            Level02Info.GetComponent<TMPro.TextMeshProUGUI>().text += " " + niceTime + " TIME LEFT";
            PlayerPrefs.SetFloat("levelTwoBestTime", levelTwoBestTime);
            PlayerPrefs.Save();
        }
        else
        {
            minutes = Mathf.FloorToInt(levelTwoBestTime / 60F);
            seconds = Mathf.FloorToInt(levelTwoBestTime - minutes * 60);
            niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            Level02Info.GetComponent<TMPro.TextMeshProUGUI>().text += " " + niceTime + " TIME LEFT";
        }

        if (levelThreeBestTime <= levelThreeFinalTime)
        {
            levelThreeBestTime = levelThreeFinalTime;
            minutes = Mathf.FloorToInt(levelThreeBestTime / 60F);
            seconds = Mathf.FloorToInt(levelThreeBestTime - minutes * 60);
            niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            Level03Info.GetComponent<TMPro.TextMeshProUGUI>().text += " " + niceTime + " TIME LEFT";
            PlayerPrefs.SetFloat("levelThreeBestTime", levelThreeBestTime);
            PlayerPrefs.Save();
        }
        else
        {
            minutes = Mathf.FloorToInt(levelThreeBestTime / 60F);
            seconds = Mathf.FloorToInt(levelThreeBestTime - minutes * 60);
            niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            Level03Info.GetComponent<TMPro.TextMeshProUGUI>().text += " " + niceTime + " TIME LEFT";
        }

        if (isLevelOnePassed == "True")
        {
            Level02.GetComponent<Image>().enabled = true;
            Level02.GetComponent<Button>().enabled = true;
            HintButtonLevel02.SetActive(true);
            PadLcokLevel02.SetActive(false);
            Level01.GetComponent<Image>().color = levelCompletedColor;
        }
        else if (isLevelOnePassed == "False" && counterLevelOne > 0)
        {
            Level02.GetComponent<Image>().enabled = true;
            Level02.GetComponent<Button>().enabled = true;
            HintButtonLevel02.SetActive(true);
            PadLcokLevel02.SetActive(false);
            Level01.GetComponent<Image>().color = levelCompletedColor;
        }

        if (isLevelTwoPassed == "True")
        {
            Level03.GetComponent<Image>().enabled = true;
            Level03.GetComponent<Button>().enabled = true;
            HintButtonLevel03.SetActive(true);
            PadLcokLevel03.SetActive(false);
            Level02.GetComponent<Image>().color = levelCompletedColor;
        }
        else if (isLevelTwoPassed == "False" && counterLevelTwo > 0)
        {
            Level03.GetComponent<Image>().enabled = true;
            Level03.GetComponent<Button>().enabled = true;
            HintButtonLevel03.SetActive(true);
            PadLcokLevel03.SetActive(false);
            Level02.GetComponent<Image>().color = levelCompletedColor;
        }

        if (isLevelThreePassed == "True")
        {
            Level03.GetComponent<Image>().color = levelCompletedColor;
            ToBeContinued();
        }
        else if (isLevelThreePassed == "False" && counterLevelThree > 0)
        {
            Level03.GetComponent<Image>().color = levelCompletedColor;
            ToBeContinued();
        }
    }

    private void ToBeContinued()
    {
        FinalPanel.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}