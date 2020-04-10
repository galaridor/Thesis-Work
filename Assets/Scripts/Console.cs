using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Console : MonoBehaviour
{
    private int counterLevelOne = 0;
    private int counterLevelTwo = 0;
    private int counterLevelThree = 0;

    public GameObject mainCamera;
    public GameObject secondCamera;

    public GameObject console;

    public GameObject backgroundAudio;

    public GameObject cheatCode;

    public GameObject canvas;

    [SerializeField]
    private int counter = 0;

    public string mouseLookScript;
    public string pauseMenuScript;
    public string playerMovementScript;
    public string objectClickerScript;
    public string rotateScript;
    public string resetBombPositionScript;
    public string goBackSript;

    public GameObject bomb;
    public GameObject bombSecondPosition;

    public GameObject bomb02;
    public GameObject bomb02SecondPosition;

    public GameObject bomb03;
    public GameObject bomb03SecondPosition;

    public GameObject player;

    public GameObject pauseMenu;

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
        if (!console.activeSelf && Input.GetKeyDown(KeyCode.BackQuote) && !pauseMenu.activeSelf)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            console.SetActive(true);
            counter++;

            if (counter > 0)
            {
                console.GetComponent<InputField>().Select();
            }

            if (!secondCamera.activeSelf)
            {
                (canvas.GetComponent(pauseMenuScript) as MonoBehaviour).enabled = false;
                (mainCamera.GetComponent(mouseLookScript) as MonoBehaviour).enabled = false;
                (player.GetComponent(playerMovementScript) as MonoBehaviour).enabled = false;
                (bomb.GetComponent(objectClickerScript) as MonoBehaviour).enabled = false;
                (bomb02.GetComponent(objectClickerScript) as MonoBehaviour).enabled = false;
                (bomb03.GetComponent(objectClickerScript) as MonoBehaviour).enabled = false;
                Cursor.lockState = CursorLockMode.None;
                //Cursor.visible = true;
            }
            else
            {
                (canvas.GetComponent(pauseMenuScript) as MonoBehaviour).enabled = false;
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    GameObject theGM = GameObject.Find("GameManagerLevel01");
                    GameManagerLevel01 gm = theGM.GetComponent<GameManagerLevel01>();

                    if(gm.bombIndex == 1)
                    {
                        bombSecondPosition.SetActive(false);
                    }
                    else if(gm.bombIndex == 2)
                    {
                        bomb02SecondPosition.SetActive(false);
                    }
                    else if (gm.bombIndex == 3)
                    {
                        bomb03SecondPosition.SetActive(false);
                    }
                }
                else if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    GameObject theGM = GameObject.Find("GameManagerLevel02");
                    GameManagerLevel02 gm = theGM.GetComponent<GameManagerLevel02>();

                    if (gm.bombIndex == 1)
                    {
                        bombSecondPosition.SetActive(false);
                    }
                    else if (gm.bombIndex == 2)
                    {
                        bomb02SecondPosition.SetActive(false);
                    }
                    else if (gm.bombIndex == 3)
                    {
                        bomb03SecondPosition.SetActive(false);
                    }
                }
                else if (SceneManager.GetActiveScene().buildIndex == 4)
                {
                    GameObject theGM = GameObject.Find("GameManagerLevel03");
                    GameManagerLevel03 gm = theGM.GetComponent<GameManagerLevel03>();

                    if (gm.bombIndex == 1)
                    {
                        bombSecondPosition.SetActive(false);
                    }
                    else if (gm.bombIndex == 2)
                    {
                        bomb02SecondPosition.SetActive(false);
                    }
                    else if (gm.bombIndex == 3)
                    {
                        bomb03SecondPosition.SetActive(false);
                    }
                }
                //(bombSecondPosition.GetComponent(rotateScript) as MonoBehaviour).enabled = false;
                //(bombSecondPosition.GetComponent(goBackSript) as MonoBehaviour).enabled = false;
                //(bombSecondPosition.GetComponent(resetBombPositionScript) as MonoBehaviour).enabled = false;
                //(bomb02SecondPosition.GetComponent(rotateScript) as MonoBehaviour).enabled = false;
                //(bomb02SecondPosition.GetComponent(goBackSript) as MonoBehaviour).enabled = false;
                //(bomb02SecondPosition.GetComponent(resetBombPositionScript) as MonoBehaviour).enabled = false;
                //(bomb03SecondPosition.GetComponent(rotateScript) as MonoBehaviour).enabled = false;
                //(bomb03SecondPosition.GetComponent(goBackSript) as MonoBehaviour).enabled = false;
                //(bomb03SecondPosition.GetComponent(resetBombPositionScript) as MonoBehaviour).enabled = false;
            }
        }
        else if (console.activeSelf && Input.GetKeyDown(KeyCode.BackQuote))
        {
            console.GetComponent<InputField>().text = "";
            console.SetActive(false);
            counter--;

            if (!secondCamera.activeSelf)
            {
                (canvas.GetComponent(pauseMenuScript) as MonoBehaviour).enabled = true;
                (mainCamera.GetComponent(mouseLookScript) as MonoBehaviour).enabled = true;
                (player.GetComponent(playerMovementScript) as MonoBehaviour).enabled = true;
                (bomb.GetComponent(objectClickerScript) as MonoBehaviour).enabled = true;
                (bomb02.GetComponent(objectClickerScript) as MonoBehaviour).enabled = true;
                (bomb03.GetComponent(objectClickerScript) as MonoBehaviour).enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                //Cursor.visible = true;
            }
            else
            {
                (canvas.GetComponent(pauseMenuScript) as MonoBehaviour).enabled = true;
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    GameObject theGM = GameObject.Find("GameManagerLevel01");
                    GameManagerLevel01 gm = theGM.GetComponent<GameManagerLevel01>();

                    if (gm.bombIndex == 1)
                    {
                        bombSecondPosition.SetActive(true);
                    }
                    else if (gm.bombIndex == 2)
                    {
                        bomb02SecondPosition.SetActive(true);
                    }
                    else if (gm.bombIndex == 3)
                    {
                        bomb03SecondPosition.SetActive(true);
                    }
                }
                else if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    GameObject theGM = GameObject.Find("GameManagerLevel02");
                    GameManagerLevel02 gm = theGM.GetComponent<GameManagerLevel02>();

                    if (gm.bombIndex == 1)
                    {
                        bombSecondPosition.SetActive(true);
                    }
                    else if (gm.bombIndex == 2)
                    {
                        bomb02SecondPosition.SetActive(true);
                    }
                    else if (gm.bombIndex == 3)
                    {
                        bomb03SecondPosition.SetActive(true);
                    }
                }
                else if (SceneManager.GetActiveScene().buildIndex == 4)
                {
                    GameObject theGM = GameObject.Find("GameManagerLevel03");
                    GameManagerLevel03 gm = theGM.GetComponent<GameManagerLevel03>();

                    if (gm.bombIndex == 1)
                    {
                        bombSecondPosition.SetActive(true);
                    }
                    else if (gm.bombIndex == 2)
                    {
                        bomb02SecondPosition.SetActive(true);
                    }
                    else if (gm.bombIndex == 3)
                    {
                        bomb03SecondPosition.SetActive(true);
                    }
                    //(bombSecondPosition.GetComponent(rotateScript) as MonoBehaviour).enabled = true;
                    //(bombSecondPosition.GetComponent(goBackSript) as MonoBehaviour).enabled = true;
                    //(bombSecondPosition.GetComponent(resetBombPositionScript) as MonoBehaviour).enabled = true;
                    //(bomb02SecondPosition.GetComponent(rotateScript) as MonoBehaviour).enabled = true;
                    //(bomb02SecondPosition.GetComponent(goBackSript) as MonoBehaviour).enabled = true;
                    //(bomb02SecondPosition.GetComponent(resetBombPositionScript) as MonoBehaviour).enabled = true;
                    //(bomb03SecondPosition.GetComponent(rotateScript) as MonoBehaviour).enabled = true;
                    //(bomb03SecondPosition.GetComponent(goBackSript) as MonoBehaviour).enabled = true;
                    //(bomb03SecondPosition.GetComponent(resetBombPositionScript) as MonoBehaviour).enabled = true;
                }
            }
        }

        if (console.GetComponent<InputField>().text == "quit" || console.GetComponent<InputField>().text == "QUIT")
        {
            Application.Quit();
        }

        if (console.GetComponent<InputField>().text == "leave" || console.GetComponent<InputField>().text == "LEAVE")
        {
            LoadMainMenu();
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

                if (!secondCamera.activeSelf)
                {
                    bomb.SetActive(false);
                    bomb02.SetActive(false);
                    bomb03.SetActive(false);
                }
                else
                {
                    bombSecondPosition.SetActive(false);
                    bomb02SecondPosition.SetActive(false);
                    bomb03SecondPosition.SetActive(false);
                }
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                Invoke("LoadMainMenu", 6.0f);
            }
        }
    }
}