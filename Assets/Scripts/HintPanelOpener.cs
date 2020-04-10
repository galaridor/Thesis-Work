using UnityEngine;

public class HintPanelOpener : MonoBehaviour
{
    public GameObject Panel;

    public GameObject ButtonText;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public void OnMouseEnter()
    {
        ButtonText.SetActive(true);
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    public void OnMouseExit()
    {
        ButtonText.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    public void OnMouseEnterX()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    public void OnMOuseExitX()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    public void OpenPanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }

    public void ClosePanel()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        Panel.SetActive(false);
    }

    private void Update()
    {
        if (Panel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Panel.SetActive(false);
            }
        }
    }
}