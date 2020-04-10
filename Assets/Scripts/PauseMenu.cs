using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public AudioSource siren;

    public GameObject pauseMenuUI;

    public GameObject mainCamera;

    public GameObject secondCamera;

    public GameObject bomb;
    public GameObject firstBomb;

    public GameObject bomb02;
    public GameObject firstBomb02;

    public GameObject bomb03;
    public GameObject firstBomb03;

    public string mouseLookScript;

    public string bombRotationScript;

    private int bombIndex;

    public GameObject keyGuide;

    public GameObject postFX;

    public GameObject lightnings;

    public Button resumeButton;
    public Button keyGuideButton;
    public Button menuButton;
    public Button quitButton;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!keyGuide.activeSelf) 
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            GameObject theGM = GameObject.Find("GameManagerLevel01");
            GameManagerLevel01 gm = theGM.GetComponent<GameManagerLevel01>();
            bombIndex = gm.bombIndex;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            GameObject theGM = GameObject.Find("GameManagerLevel02");
            GameManagerLevel02 gm = theGM.GetComponent<GameManagerLevel02>();
            bombIndex = gm.bombIndex;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            GameObject theGM = GameObject.Find("GameManagerLevel03");
            GameManagerLevel03 gm = theGM.GetComponent<GameManagerLevel03>();
            bombIndex = gm.bombIndex;
        }
    }

    public void Resume()
    {
        if (PlayerPrefs.GetInt("postProcessingValue") == 1)
        {
            postFX.GetComponent<PostProcessVolume>().enabled = true;
        }

        if (secondCamera.activeSelf)
        {
            siren.Play();
            (mainCamera.GetComponent(mouseLookScript) as MonoBehaviour).enabled = false;
            switch (bombIndex)
            {
                case 1:
                    (bomb.GetComponent(bombRotationScript) as MonoBehaviour).enabled = true;
                    break;
                case 2:
                    (bomb02.GetComponent(bombRotationScript) as MonoBehaviour).enabled = true;
                    break;
                case 3:
                    (bomb03.GetComponent(bombRotationScript) as MonoBehaviour).enabled = true;
                    break;
            }          
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
            switch (bombIndex)
            {
                case 1:
                    bomb.SetActive(true);
                    break;
                case 2:
                    bomb02.SetActive(true);
                    break;
                case 3:
                    bomb03.SetActive(true);
                    break;
            }

            Cursor.visible = true;
        }
        else
        {
            siren.Play();
            (mainCamera.GetComponent(mouseLookScript) as MonoBehaviour).enabled = true;
            switch (bombIndex)
            {
                case 1:
                    (bomb.GetComponent(bombRotationScript) as MonoBehaviour).enabled = true;
                    break;
                case 2:
                    (bomb02.GetComponent(bombRotationScript) as MonoBehaviour).enabled = true;
                    break;
                case 3:
                    (bomb03.GetComponent(bombRotationScript) as MonoBehaviour).enabled = true;
                    break;
            }
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
            switch (bombIndex)
            {
                case 1:
                    firstBomb.SetActive(true);
                    break;
                case 2:
                    firstBomb02.SetActive(true);
                    break;
                case 3:
                    firstBomb03.SetActive(true);
                    break;
            }
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Pause()
    {
        ColorBlock colorVar01 = resumeButton.colors;
        ColorBlock colorVar02 = keyGuideButton.colors;
        ColorBlock colorVar03 = menuButton.colors;
        ColorBlock colorVar04 = quitButton.colors;

        if (!lightnings.activeSelf)
        {
            colorVar01.highlightedColor = new Color32(255, 0, 0, 61);
            resumeButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            resumeButton.colors = colorVar01;

            colorVar02.highlightedColor = new Color32(255, 0, 0, 61);
            keyGuideButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            keyGuideButton.colors = colorVar02;

            colorVar03.highlightedColor = new Color32(255, 0, 0, 61);
            menuButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            menuButton.colors = colorVar03;

            colorVar04.highlightedColor = new Color32(255, 0, 0, 61);
            quitButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            quitButton.colors = colorVar04;
        }
        else if(lightnings.activeSelf)
        {
            colorVar01.highlightedColor = new Color32(245, 245, 245, 61);
            resumeButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
            resumeButton.colors = colorVar01;

            colorVar02.highlightedColor = new Color32(245, 245, 245, 61);
            keyGuideButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
            keyGuideButton.colors = colorVar02;

            colorVar03.highlightedColor = new Color32(245, 245, 245, 61);
            menuButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
            menuButton.colors = colorVar03;

            colorVar04.highlightedColor = new Color32(245, 245, 245, 61);
            quitButton.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
            quitButton.colors = colorVar04;
        }

        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        if (PlayerPrefs.GetInt("postProcessingValue") == 1)
        {
            postFX.GetComponent<PostProcessVolume>().enabled = false;
        }

        if (siren.isPlaying)
        {
            siren.Pause();
        }
        if (secondCamera.activeSelf)
        {
            switch (bombIndex)
            {
                case 1:
                    bomb.SetActive(false);
                    break;
                case 2:
                    bomb02.SetActive(false);
                    break;
                case 3:
                    bomb03.SetActive(false);
                    break;
            }
        }
        else
        {
            switch (bombIndex)
            {
                case 1:
                    firstBomb.SetActive(false);
                    break;
                case 2:
                    firstBomb02.SetActive(false);
                    break;
                case 3:
                    firstBomb03.SetActive(false);
                    break;
            }

        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        (mainCamera.GetComponent(mouseLookScript) as MonoBehaviour).enabled = false;
        switch (bombIndex)
        {
            case 1:
                (bomb.GetComponent(bombRotationScript) as MonoBehaviour).enabled = false;
                break;
            case 2:
                (bomb02.GetComponent(bombRotationScript) as MonoBehaviour).enabled = false;
                break;
            case 3:
                (bomb03.GetComponent(bombRotationScript) as MonoBehaviour).enabled = false;
                break;
        }
        Time.timeScale = 0f; 
        pauseMenuUI.SetActive(true);   
        GameIsPaused = true;
        
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
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