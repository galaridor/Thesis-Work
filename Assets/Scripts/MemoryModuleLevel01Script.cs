using UnityEngine;
using TMPro;

public class MemoryModuleLevel01Script : MonoBehaviour
{
    public GameObject wrongSound;
    public GameObject correctSound;

    [SerializeField]
    private int counter = 0;

    private int bombIndex;

    private int strikes;

    [SerializeField]
    private int numberOfModules = 0;

    public GameObject memoryIndicator;

    public Material indicatorPassed;

    public Material indicatorStrike;

    public Material defaultMaterial;

    public Material numberOne;
    public Material numberTwo;
    public Material numberThree;
    public Material numberFour;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public GameObject button01;
    public GameObject button02;
    public GameObject button03;
    public GameObject button04;

    public GameObject display;

    public GameObject stage01;
    public GameObject stage02;
    public GameObject stage03;

    public TextMeshProUGUI strikesText;

    public Light memoryIndicatorLight;

    private void Start()
    {
        PlayerPrefs.SetInt("memoryCounter", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("numberOfModules", 0);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        if (memoryIndicator.GetComponent<MeshRenderer>().material.color == new Color32(255, 0, 0, 255) || memoryIndicator.GetComponent<MeshRenderer>().material.color == new Color32(0, 255, 0, 255) && memoryIndicatorLight.enabled == false)
        {
            memoryIndicatorLight.enabled = true;
        }
    }

    public void OnMouseEnter()
    {
        GameObject theGM = GameObject.Find("GameManagerLevel01");
        GameManagerLevel01 gm = theGM.GetComponent<GameManagerLevel01>();

        if (gm.memoryFinal == false)
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

    private void ResetAll()
    {
        display.GetComponent<MeshRenderer>().material = defaultMaterial;
        button01.GetComponent<MeshRenderer>().material = defaultMaterial;
        button02.GetComponent<MeshRenderer>().material = defaultMaterial;
        button03.GetComponent<MeshRenderer>().material = defaultMaterial;
        button04.GetComponent<MeshRenderer>().material = defaultMaterial;
    }

    private void DefaultValues()
    {
        GameObject theGM = GameObject.Find("GameManagerLevel01");
        GameManagerLevel01 gm = theGM.GetComponent<GameManagerLevel01>();

        bombIndex = gm.bombIndex;

        if (bombIndex == 1)
        {
            display.GetComponent<MeshRenderer>().material = numberTwo;
            button01.GetComponent<MeshRenderer>().material = numberOne;
            button02.GetComponent<MeshRenderer>().material = numberFour;
            button03.GetComponent<MeshRenderer>().material = numberThree;
            button04.GetComponent<MeshRenderer>().material = numberTwo;
        }
        else if(bombIndex == 2)
        {
            display.GetComponent<MeshRenderer>().material = numberFour;
            button01.GetComponent<MeshRenderer>().material = numberFour;
            button02.GetComponent<MeshRenderer>().material = numberTwo;
            button03.GetComponent<MeshRenderer>().material = numberOne;
            button04.GetComponent<MeshRenderer>().material = numberThree;
        }
        else if (bombIndex == 3)
        {
            display.GetComponent<MeshRenderer>().material = numberThree;
            button01.GetComponent<MeshRenderer>().material = numberTwo;
            button02.GetComponent<MeshRenderer>().material = numberOne;
            button03.GetComponent<MeshRenderer>().material = numberThree;
            button04.GetComponent<MeshRenderer>().material = numberFour;
        }
    }

    public void OnMouseDown()
    {
        numberOfModules = PlayerPrefs.GetInt("numberOfModules");
        counter = PlayerPrefs.GetInt("memoryCounter");
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
            if (gm.memoryFinal == false)
            {
                if (strikes == 0)
                {
                    if (counter == 0)
                    {
                        if (this.gameObject.name == "Button01")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage01.GetComponent<MeshRenderer>().material = indicatorPassed;
                            display.GetComponent<MeshRenderer>().material = numberThree;
                            button01.GetComponent<MeshRenderer>().material = numberThree;
                            button02.GetComponent<MeshRenderer>().material = numberTwo;
                            button03.GetComponent<MeshRenderer>().material = numberOne;
                            button04.GetComponent<MeshRenderer>().material = numberFour;

                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage01.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                    else if (counter == 1)
                    {
                        if (this.gameObject.name == "Button01")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage02.GetComponent<MeshRenderer>().material = indicatorPassed;
                            display.GetComponent<MeshRenderer>().material = numberFour;
                            button01.GetComponent<MeshRenderer>().material = numberTwo;
                            button02.GetComponent<MeshRenderer>().material = numberThree;
                            button03.GetComponent<MeshRenderer>().material = numberFour;
                            button04.GetComponent<MeshRenderer>().material = numberOne;
                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage02.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            stage01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            stage03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                    else if (counter == 2)
                    {
                        if (this.gameObject.name == "Button02")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage03.GetComponent<MeshRenderer>().material = indicatorPassed;
                            ResetAll();
                            if (counter == 3)
                            {
                                numberOfModules++;
                                PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                                PlayerPrefs.Save();
                                Cursor.SetCursor(null, Vector2.zero, cursorMode);
                                memoryIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                                gm.memoryFinal = true;
                                if (numberOfModules != 4)
                                {
                                    correctSound.SetActive(true);
                                }

                            }
                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage03.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            stage01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            stage02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                }
                else if (strikes == 1)
                {
                    if (counter == 0)
                    {
                        if (this.gameObject.name == "Button04")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage01.GetComponent<MeshRenderer>().material = indicatorPassed;
                            display.GetComponent<MeshRenderer>().material = numberOne;
                            button01.GetComponent<MeshRenderer>().material = numberThree;
                            button02.GetComponent<MeshRenderer>().material = numberTwo;
                            button03.GetComponent<MeshRenderer>().material = numberFour;
                            button04.GetComponent<MeshRenderer>().material = numberOne;

                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage01.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                    else if (counter == 1)
                    {
                        if (this.gameObject.name == "Button04")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage02.GetComponent<MeshRenderer>().material = indicatorPassed;
                            display.GetComponent<MeshRenderer>().material = numberTwo;
                            button01.GetComponent<MeshRenderer>().material = numberFour;
                            button02.GetComponent<MeshRenderer>().material = numberThree;
                            button03.GetComponent<MeshRenderer>().material = numberTwo;
                            button04.GetComponent<MeshRenderer>().material = numberOne;
                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage02.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            stage01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            stage03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                    else if (counter == 2)
                    {
                        if (this.gameObject.name == "Button04")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage03.GetComponent<MeshRenderer>().material = indicatorPassed;
                            ResetAll();
                            if (counter == 3)
                            {
                                numberOfModules++;
                                PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                                PlayerPrefs.Save();
                                Cursor.SetCursor(null, Vector2.zero, cursorMode);
                                memoryIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                                gm.memoryFinal = true;
                                if (numberOfModules != 4)
                                {
                                    correctSound.SetActive(true);
                                }
                            }
                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage03.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            stage01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            stage02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                }
                else if (strikes == 2)
                {
                    if (counter == 0)
                    {
                        if (this.gameObject.name == "Button01")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage01.GetComponent<MeshRenderer>().material = indicatorPassed;
                            display.GetComponent<MeshRenderer>().material = numberTwo;
                            button01.GetComponent<MeshRenderer>().material = numberOne;
                            button02.GetComponent<MeshRenderer>().material = numberFour;
                            button03.GetComponent<MeshRenderer>().material = numberTwo;
                            button04.GetComponent<MeshRenderer>().material = numberThree;

                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage01.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                    else if (counter == 1)
                    {
                        if (this.gameObject.name == "Button02")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage02.GetComponent<MeshRenderer>().material = indicatorPassed;
                            display.GetComponent<MeshRenderer>().material = numberOne;
                            button01.GetComponent<MeshRenderer>().material = numberOne;
                            button02.GetComponent<MeshRenderer>().material = numberTwo;
                            button03.GetComponent<MeshRenderer>().material = numberThree;
                            button04.GetComponent<MeshRenderer>().material = numberFour;
                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage02.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            stage01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            stage03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                    else if (counter == 2)
                    {
                        if (this.gameObject.name == "Button04")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage03.GetComponent<MeshRenderer>().material = indicatorPassed;
                            ResetAll();
                            if (counter == 3)
                            {
                                numberOfModules++;
                                PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                                PlayerPrefs.Save();
                                Cursor.SetCursor(null, Vector2.zero, cursorMode);
                                memoryIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                                gm.memoryFinal = true;
                                if (numberOfModules != 4)
                                {
                                    correctSound.SetActive(true);
                                }
                            }
                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage03.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            stage01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            stage02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                }
            }
        }
        else if (bombIndex == 2)
        {
            if (gm.memoryFinal == false)
            {
                if (strikes == 0)
                {
                    if (counter == 0)
                    {
                        if (this.gameObject.name == "Button04")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage01.GetComponent<MeshRenderer>().material = indicatorPassed;
                            display.GetComponent<MeshRenderer>().material = numberFour;
                            button01.GetComponent<MeshRenderer>().material = numberFour;
                            button02.GetComponent<MeshRenderer>().material = numberTwo;
                            button03.GetComponent<MeshRenderer>().material = numberOne;
                            button04.GetComponent<MeshRenderer>().material = numberThree;

                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage01.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                    else if (counter == 1)
                    {
                        if (this.gameObject.name == "Button01")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage02.GetComponent<MeshRenderer>().material = indicatorPassed;
                            display.GetComponent<MeshRenderer>().material = numberOne;
                            button01.GetComponent<MeshRenderer>().material = numberFour;
                            button02.GetComponent<MeshRenderer>().material = numberThree;
                            button03.GetComponent<MeshRenderer>().material = numberOne;
                            button04.GetComponent<MeshRenderer>().material = numberTwo;
                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage02.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            stage01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            stage03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                    else if (counter == 2)
                    {
                        if (this.gameObject.name == "Button01")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage03.GetComponent<MeshRenderer>().material = indicatorPassed;
                            ResetAll();
                            if (counter == 3)
                            {
                                numberOfModules++;
                                PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                                PlayerPrefs.Save();
                                Cursor.SetCursor(null, Vector2.zero, cursorMode);
                                memoryIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                                gm.memoryFinal = true;
                                if (numberOfModules != 4)
                                {
                                    correctSound.SetActive(true);
                                }
                            }
                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage03.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            stage01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            stage02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                }
                else if (strikes == 1)
                {
                    if (counter == 0)
                    {
                        if (this.gameObject.name == "Button02")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage01.GetComponent<MeshRenderer>().material = indicatorPassed;
                            display.GetComponent<MeshRenderer>().material = numberThree;
                            button01.GetComponent<MeshRenderer>().material = numberThree;
                            button02.GetComponent<MeshRenderer>().material = numberOne;
                            button03.GetComponent<MeshRenderer>().material = numberFour;
                            button04.GetComponent<MeshRenderer>().material = numberTwo;

                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage01.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                    else if (counter == 1)
                    {
                        if (this.gameObject.name == "Button02")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage02.GetComponent<MeshRenderer>().material = indicatorPassed;
                            display.GetComponent<MeshRenderer>().material = numberTwo;
                            button01.GetComponent<MeshRenderer>().material = numberThree;
                            button02.GetComponent<MeshRenderer>().material = numberOne;
                            button03.GetComponent<MeshRenderer>().material = numberFour;
                            button04.GetComponent<MeshRenderer>().material = numberTwo;
                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage02.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            stage01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            stage03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                    else if (counter == 2)
                    {
                        if (this.gameObject.name == "Button04")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage03.GetComponent<MeshRenderer>().material = indicatorPassed;
                            ResetAll();
                            if (counter == 3)
                            {
                                numberOfModules++;
                                PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                                PlayerPrefs.Save();
                                Cursor.SetCursor(null, Vector2.zero, cursorMode);
                                memoryIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                                gm.memoryFinal = true;
                                if (numberOfModules != 4)
                                {
                                    correctSound.SetActive(true);
                                }
                            }
                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage03.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            stage01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            stage02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                }
                else if (strikes == 2)
                {
                    if (counter == 0)
                    {
                        if (this.gameObject.name == "Button03")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage01.GetComponent<MeshRenderer>().material = indicatorPassed;
                            display.GetComponent<MeshRenderer>().material = numberOne;
                            button01.GetComponent<MeshRenderer>().material = numberFour;
                            button02.GetComponent<MeshRenderer>().material = numberTwo;
                            button03.GetComponent<MeshRenderer>().material = numberThree;
                            button04.GetComponent<MeshRenderer>().material = numberOne;

                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage01.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                    else if (counter == 1)
                    {
                        if (this.gameObject.name == "Button04")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage02.GetComponent<MeshRenderer>().material = indicatorPassed;
                            display.GetComponent<MeshRenderer>().material = numberThree;
                            button01.GetComponent<MeshRenderer>().material = numberOne;
                            button02.GetComponent<MeshRenderer>().material = numberTwo;
                            button03.GetComponent<MeshRenderer>().material = numberFour;
                            button04.GetComponent<MeshRenderer>().material = numberThree;
                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage02.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            stage01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            stage03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                    else if (counter == 2)
                    {
                        if (this.gameObject.name == "Button02")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage03.GetComponent<MeshRenderer>().material = indicatorPassed;
                            ResetAll();
                            if (counter == 3)
                            {
                                numberOfModules++;
                                PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                                PlayerPrefs.Save();
                                Cursor.SetCursor(null, Vector2.zero, cursorMode);
                                memoryIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                                gm.memoryFinal = true;
                                if (numberOfModules != 4)
                                {
                                    correctSound.SetActive(true);
                                }
                            }
                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage03.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            stage01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            stage02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                }
            }
        }
        else if (bombIndex == 3)
        {
            if (gm.memoryFinal == false)
            {
                if (strikes == 0)
                {
                    if (counter == 0)
                    {
                        if (this.gameObject.name == "Button03")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage01.GetComponent<MeshRenderer>().material = indicatorPassed;
                            display.GetComponent<MeshRenderer>().material = numberTwo;
                            button01.GetComponent<MeshRenderer>().material = numberFour;
                            button02.GetComponent<MeshRenderer>().material = numberTwo;
                            button03.GetComponent<MeshRenderer>().material = numberThree;
                            button04.GetComponent<MeshRenderer>().material = numberOne;

                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage01.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                    else if (counter == 1)
                    {
                        if (this.gameObject.name == "Button04")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage02.GetComponent<MeshRenderer>().material = indicatorPassed;
                            display.GetComponent<MeshRenderer>().material = numberThree;
                            button01.GetComponent<MeshRenderer>().material = numberThree;
                            button02.GetComponent<MeshRenderer>().material = numberFour;
                            button03.GetComponent<MeshRenderer>().material = numberTwo;
                            button04.GetComponent<MeshRenderer>().material = numberOne;
                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage02.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            stage01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            stage03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                    else if (counter == 2)
                    {
                        if (this.gameObject.name == "Button02")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage03.GetComponent<MeshRenderer>().material = indicatorPassed;
                            ResetAll();
                            if (counter == 3)
                            {
                                numberOfModules++;
                                PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                                PlayerPrefs.Save();
                                Cursor.SetCursor(null, Vector2.zero, cursorMode);
                                memoryIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                                gm.memoryFinal = true;
                                if (numberOfModules != 4)
                                {
                                    correctSound.SetActive(true);
                                }
                            }
                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage03.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            stage01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            stage02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                }
                else if (strikes == 1)
                {
                    if (counter == 0)
                    {
                        if (this.gameObject.name == "Button03")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage01.GetComponent<MeshRenderer>().material = indicatorPassed;
                            display.GetComponent<MeshRenderer>().material = numberFour;
                            button01.GetComponent<MeshRenderer>().material = numberThree;
                            button02.GetComponent<MeshRenderer>().material = numberTwo;
                            button03.GetComponent<MeshRenderer>().material = numberFour;
                            button04.GetComponent<MeshRenderer>().material = numberOne;

                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage01.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                    else if (counter == 1)
                    {
                        if (this.gameObject.name == "Button01")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage02.GetComponent<MeshRenderer>().material = indicatorPassed;
                            display.GetComponent<MeshRenderer>().material = numberTwo;
                            button01.GetComponent<MeshRenderer>().material = numberOne;
                            button02.GetComponent<MeshRenderer>().material = numberTwo;
                            button03.GetComponent<MeshRenderer>().material = numberThree;
                            button04.GetComponent<MeshRenderer>().material = numberFour;
                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage02.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            stage01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            stage03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                    else if (counter == 2)
                    {
                        if (this.gameObject.name == "Button04")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage03.GetComponent<MeshRenderer>().material = indicatorPassed;
                            ResetAll();
                            if (counter == 3)
                            {
                                numberOfModules++;
                                PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                                PlayerPrefs.Save();
                                Cursor.SetCursor(null, Vector2.zero, cursorMode);
                                memoryIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                                gm.memoryFinal = true;
                                if (numberOfModules != 4)
                                {
                                    correctSound.SetActive(true);
                                }
                            }
                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage03.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            stage01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            stage02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                }
                else if (strikes == 2)
                {
                    if (counter == 0)
                    {
                        if (this.gameObject.name == "Button02")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage01.GetComponent<MeshRenderer>().material = indicatorPassed;
                            display.GetComponent<MeshRenderer>().material = numberThree;
                            button01.GetComponent<MeshRenderer>().material = numberTwo;
                            button02.GetComponent<MeshRenderer>().material = numberFour;
                            button03.GetComponent<MeshRenderer>().material = numberThree;
                            button04.GetComponent<MeshRenderer>().material = numberOne;

                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage01.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                    else if (counter == 1)
                    {
                        if (this.gameObject.name == "Button02")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage02.GetComponent<MeshRenderer>().material = indicatorPassed;
                            display.GetComponent<MeshRenderer>().material = numberOne;
                            button01.GetComponent<MeshRenderer>().material = numberOne;
                            button02.GetComponent<MeshRenderer>().material = numberThree;
                            button03.GetComponent<MeshRenderer>().material = numberTwo;
                            button04.GetComponent<MeshRenderer>().material = numberFour;
                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage02.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            stage01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            stage03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                    else if (counter == 2)
                    {
                        if (this.gameObject.name == "Button04")
                        {
                            counter++;
                            PlayerPrefs.SetInt("memoryCounter", counter);
                            PlayerPrefs.Save();
                            stage03.GetComponent<MeshRenderer>().material = indicatorPassed;
                            ResetAll();
                            if (counter == 3)
                            {
                                numberOfModules++;
                                PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                                PlayerPrefs.Save();
                                Cursor.SetCursor(null, Vector2.zero, cursorMode);
                                memoryIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                                gm.memoryFinal = true;
                                if (numberOfModules != 4)
                                {
                                    correctSound.SetActive(true);
                                }
                            }
                        }
                        else
                        {
                            gm.levelOneStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelOneStrikes.ToString();
                            stage03.GetComponent<MeshRenderer>().material = indicatorStrike;
                            if (strikes != 2)
                            {
                                wrongSound.SetActive(true);
                            }
                            memoryIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            DefaultValues();
                            stage01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            stage02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("memoryCounter", 0);
                            PlayerPrefs.Save();
                        }
                    }
                }
            }
        }
    }
}