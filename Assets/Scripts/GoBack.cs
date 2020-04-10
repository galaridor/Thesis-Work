using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{
    public GameObject bomb;

    public GameObject secondCamera;

    public GameObject firstCamera;

    public GameObject player;

    public string lookAroundScriptName;

    public string movementScriptName;

    private bool started = false;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Start()
    {
        PlayerPrefs.SetString("started", "False");
        PlayerPrefs.Save();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (secondCamera.activeSelf)
            {
                if (PlayerPrefs.GetString("started")  ==  "True")
                {
                    started = true;
                }

                if (started == false)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = true;
                    bomb.SetActive(true);
                    firstCamera.SetActive(true);
                    secondCamera.SetActive(false);
                    (firstCamera.GetComponent(lookAroundScriptName) as MonoBehaviour).enabled = true;
                    firstCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
                    (player.GetComponent(movementScriptName) as MonoBehaviour).enabled = true;
                }
            }
        }
    }
}