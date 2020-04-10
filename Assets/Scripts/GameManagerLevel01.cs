using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class GameManagerLevel01 : MonoBehaviour
{
    public GameObject canvas;

    public GameObject panel;

    public GameObject InfoText;

    public GameObject background;

    public GameObject backgroundMusic;

    public GameObject siren;

    public GameObject bomb;
    public GameObject bombSecondPosition;

    public GameObject bomb02;
    public GameObject bomb02SecondPosition;

    public GameObject bomb03;
    public GameObject bomb03SecondPosition;

    public GameObject bombSoundEffect;

    public GameObject succesfullSoundEffect;

    public GameObject menuButton;
    public GameObject quitButton;

    public GameObject console;

    public GameObject cheatCode;

    private bool levelIsPassed = false;

    private bool gameHasEnded = false;

    public float levelOneTimeLeft = 300.0f;

    private float lightTimer = 20.0f;

    public string mouseLookScript;
    public string pauseMenuScript;

    public GameObject mainCamera;
    public GameObject secondCamera;

    private float finalTime;
    private int finalTimeCounter = 0;

    public int levelOneStrikes = 0;

    public int bombIndex;

    public float sirenIndex;

    public float lightIndex;

    public GameObject lightning;

    private int counter = 0;

    public bool symbolsFinal = false;
    public bool wiresFinal = false;
    public bool complexWiresFinal = false;
    public bool memoryFinal = false;

    public Material lampOn;
    public Material lampOff;

    public GameObject lamp01;
    public GameObject lamp02;
    public GameObject lamp03;
    public GameObject lamp04;

    private float stopSiren = 30.0f;

    public GameObject postFX;
    public GameObject postAE;
    public GameObject postMB;

    private int postProcessingIndex = 1;

    private int antiAliasingIndex = 1;

    private int motionBlurIndex = 1;

    private int minutes;
    private int seconds;

    private string niceTime = "";

    public void Start()
    {
        bombIndex = UnityEngine.Random.Range(1, 4); //COULD BE 3
        sirenIndex = UnityEngine.Random.Range(90.0f, 30.0f);
        lightIndex = UnityEngine.Random.Range(120.0f, 60.0f);

        Debug.Log(bombIndex);
        Debug.Log(sirenIndex);
        Debug.Log(lightIndex);

        switch (bombIndex)
        {
            case 1:
                bomb.SetActive(true);
                bombSecondPosition.SetActive(true);
                break;
            case 2:
                bomb02.SetActive(true);
                bomb02SecondPosition.SetActive(true);
                break;
            case 3:
                bomb03.SetActive(true);
                bomb03SecondPosition.SetActive(true);
                break;
        }

        postProcessingIndex = PlayerPrefs.GetInt("postProcessingValue");
        antiAliasingIndex = PlayerPrefs.GetInt("antiAliasingValue");
        motionBlurIndex = PlayerPrefs.GetInt("motionBlurValue");
        counter = PlayerPrefs.GetInt("counterLevelOne");

        if (postProcessingIndex == 0)
        {
           postFX.GetComponent<PostProcessVolume>().enabled = false;
        }

        if(antiAliasingIndex == 0)
        {
           mainCamera.GetComponent<PostProcessLayer>().antialiasingMode = PostProcessLayer.Antialiasing.None;
           secondCamera.GetComponent<PostProcessLayer>().antialiasingMode = PostProcessLayer.Antialiasing.None;
        }

        if (motionBlurIndex == 0)
        {
            postMB.GetComponent<PostProcessVolume>().enabled = false;
        }
    }

    public void Update()
    {
        if (Math.Round(levelOneTimeLeft, 0) == Math.Round(sirenIndex, 0))
        {
            siren.SetActive(true);
        }
        if (siren.activeSelf)
        {
            stopSiren -= Time.deltaTime;
        }
        if(Math.Round(stopSiren, 0) == 0)
        {
            siren.SetActive(false);
        }
        if(Math.Round(levelOneTimeLeft, 0) == Math.Round(lightIndex, 0))
        {
            postAE.GetComponent<PostProcessVolume>().enabled = true;            
            lamp01.GetComponent<MeshRenderer>().material = lampOff;
            lamp02.GetComponent<MeshRenderer>().material = lampOff;
            lamp03.GetComponent<MeshRenderer>().material = lampOff;
            lamp04.GetComponent<MeshRenderer>().material = lampOff;
            lightning.SetActive(false);
        }
        if (lightning.activeSelf == false)
        {
            lightTimer -= Time.deltaTime;
            if (Math.Round(lightTimer, 0) == 0)
            {
                postAE.GetComponent<PostProcessVolume>().enabled = false;
                lamp01.GetComponent<MeshRenderer>().material = lampOn;
                lamp02.GetComponent<MeshRenderer>().material = lampOn;
                lamp03.GetComponent<MeshRenderer>().material = lampOn;
                lamp04.GetComponent<MeshRenderer>().material = lampOn;
                lightning.SetActive(true);
            }
        }
        if(levelOneStrikes == 3)
        {
            levelOneTimeLeft = 0.0f;
            EndGame();
        }
        if (LevelCompleted() == true)
        {
            finalTimeCounter++;
            levelIsPassed = true;
            if(finalTimeCounter == 1)
            {
                finalTime = levelOneTimeLeft;
                PlayerPrefs.SetFloat("levelOneFinalTime", finalTime);
                PlayerPrefs.Save();
            }
        }
        levelOneTimeLeft -= Time.deltaTime; 

        if(levelOneTimeLeft <= 0)
        {
            levelOneTimeLeft = 0;
        }

        if (levelOneTimeLeft <= 0.0f && levelIsPassed == false)
        {
            levelOneTimeLeft = 0.0f;
            EndGame();
        }
        if(levelOneTimeLeft > 0.0f && levelIsPassed == true)
        {
            levelOneTimeLeft = 0.0f;
            PassedLevel();
        }

        if (cheatCode.activeSelf)
        {
            levelOneTimeLeft = 1.0f;
        }

        PlayerPrefs.SetString("levelIsPassed", levelIsPassed.ToString());
        PlayerPrefs.Save();
    }

    public bool LevelCompleted()
    {
        if(Wires() == true && Symbols() == true && Memory() == true && ComplexWires() == true) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Symbols()
    {
        return symbolsFinal;
    }

    public bool Memory()
    {
        return memoryFinal;
    }

    public bool ComplexWires()
    {
        return complexWiresFinal;
    }

    public bool Wires()
    {
        return wiresFinal;
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            if (!secondCamera.activeSelf)
            {
                bomb.SetActive(false);
                bomb02.SetActive(false);
                bomb03.SetActive(false);
                (canvas.GetComponent(pauseMenuScript) as MonoBehaviour).enabled = false;
                (mainCamera.GetComponent(mouseLookScript) as MonoBehaviour).enabled = false;
                console.GetComponent<InputField>().enabled = false;
            }
            else
            {
                bombSecondPosition.SetActive(false);
                bomb02SecondPosition.SetActive(false);
                bomb03SecondPosition.SetActive(false);
                (canvas.GetComponent(pauseMenuScript) as MonoBehaviour).enabled = false;
                console.GetComponent<InputField>().enabled = false;
            }
            levelIsPassed = false;
            gameHasEnded = true;
            background.SetActive(true);
            backgroundMusic.SetActive(false);
            bombSoundEffect.SetActive(true);
            Invoke("OpenPanel", 3.0f);
        }
    }

    public void PassedLevel()
    {
        if (levelIsPassed == true)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            counter++;
            PlayerPrefs.SetInt("counterLevelOne", counter);
            PlayerPrefs.Save();
            if (!secondCamera.activeSelf)
            {
                bomb.SetActive(false);
                bomb02.SetActive(false);
                bomb03.SetActive(false);
                (canvas.GetComponent(pauseMenuScript) as MonoBehaviour).enabled = false;
                (mainCamera.GetComponent(mouseLookScript) as MonoBehaviour).enabled = false;
                console.GetComponent<InputField>().enabled = false;
            }
            else
            {
                bombSecondPosition.SetActive(false);
                bomb02SecondPosition.SetActive(false);
                bomb03SecondPosition.SetActive(false);
                (canvas.GetComponent(pauseMenuScript) as MonoBehaviour).enabled = false;
                console.GetComponent<InputField>().enabled = false;
            }
            bomb.SetActive(false);
            bombSecondPosition.SetActive(false);
            levelIsPassed = true;
            gameHasEnded = true;
            background.SetActive(true);
            backgroundMusic.SetActive(false);
            succesfullSoundEffect.SetActive(true);
            Invoke("OpenPanel", 3.0f);
        }
    }

    public void OpenPanel()
    {
        if (!secondCamera.activeSelf)
        {
            bomb.SetActive(false);
            bomb02.SetActive(false);
            bomb03.SetActive(false);
            (canvas.GetComponent(pauseMenuScript) as MonoBehaviour).enabled = false;
            (mainCamera.GetComponent(mouseLookScript) as MonoBehaviour).enabled = false;
            console.GetComponent<InputField>().enabled = false;
        }
        else
        {
            bombSecondPosition.SetActive(false);
            bomb02SecondPosition.SetActive(false);
            bomb03SecondPosition.SetActive(false);
            (canvas.GetComponent(pauseMenuScript) as MonoBehaviour).enabled = false;
            console.GetComponent<InputField>().enabled = false;
        }

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        minutes = Mathf.FloorToInt(finalTime / 60F);
        seconds = Mathf.FloorToInt(finalTime - minutes * 60);
        niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (LevelCompleted() == true)
        {
            InfoText.GetComponent<TMPro.TextMeshProUGUI>().color = new Color32(0, 255, 0, 255);
            menuButton.GetComponent<Image>().color = new Color32(0,255,0,255);
            quitButton.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            InfoText.GetComponent<TMPro.TextMeshProUGUI>().text = ("CONGRATULATIONS," + "\n" + "YOU DEFUSED "+ "\n" + "THE BOMB WITH " + "\n" +  niceTime + " TIME LEFT");
        }
        else
        {
            menuButton.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            quitButton.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            InfoText.GetComponent<TMPro.TextMeshProUGUI>().color = new Color32(255, 0, 0, 255);
            InfoText.GetComponent<TMPro.TextMeshProUGUI>().text = ("THE BOMB EXPLODED," + "\n"+ "BETTER LUCK NEXT TIME");
        }

        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);
        }
    }

    public void LoadMenu()
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