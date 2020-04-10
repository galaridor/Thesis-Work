using UnityEngine;
using TMPro;

public class SymbolsModuleLevel01Script : MonoBehaviour
{
    public GameObject wrongSound;
    public GameObject correctSound;

    [SerializeField]
    private int counter = 0;

    private int bombIndex;

    private int strikes;

    [SerializeField]
    private int numberOfModules = 0;

    public GameObject symbolsIndicator;

    public Material indicatorPassed;

    public Material indicatorStrike;

    public Material defaultMaterial;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public GameObject Symbol01;
    public GameObject Symbol02;
    public GameObject Symbol03;
    public GameObject Symbol04;

    public GameObject Symbol01Indicator;
    public GameObject Symbol02Indicator;
    public GameObject Symbol03Indicator;
    public GameObject Symbol04Indicator;

    public TextMeshProUGUI strikesText;

    public Light symbolsIndicatorLight;

    public void OnMouseEnter()
    {
        GameObject theGM = GameObject.Find("GameManagerLevel01");
        GameManagerLevel01 gm = theGM.GetComponent<GameManagerLevel01>();

        if (gm.symbolsFinal == false)
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
        PlayerPrefs.SetInt("symbolsCounter", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("numberOfModules", 0);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        if (symbolsIndicator.GetComponent<MeshRenderer>().material.color == new Color32(255, 0, 0, 255) || symbolsIndicator.GetComponent<MeshRenderer>().material.color == new Color32(0, 255, 0, 255) && symbolsIndicatorLight.enabled == false)
        {
            symbolsIndicatorLight.enabled = true;
        }
    }

    private void ResetCollider()
    {
        (Symbol01.GetComponent(typeof(BoxCollider)) as Collider).enabled = true;
        (Symbol02.GetComponent(typeof(BoxCollider)) as Collider).enabled = true;
        (Symbol03.GetComponent(typeof(BoxCollider)) as Collider).enabled = true;
        (Symbol04.GetComponent(typeof(BoxCollider)) as Collider).enabled = true;
    }

    public void OnMouseDown()
    {
        numberOfModules = PlayerPrefs.GetInt("numberOfModules");
        counter = PlayerPrefs.GetInt("symbolsCounter");
        correctSound.SetActive(false);
        wrongSound.SetActive(false);

        if (PlayerPrefs.GetString("started") == "False")
        {
            PlayerPrefs.SetString("started", "True");
            PlayerPrefs.Save();
        }

        GameObject theGM = GameObject.Find("GameManagerLevel01");
        GameManagerLevel01 gm = theGM.GetComponent<GameManagerLevel01>();

        bombIndex = gm.bombIndex;

        strikes = gm.levelOneStrikes;

        if (bombIndex == 1)
        {
            if (gm.symbolsFinal == false)
            {
                if (strikes == 0)
                {
                    if (this.gameObject.name == "Symbol01")
                    {
                        if (counter == 3)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol01.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol02")
                    {
                        if (counter == 1)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol02.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol03")
                    {
                        if (counter == 0)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol03.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol04")
                    {
                        if (counter == 2)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol04.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                }
                else if(strikes == 1)
                {
                    if (this.gameObject.name == "Symbol01")
                    {
                        if (counter == 0)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol01.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol02")
                    {
                        if (counter == 1)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol02.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                        PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                        PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol03")
                    {
                        if (counter == 3)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol03.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol04")
                    {
                        if (counter == 2)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol04.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                }
                else if(strikes == 2)
                {               
                    if (this.gameObject.name == "Symbol01")
                    {
                        if (counter == 3)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol01.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol02")
                    {
                        if (counter == 2)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol02.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol03")
                    {
                        if (counter == 1)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol03.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol04")
                    {
                        if (counter == 0)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol04.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                }
            }
        }
        else if (bombIndex == 2)
        {
            if (gm.symbolsFinal == false)
            {
                if (strikes == 0)
                {
                    if (this.gameObject.name == "Symbol01")
                    {
                        if (counter == 1)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol01.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol02")
                    {
                        if (counter == 2)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol02.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol03")
                    {
                        if (counter == 3)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol03.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol04")
                    {
                        if (counter == 0)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol04.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                }
                else if (strikes == 1)
                {
                    if (this.gameObject.name == "Symbol01")
                    {
                        if (counter == 3)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol01.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol02")
                    {
                        if (counter == 1)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol02.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol03")
                    {
                        if (counter == 0)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol03.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol04")
                    {
                        if (counter == 2)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol04.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                }
                else if (strikes == 2)
                {

                    if (this.gameObject.name == "Symbol01")
                    {
                        if (counter == 0)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol01.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol02")
                    {
                        if (counter == 3)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol02.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol03")
                    {
                        if (counter == 2)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol03.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol04")
                    {
                        if (counter == 1)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol04.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                }
            }
        }
        else if (bombIndex == 3)
        {
            if (gm.symbolsFinal == false)
            {
                if (strikes == 0)
                {
                    if (this.gameObject.name == "Symbol01")
                    {
                        if (counter == 1)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol01.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol02")
                    {
                        if (counter == 0)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol02.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol03")
                    {
                        if (counter == 3)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol03.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol04")
                    {
                        if (counter == 2)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol04.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                }
                else if (strikes == 1)
                {
                    if (this.gameObject.name == "Symbol01")
                    {
                        if (counter == 0)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol01.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol02")
                    {
                        if (counter == 1)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol02.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol03")
                    {
                        if (counter == 3)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol03.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol04")
                    {
                        if (counter == 2)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol04.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                }
                else if (strikes == 2)
                {

                    if (this.gameObject.name == "Symbol01")
                    {
                        if (counter == 3)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol01.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol02")
                    {
                        if (counter == 1)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol02.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol03")
                    {
                        if (counter == 2)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol03.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                    else if (this.gameObject.name == "Symbol04")
                    {
                        if (counter == 0)
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            counter++;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            (Symbol04.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;
                        }
                        else
                        {
                            Symbol04Indicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            Symbol02Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol01Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            Symbol03Indicator.GetComponent<MeshRenderer>().material = defaultMaterial;
                            ResetCollider();
                            counter = 0;
                            PlayerPrefs.SetInt("symbolsCounter", counter);
                            PlayerPrefs.Save();
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                        if (counter == 4)
                        {
                            symbolsIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                            gm.symbolsFinal = true;
                            numberOfModules++;
                            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                            PlayerPrefs.Save();
                            if (numberOfModules != 4)
                            {
                                correctSound.SetActive(true);
                            }
                        }
                    }
                }
            }
        }
    }
}