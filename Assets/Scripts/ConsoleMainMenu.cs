using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConsoleMainMenu : MonoBehaviour
{
    private int counterLevelOne = 0;
    private int counterLevelTwo = 0;
    private int counterLevelThree = 0;

    public GameObject console;

    public GameObject backgroundAudio;

    public GameObject cheatCode;

    [SerializeField]
    private int counter = 0;

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Awake()
    {
        counterLevelOne = PlayerPrefs.GetInt("counterLevelOne");
        counterLevelTwo = PlayerPrefs.GetInt("counterLevelTwo");
        counterLevelThree = PlayerPrefs.GetInt("counterLevelThree");
    }

    private void Update()
    {
        if (!console.activeSelf && Input.GetKeyDown(KeyCode.BackQuote))
        {
            console.SetActive(true);
            counter++;

            if(counter > 0)
            {
                console.GetComponent<InputField>().Select();
            }
        }
        else if (console.activeSelf && Input.GetKeyDown(KeyCode.BackQuote))
        {
            console.GetComponent<InputField>().text = "";
            console.SetActive(false);
            counter--;
        }

        if (console.GetComponent<InputField>().text == "quit" || console.GetComponent<InputField>().text == "QUIT")
        {
            Application.Quit();
        }

        if (PlayerPrefs.GetString("cheatUsed") != "True")
        {
            if (console.GetComponent<InputField>().text == "qtyaftw" || console.GetComponent<InputField>().text == "QTYAFTW")
            {
                PlayerPrefs.SetString("levelIsPassed", "True");
                PlayerPrefs.Save();
                PlayerPrefs.SetInt("counterLevelOne", counterLevelOne + 1);
                PlayerPrefs.Save();
                PlayerPrefs.SetInt("counterLevelTwo", counterLevelTwo + 1);
                PlayerPrefs.Save();
                PlayerPrefs.SetInt("counterLevelThree", counterLevelThree + 1);
                PlayerPrefs.Save();
                PlayerPrefs.SetString("levelIsPassed2", "True");
                PlayerPrefs.Save();
                PlayerPrefs.SetString("levelIsPassed3", "True");
                PlayerPrefs.Save();
                PlayerPrefs.SetString("cheatUsed", "True");
                PlayerPrefs.Save();
                console.SetActive(false);
                backgroundAudio.SetActive(false);
                cheatCode.SetActive(true);    
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                Invoke("LoadMainMenu", 6.0f);
            }
        }
    }
}