using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    public GameObject bomb;

    public GameObject secondBombPosition;

    public GameObject secondCamera;

    public GameObject firstCamera;

    public GameObject player;

    public string scriptName;

    public string movementScriptName;

    public bool triger = false;

    public bool exitTrigger = false;

    public GameObject console;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Update()
    {
        float posX = player.transform.position.x;
        float posZ = player.transform.position.z;

        if (posX >= -2 && posX <= 2 && posZ <= -2 && posZ >= -5 && exitTrigger == false)
        {
            triger = true;
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }

        if (posX < -2 || posX > 2 || posZ > -2 || posZ < -5)
        {
            triger = false;
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }

    public void OnMouseEnter()
    {
        if (!console.activeSelf)
        {
            exitTrigger = false;
            if (triger == true)
            {
                Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            }
            else if (triger == false)
            {
                Cursor.SetCursor(null, Vector2.zero, cursorMode);
            }
        }
    }

    public void OnMouseExit()
    {
        if (!console.activeSelf)
        {
            exitTrigger = true;
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }

   public void OnMouseDown()
    {
        if (triger == true && !console.activeSelf)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            bomb.SetActive(false);
            secondBombPosition.transform.rotation = Quaternion.Euler(0, 0, 0);
            secondCamera.SetActive(true);
            (firstCamera.GetComponent(scriptName) as MonoBehaviour).enabled = false;
            firstCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
            (player.GetComponent(movementScriptName) as MonoBehaviour).enabled = false;
        }
    }
}