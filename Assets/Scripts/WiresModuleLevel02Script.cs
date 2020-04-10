using UnityEngine;
using TMPro;

public class WiresModuleLevel02Script : MonoBehaviour
{
    public GameObject wrongSound;
    public GameObject correctSound;

    private int bombIndex;

    private int strikes;

    [SerializeField]
    private int numberOfModules = 0;

    public GameObject wiresIndicator;

    public Material indicatorPassed;

    public Material indicatorStrike;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public GameObject BlueWire;
    public GameObject BlueWireCut;

    public GameObject BlueWire02;
    public GameObject BlueWire02Cut;

    public GameObject YellowWire;
    public GameObject YellowWireCut;

    public GameObject YellowWire02;
    public GameObject YellowWire02Cut;

    public GameObject GreenWire;
    public GameObject GreenWireCut;

    public GameObject GreenWire02;
    public GameObject GreenWire02Cut;

    public GameObject RedWire;
    public GameObject RedWireCut;

    public GameObject RedWire02;
    public GameObject RedWire02Cut;

    public GameObject WhiteWire;
    public GameObject WhiteWireCut;

    public GameObject WhiteWire02;
    public GameObject WhiteWire02Cut;

    public TextMeshProUGUI strikesText;

    public Light wiresIndicatorLight;

    public void OnMouseEnter()
    {
        GameObject theGM = GameObject.Find("GameManagerLevel02");
        GameManagerLevel02 gm = theGM.GetComponent<GameManagerLevel02>();

        if (gm.wiresFinal == false)
        { 
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    public void OnMouseExit()
    {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    private void Start()
    {
        PlayerPrefs.SetInt("numberOfModules", 0);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        if (wiresIndicator.GetComponent<MeshRenderer>().material.color == new Color32(255, 0, 0, 255) || wiresIndicator.GetComponent<MeshRenderer>().material.color == new Color32(0, 255, 0, 255) && wiresIndicatorLight.enabled == false)
        {
            wiresIndicatorLight.enabled = true;
        }
    }

    public void OnMouseDown()
    {
        numberOfModules = PlayerPrefs.GetInt("numberOfModules");
        correctSound.SetActive(false);
        wrongSound.SetActive(false);

        if (PlayerPrefs.GetString("started") == "False")
        {
            PlayerPrefs.SetString("started", "True");
            PlayerPrefs.Save();
        }

        GameObject theGM = GameObject.Find("GameManagerLevel02");
        GameManagerLevel02 gm = theGM.GetComponent<GameManagerLevel02>();

        bombIndex = gm.bombIndex;

        strikes = gm.levelTwoStrikes;

        if (bombIndex == 1)
        {
            if (gm.wiresFinal == false)
            {
                if (this.gameObject.name == "YellowWire01")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    wiresIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                    gm.wiresFinal = true;
                    numberOfModules++;
                    PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                    PlayerPrefs.Save();
                    YellowWire.SetActive(false);
                    YellowWireCut.SetActive(true);
                    if (numberOfModules != 5)
                    {
                        correctSound.SetActive(true);
                    }
                }
                else if(this.gameObject.name == "RedWire")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    RedWire.SetActive(false);
                    RedWireCut.SetActive(true);
                    gm.levelTwoStrikes++;
                    strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                    wiresIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                    if (strikes != 1)
                    {
                        wrongSound.SetActive(true);
                    }
                }
                else if (this.gameObject.name == "BlueWire")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    BlueWire.SetActive(false);
                    BlueWireCut.SetActive(true);
                    gm.levelTwoStrikes++;
                    strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                    wiresIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                    if (strikes != 1)
                    {
                        wrongSound.SetActive(true);
                    }
                }
                else if (this.gameObject.name == "RedWire")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    RedWire.SetActive(false);
                    RedWireCut.SetActive(true);
                    gm.levelTwoStrikes++;
                    strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                    wiresIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                    if (strikes != 1)
                    {
                        wrongSound.SetActive(true);
                    }
                }
                else if (this.gameObject.name == "YellowWire02")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    YellowWire02.SetActive(false);
                    YellowWire02Cut.SetActive(true);
                    gm.levelTwoStrikes++;
                    strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                    wiresIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                    if (strikes != 1)
                    {
                        wrongSound.SetActive(true);
                    }
                }
            }
        }
        else if (bombIndex == 2)
        {
            if (gm.wiresFinal == false)
            {
                if (this.gameObject.name == "YellowWire")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    wiresIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                    numberOfModules++;
                    PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                    PlayerPrefs.Save();
                    gm.wiresFinal = true;
                    YellowWire.SetActive(false);
                    YellowWireCut.SetActive(true);

                    if (numberOfModules != 5)
                    {
                        correctSound.SetActive(true);
                    }
                }
                else if (this.gameObject.name == "GreenWire")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    GreenWire.SetActive(false);
                    GreenWireCut.SetActive(true);
                    gm.levelTwoStrikes++;
                    strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                    wiresIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                    if (strikes != 1)
                    {
                        wrongSound.SetActive(true);
                    }
                }
                else if (this.gameObject.name == "BlueWire")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    BlueWire.SetActive(false);
                    BlueWireCut.SetActive(true);
                    gm.levelTwoStrikes++;
                    strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                    wiresIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                    if (strikes != 1)
                    {
                        wrongSound.SetActive(true);
                    }
                }
                else if (this.gameObject.name == "WhiteWire")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    WhiteWire.SetActive(false);
                    WhiteWireCut.SetActive(true);
                    gm.levelTwoStrikes++;
                    strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                    wiresIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                    if (strikes != 1)
                    {
                        wrongSound.SetActive(true);
                    }
                }
                else if (this.gameObject.name == "RedWire")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    RedWire.SetActive(false);
                    RedWireCut.SetActive(true);
                    gm.levelTwoStrikes++;
                    strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                    wiresIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                    if (strikes != 1)
                    {
                        wrongSound.SetActive(true);
                    }
                }
            }
        }
        else if (bombIndex == 3)
        {
            if (gm.wiresFinal == false)
            {
                if (this.gameObject.name == "BlueWire")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    wiresIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                    gm.wiresFinal = true;
                    numberOfModules++;
                    PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                    PlayerPrefs.Save();
                    BlueWire.SetActive(false);
                    BlueWireCut.SetActive(true);
                    if (numberOfModules != 5)
                    {
                        correctSound.SetActive(true);
                    }
                }
                else if (this.gameObject.name == "RedWire")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    RedWire.SetActive(false);
                    RedWireCut.SetActive(true);
                    gm.levelTwoStrikes++;
                    strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                    wiresIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                    if (strikes != 1)
                    {
                        wrongSound.SetActive(true);
                    }
                }
                else if (this.gameObject.name == "WhiteWire")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    WhiteWire.SetActive(false);
                    WhiteWireCut.SetActive(true);
                    gm.levelTwoStrikes++;
                    strikesText.text = "STRIKES: " +  gm.levelTwoStrikes.ToString();
                    wiresIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                    if (strikes != 1)
                    {
                        wrongSound.SetActive(true);
                    }
                }
            }
        }
    }
}