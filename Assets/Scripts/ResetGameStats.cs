using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetGameStats : MonoBehaviour
{
    public GameObject Level01;
    public GameObject Level02;
    public GameObject Level03;

    public GameObject HintButtonLevel01;
    public GameObject HintButtonLevel02;
    public GameObject HintButtonLevel03;

    public GameObject PadLcokLevel01;
    public GameObject PadLcokLevel02;
    public GameObject PadLcokLevel03;

    public GameObject FinalPanel;

    public Slider volumeSlider;

    public void ResetGameStatistics()
    {
        FinalPanel.SetActive(false);

        PlayerPrefs.SetString("levelIsPassed", "False");
        PlayerPrefs.Save();
        PlayerPrefs.SetString("levelIsPassed2", "False");
        PlayerPrefs.Save();
        PlayerPrefs.SetString("levelIsPassed3", "False");
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat("levelOneFinalTime", 0.0f);
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat("levelTwoFinalTime", 0.0f);
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat("levelThreeFinalTime", 0.0f);
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat("levelOneBestTime", 0.0f);
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat("levelTwoBestTime", 0.0f);
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat("levelThreeBestTime", 0.0f);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("counterLevelOne", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("counterLevelTwo", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("counterLevelThree", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetString("cheatUsed", "False");
        PlayerPrefs.Save();
        PlayerPrefs.SetString("isMainMenuAudioMuted", "False");
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat("audioSliderValue", 0.5f) ;
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("GameCounter", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("quality", 2);
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat("mouseSensValue", 1.0f);
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat("bombRotationsSensValue", 2.0f);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("postProcessingValue", 1);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("antiAliasingValue", 1);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("motionBlurValue", 1);
        PlayerPrefs.Save();

        PadLcokLevel02.SetActive(true);
        PadLcokLevel03.SetActive(true);

        HintButtonLevel02.SetActive(false);
        HintButtonLevel03.SetActive(false);

        Level01.GetComponent<Image>().enabled = true;
        Level01.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Level01.GetComponent<Button>().enabled = true;

        Level02.GetComponent<Image>().enabled = false;
        Level02.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Level02.GetComponent<Button>().enabled = false;

        Level03.GetComponent<Image>().enabled = false;
        Level03.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        Level03.GetComponent<Button>().enabled = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}