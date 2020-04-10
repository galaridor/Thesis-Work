using UnityEngine;
using TMPro;

public class ComplexWiresModuleLevel02Script : MonoBehaviour
{
    public GameObject wrongSound;
    public GameObject correctSound;

    private int bombIndex;

    private int strikes;

    [SerializeField]
    private int numberOfModules = 0;

    [SerializeField]
    private int counter = 0;

    public GameObject complexWiresIndicator;

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

    public Light complexWiresIndicatorLight;

    public void OnMouseEnter()
    {
        GameObject theGM = GameObject.Find("GameManagerLevel02");
        GameManagerLevel02 gm = theGM.GetComponent<GameManagerLevel02>();

        if (gm.complexWiresFinal == false)
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
        PlayerPrefs.SetInt("complexWiresCounter", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("numberOfModules", 0);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        if (complexWiresIndicator.GetComponent<MeshRenderer>().material.color == new Color32(255, 0, 0, 255) || complexWiresIndicator.GetComponent<MeshRenderer>().material.color == new Color32(0, 255, 0, 255))
        {
            complexWiresIndicatorLight.enabled = true;
        }
    }

    public void OnMouseDown()
    {
        numberOfModules = PlayerPrefs.GetInt("numberOfModules");
        counter = PlayerPrefs.GetInt("complexWiresCounter");
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
            if (gm.complexWiresFinal == false)
            {
                if (this.gameObject.name == "ComplexGreenWire01")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    GreenWire.SetActive(false);
                    GreenWireCut.SetActive(true);
                    counter++;
                    PlayerPrefs.SetInt("complexWiresCounter", counter);
                    PlayerPrefs.Save();
                    if (counter == 2)
                    {
                        numberOfModules++;
                        PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                        PlayerPrefs.Save();
                        gm.complexWiresFinal = true;
                        if (numberOfModules != 5)
                        {
                            correctSound.SetActive(true);
                        }
                        complexWiresIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                    }
                }
                else if (this.gameObject.name == "ComplexGreenWire02")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    GreenWire02.SetActive(false);
                    GreenWire02Cut.SetActive(true);
                    counter++;
                    PlayerPrefs.SetInt("complexWiresCounter", counter);
                    PlayerPrefs.Save();
                    if (counter == 2)
                    {
                        numberOfModules++;
                        PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                        PlayerPrefs.Save();
                        gm.complexWiresFinal = true;
                        if (numberOfModules != 5)
                        {
                            correctSound.SetActive(true);
                        }
                        complexWiresIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                    }
                }
                else if (this.gameObject.name == "ComplexYellowWire")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    YellowWire.SetActive(false);
                    YellowWireCut.SetActive(true);
                    gm.levelTwoStrikes++;
                    strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                    complexWiresIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                    if (strikes != 1)
                    {
                        wrongSound.SetActive(true);
                    }
                }
                else if (this.gameObject.name == "ComplexRedWire")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    RedWire.SetActive(false);
                    RedWireCut.SetActive(true);
                    gm.levelTwoStrikes++;
                    strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                    complexWiresIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                    if (strikes != 1)
                    {
                        wrongSound.SetActive(true);
                    }
                }
                else if (this.gameObject.name == "ComplexBlueWire")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    BlueWire.SetActive(false);
                    BlueWireCut.SetActive(true);
                    gm.levelTwoStrikes++;
                    strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                    complexWiresIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                    if (strikes != 1)
                    {
                        wrongSound.SetActive(true);
                    }
                }
            }
        }
        else if (bombIndex == 2)
        {
            if (gm.complexWiresFinal == false)
            {
                if (this.gameObject.name == "ComplexGreenWire")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    GreenWire.SetActive(false);
                    GreenWireCut.SetActive(true);
                    counter++;
                    PlayerPrefs.SetInt("complexWiresCounter", counter);
                    PlayerPrefs.Save();
                    if (counter == 2)
                    {
                        numberOfModules++;
                        PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                        PlayerPrefs.Save();
                        gm.complexWiresFinal = true;
                        if (numberOfModules != 5)
                        {
                            correctSound.SetActive(true);
                        }
                        complexWiresIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                    }
                }
                else if (this.gameObject.name == "ComplexYellowWire")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    YellowWire.SetActive(false);
                    YellowWireCut.SetActive(true);
                    counter++;
                    PlayerPrefs.SetInt("complexWiresCounter", counter);
                    PlayerPrefs.Save();
                    if (counter == 2)
                    {
                        numberOfModules++;
                        PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                        PlayerPrefs.Save();
                        gm.complexWiresFinal = true;
                        if (numberOfModules != 5)
                        {
                            correctSound.SetActive(true);
                        }
                        complexWiresIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                    }
                }
                else if (this.gameObject.name == "ComplexRedWire01")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    RedWire.SetActive(false);
                    RedWireCut.SetActive(true);
                    gm.levelTwoStrikes++;
                    strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                    complexWiresIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                    if (strikes != 1)
                    {
                        wrongSound.SetActive(true);
                    }
                }
                else if (this.gameObject.name == "ComplexRedWire02")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    RedWire02.SetActive(false);
                    RedWire02Cut.SetActive(true);
                    gm.levelTwoStrikes++;
                    strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                    complexWiresIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                    if (strikes != 1)
                    {
                        wrongSound.SetActive(true);
                    }
                }
                else if (this.gameObject.name == "ComplexBlueWire")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    BlueWire.SetActive(false);
                    BlueWireCut.SetActive(true);
                    gm.levelTwoStrikes++;
                    strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                    complexWiresIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                    if (strikes != 1)
                    {
                        wrongSound.SetActive(true);
                    }
                }
            }
        }
        else if (bombIndex == 3)
        {
            if (gm.complexWiresFinal == false)
            {
                if (this.gameObject.name == "ComplexRedWire")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    RedWire.SetActive(false);
                    RedWireCut.SetActive(true);
                    counter++;
                    PlayerPrefs.SetInt("complexWiresCounter", counter);
                    PlayerPrefs.Save();
                    if (counter == 3)
                    {
                        numberOfModules++;
                        PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                        PlayerPrefs.Save();
                        gm.complexWiresFinal = true;
                        if (numberOfModules != 5)
                        {
                            correctSound.SetActive(true);
                        }
                        complexWiresIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                    }
                }
                else if (this.gameObject.name == "ComplexWhiteWire01")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    WhiteWire.SetActive(false);
                    WhiteWireCut.SetActive(true);
                    counter++;
                    PlayerPrefs.SetInt("complexWiresCounter", counter);
                    PlayerPrefs.Save();
                    if (counter == 3)
                    {
                        numberOfModules++;
                        PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                        PlayerPrefs.Save();
                        gm.complexWiresFinal = true;
                        if (numberOfModules != 5)
                        {
                            correctSound.SetActive(true);
                        }
                        complexWiresIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                    }
                }
                else if (this.gameObject.name == "ComplexWhiteWire02")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    WhiteWire02.SetActive(false);
                    WhiteWire02Cut.SetActive(true);
                    counter++;
                    PlayerPrefs.SetInt("complexWiresCounter", counter);
                    PlayerPrefs.Save();
                    if (counter == 3)
                    {
                        numberOfModules++;
                        PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                        PlayerPrefs.Save();
                        gm.complexWiresFinal = true;
                        if (numberOfModules != 5)
                        {
                            correctSound.SetActive(true);
                        }
                        complexWiresIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                    }
                }
                else if (this.gameObject.name == "ComplexYellowWire")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    YellowWire.SetActive(false);
                    YellowWireCut.SetActive(true);
                    gm.levelTwoStrikes++;
                    strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                    complexWiresIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                    if (strikes != 1)
                    {
                        wrongSound.SetActive(true);
                    }
                }
                else if (this.gameObject.name == "ComplexGreenWire")
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    GreenWire.SetActive(false);
                    GreenWireCut.SetActive(true);
                    gm.levelTwoStrikes++;
                    strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                    complexWiresIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                    if (strikes != 1)
                    {
                        wrongSound.SetActive(true);
                    }
                }
            }
        }
    }
}