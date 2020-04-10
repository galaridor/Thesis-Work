using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class LoadingLevel : MonoBehaviour
{
    private string LevelName;

    public Slider slider;

    public TextMeshProUGUI sliderText;

    private string sliderPercentageText = "";

    private double percentage;

    private void Start()
    {
        LevelName = PlayerPrefs.GetString("LevelName");
    }

    private void Update()
    {
        percentage =  Math.Round(slider.value / 14.2f, 0);
        sliderPercentageText = percentage.ToString();
        sliderText.text = sliderPercentageText + "%";
        slider.value++;

        if(slider.value == 1420)
        {
            LoadLevel();
        }
    }

    private void LoadLevel()
    {
        if (LevelName == "Level01")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (LevelName == "Level02")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
        else if (LevelName == "Level03")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }
    }
}