using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioMute : MonoBehaviour
{
    public GameObject fillArea;

    public GameObject handle;

    public AudioSource audio;

    public GameObject volumeSlider;

    public GameObject soundIcon;
    public GameObject muteSoundIcon;

    public TextMeshProUGUI volumePercentageText;

    private float audioSliderValue = 0.0f;

    public void MuteAudio()
    {
        volumePercentageText.enabled = false;
        fillArea.SetActive(false);
        handle.SetActive(false);
        audio.volume = 0.0f;
        PlayerPrefs.SetString("isMainMenuAudioMuted", "True");
        PlayerPrefs.Save();
    }

    public void UnmuteAudio()
    {
        volumePercentageText.enabled = true;
        fillArea.SetActive(true);
        handle.SetActive(true);
        audio.volume = 0.1f;
        volumeSlider.SetActive(true);
        PlayerPrefs.SetString("isMainMenuAudioMuted", "False");
        PlayerPrefs.Save();
    }

    private void Start()
    {
        if (PlayerPrefs.GetString("isMainMenuAudioMuted") == "True")
        {
            volumePercentageText.enabled = false;
        }

        audioSliderValue = PlayerPrefs.GetFloat("audioSliderValue");
        volumeSlider.GetComponent<Slider>().value = audioSliderValue;
    }
}