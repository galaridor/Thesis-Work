using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    private int gameCounter = 0;

    public AudioMixer audioMixer;

    public Slider volumeSlider;

    public Slider mouseSensSlider;

    public Slider bombRotationSensSlider;

    public Toggle fullScreen;

    Resolution[] resolutions; //an array with all available resolutions

    public Dropdown resolutionDropdown;

    public Dropdown qualityDropdown;

    public Dropdown postProcessingDropdown;

    public Dropdown antiAliasingDropdown;

    public Dropdown motionBlurDropdown;

    [SerializeField]
    private float audioSliderValue = 0.5f;

    [SerializeField]
    private float mouseSensSliderValue = 1.0f;

    [SerializeField]
    private float bombRotationsSensSliderValue = 2.0f;

    [SerializeField]
    private int postProcessingValue = 1;

    [SerializeField]
    private int antiAliasingValue = 1;

    [SerializeField]
    private int motionBlurValue = 1;

    [SerializeField]
    private int qualityValue = 2;

    public TextMeshProUGUI volumeSliderText;

    public TextMeshProUGUI mouseSensSliderText;

    public TextMeshProUGUI bombRotationSensSliderText;

    private string volumePercentageText = "";

    private string mouseSensValueText = "";

    private string bombRotationValueText = "";

    private double volumePercentage;

    private double mouseSensValue;

    private double bombRotationSensValue;

    private void Start()
    {
        volumeSliderText.text = (Math.Round(volumeSlider.value * 100.0f, 0)).ToString() + "%";

        mouseSensSliderText.text = mouseSensSlider.value.ToString();
        bombRotationSensSliderText.text = bombRotationSensSlider.value.ToString();

        gameCounter = PlayerPrefs.GetInt("GameCounter");
        gameCounter++;
        PlayerPrefs.SetInt("GameCounter", gameCounter);
        PlayerPrefs.Save();

        SettingsConfiguration(gameCounter);

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " : " + resolutions[i].refreshRate + " Hz";
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        if(Screen.fullScreen == false)
        {
            fullScreen.isOn = false;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)  //value from the slider
    {
        audioMixer.SetFloat("MyExposedParam", Mathf.Log10(volume) * 20);
        volumePercentage = Math.Round(volume * 100.0f, 0);
        volumePercentageText = volumePercentage.ToString();
        volumeSliderText.text = volumePercentageText + "%";
        PlayerPrefs.SetFloat("audioSliderValue", volume);
        PlayerPrefs.Save();
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex); //qualityindex
        PlayerPrefs.SetInt("quality", qualityIndex);
        PlayerPrefs.Save();
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen; //setting to fullscreen
    }

    public void SetMouseSensitivity(float sens)
    {
        mouseSensValue = Math.Round(sens, 2);
        mouseSensValueText = mouseSensValue.ToString();
        mouseSensSliderText.text = mouseSensValueText;
        PlayerPrefs.SetFloat("mouseSensValue", sens);
        PlayerPrefs.Save();
    }

    public void SetBombRotationSensitivity(float sens)
    {
        bombRotationSensValue = Math.Round(sens, 2);
        bombRotationValueText = bombRotationSensValue.ToString();
        bombRotationSensSliderText.text = bombRotationValueText;
        PlayerPrefs.SetFloat("bombRotationsSensValue", sens);
        PlayerPrefs.Save();
    }

    public void SetPostProcessing(int index)
    {
        PlayerPrefs.SetInt("postProcessingValue", index);
        PlayerPrefs.Save();
    }

    public void SetAntiAliasing(int index)
    {
        PlayerPrefs.SetInt("antiAliasingValue", index);
        PlayerPrefs.Save();
    }

    public void SetMotionBlur(int index)
    {
        PlayerPrefs.SetInt("motionBlurValue", index);
        PlayerPrefs.Save();
    }

    private void SettingsConfiguration(int gameCounter)
    {
        if (gameCounter > 1)
        {
            audioSliderValue = PlayerPrefs.GetFloat("audioSliderValue");
            volumeSlider.value = audioSliderValue;
            audioMixer.SetFloat("MyExposedParam", Mathf.Log10(audioSliderValue) * 20);
            qualityValue = PlayerPrefs.GetInt("quality");
            QualitySettings.SetQualityLevel(qualityValue);
            qualityDropdown.value = PlayerPrefs.GetInt("quality");
            mouseSensSliderValue = PlayerPrefs.GetFloat("mouseSensValue");
            mouseSensSlider.value = mouseSensSliderValue;
            bombRotationsSensSliderValue = PlayerPrefs.GetFloat("bombRotationsSensValue");
            bombRotationSensSlider.value = bombRotationsSensSliderValue;
            postProcessingValue = PlayerPrefs.GetInt("postProcessingValue");
            postProcessingDropdown.value = postProcessingValue;
            antiAliasingValue = PlayerPrefs.GetInt("antiAliasingValue");
            antiAliasingDropdown.value = antiAliasingValue;
            motionBlurValue = PlayerPrefs.GetInt("motionBlurValue");
            motionBlurDropdown.value = motionBlurValue;
        }
        else if (gameCounter == 1)
        {
            audioMixer.SetFloat("MyExposedParam", Mathf.Log10(audioSliderValue) * 20);
            QualitySettings.SetQualityLevel(qualityValue);
            PlayerPrefs.SetFloat("audioSliderValue", audioSliderValue);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("quality", qualityValue);
            PlayerPrefs.Save();
            PlayerPrefs.SetFloat("mouseSensValue", mouseSensSliderValue);
            PlayerPrefs.Save();
            PlayerPrefs.SetFloat("bombRotationsSensValue", bombRotationsSensSliderValue);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("postProcessingValue", postProcessingValue);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("antiAliasingValue", antiAliasingValue);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("motionBlurValue", motionBlurValue);
            PlayerPrefs.Save();
        }
    }
}