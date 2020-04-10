using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadingGame : MonoBehaviour
{
    private int gameCounter;

    public GameObject trailer;

    public GameObject title;

    public VideoPlayer videoPlayer;

    private void Start()
    {
        gameCounter = PlayerPrefs.GetInt("GameCounter");

        if(gameCounter == 0)
        {
            Invoke("PlayTrailer", 1);
        }
        
        if(gameCounter > 0)
        {
            Invoke("ShowTitle", 1);
        }
    }

    private void Update()
    {
        if (trailer.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShowTitle();
            }
        }
    }

    private void PlayTrailer()
    {
        trailer.SetActive(true);
        Invoke("ShowTitle", 187);
    }

    private void ShowTitle()
    {
        if (trailer.activeSelf)
        {
            trailer.SetActive(false);
        }
        title.SetActive(true);
        Invoke("LoadMainMenu", 7);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}