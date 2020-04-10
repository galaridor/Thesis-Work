using UnityEngine;
using TMPro;

public class SimonSaysModuleLevel02Script : MonoBehaviour
{
    public GameObject wrongSound;
    public GameObject correctSound;

    private int bombIndex;

    private int strikes;
    
    [SerializeField]
    private int counter = 0;

    public GameObject simonSays01;
    public GameObject simonSays02;
    public GameObject simonSays03;
    public GameObject simonSays04;

    public GameObject phase01;
    public GameObject phase02;
    public GameObject phase03;

    [SerializeField]
    private int numberOfModules = 0;

    public GameObject simonSaysIndicator;

    public Material indicatorPassed;

    public Material indicatorStrike;

    public Material defaultMaterial;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public TextMeshProUGUI strikesText;

    public Light simonSaysIndicatorLight;

    public void OnMouseEnter()
    {
        GameObject theGM = GameObject.Find("GameManagerLevel02");
        GameManagerLevel02 gm = theGM.GetComponent<GameManagerLevel02>();

        if (gm.simonSaysFinal == false)
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
        PlayerPrefs.SetInt("simonSaysCounter", 0);
        PlayerPrefs.Save();
        GameObject theGM = GameObject.Find("GameManagerLevel02");
        GameManagerLevel02 gm = theGM.GetComponent<GameManagerLevel02>();

        if (gm.bombIndex == 1)
        {
            simonSays01.GetComponent<MeshRenderer>().material.color = new Color32(0, 0, 255, 255);
        }
        else if(gm.bombIndex == 2)
        {
            simonSays02.GetComponent<MeshRenderer>().material.color = new Color32(255, 0, 0, 255);
        }
        else if (gm.bombIndex == 3)
        {
            simonSays04.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, 255);
        }
    }

    private void Update()
    {
        if (simonSaysIndicator.GetComponent<MeshRenderer>().material.color == new Color32(255, 0, 0, 255) || simonSaysIndicator.GetComponent<MeshRenderer>().material.color == new Color32(0, 255, 0, 255) && simonSaysIndicatorLight.enabled == false)
        {
            simonSaysIndicatorLight.enabled = true;
        }
    }

    public void OnMouseDown()
    { 
        numberOfModules = PlayerPrefs.GetInt("numberOfModules");
        counter = PlayerPrefs.GetInt("simonSaysCounter");
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
            if (gm.simonSaysFinal == false)
            {
                if (counter == 0)
                {
                    if (gm.levelTwoTimeLeft < 240.0f && gm.levelTwoTimeLeft > 180.0f)
                    {
                        if (this.gameObject.name == "SimonSays03") 
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays03.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if(gm.levelTwoTimeLeft < 180.0f && gm.levelTwoTimeLeft > 120.0f)
                    {
                        if (this.gameObject.name == "SimonSays02")
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays03.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 120.0f && gm.levelTwoTimeLeft > 60.0f)
                    {
                        if (this.gameObject.name == "SimonSays03")
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays03.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 60.0f)
                    {
                        if (this.gameObject.name == "SimonSays04")
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays03.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                }
                else if(counter == 1)
                {
                    if (gm.levelTwoTimeLeft < 240.0f && gm.levelTwoTimeLeft > 180.0f)
                    {
                        if (this.gameObject.name == "SimonSays03")
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays01.GetComponent<MeshRenderer>().material.color = new Color32(255, 0, 0, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays01.GetComponent<MeshRenderer>().material.color = new Color32(0, 0, 255, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 180.0f && gm.levelTwoTimeLeft > 120.0f)
                    {
                        if (this.gameObject.name == "SimonSays04")
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays01.GetComponent<MeshRenderer>().material.color = new Color32(255, 0, 0, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays01.GetComponent<MeshRenderer>().material.color = new Color32(0, 0, 255, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 120.0f && gm.levelTwoTimeLeft > 60.0f)
                    {
                        if (this.gameObject.name == "SimonSays03")
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays01.GetComponent<MeshRenderer>().material.color = new Color32(255, 0, 0, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays01.GetComponent<MeshRenderer>().material.color = new Color32(0, 0, 255, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 60.0f)
                    {
                        if (this.gameObject.name == "SimonSays02")
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays01.GetComponent<MeshRenderer>().material.color = new Color32(255, 0, 0, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays01.GetComponent<MeshRenderer>().material.color = new Color32(0, 0, 255, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                }
                else if(counter == 2)
                {
                    if (gm.levelTwoTimeLeft < 240.0f && gm.levelTwoTimeLeft > 180.0f)
                    {
                        if (this.gameObject.name == "SimonSays02")
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                            if (PlayerPrefs.GetInt("simonSaysCounter") == 3)
                            {
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                                simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                                gm.simonSaysFinal = true;
                                numberOfModules++;
                                PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                                PlayerPrefs.Save();
                                if (numberOfModules != 5)
                                {
                                    correctSound.SetActive(true);
                                }
                            }
                        }
                        else
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            phase02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays01.GetComponent<MeshRenderer>().material.color = new Color32(0, 0, 255, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 180.0f && gm.levelTwoTimeLeft > 120.0f)
                    {
                        if (this.gameObject.name == "SimonSays04")
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                            if (PlayerPrefs.GetInt("simonSaysCounter") == 3)
                            {
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                                simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                                gm.simonSaysFinal = true;
                                numberOfModules++;
                                PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                                PlayerPrefs.Save();
                                if (numberOfModules != 5)
                                {
                                    correctSound.SetActive(true);
                                }
                            }
                        }
                        else
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            phase02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays01.GetComponent<MeshRenderer>().material.color = new Color32(0, 0, 255, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 120.0f && gm.levelTwoTimeLeft > 60.0f)
                    {
                        if (this.gameObject.name == "SimonSays01")
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                            if (PlayerPrefs.GetInt("simonSaysCounter") == 3)
                            {
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                                simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                                gm.simonSaysFinal = true;
                                numberOfModules++;
                                PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                                PlayerPrefs.Save();
                                if (numberOfModules != 5)
                                {
                                    correctSound.SetActive(true);
                                }
                            }
                        }
                        else
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            phase02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays01.GetComponent<MeshRenderer>().material.color = new Color32(0, 0, 255, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 60.0f)
                    {
                        if (this.gameObject.name == "SimonSays02")
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                            if (PlayerPrefs.GetInt("simonSaysCounter") == 3)
                            {
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                                simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                                gm.simonSaysFinal = true;
                                numberOfModules++;
                                PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                                PlayerPrefs.Save();
                                if (numberOfModules != 5)
                                {
                                    correctSound.SetActive(true);
                                }
                            }
                        }
                        else
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            phase02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays01.GetComponent<MeshRenderer>().material.color = new Color32(0, 0, 255, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                }
            }
        }
        else if (bombIndex == 2)
        {
            if (gm.simonSaysFinal == false)
            {
                if (counter == 0)
                {
                    if (gm.levelTwoTimeLeft < 240.0f && gm.levelTwoTimeLeft > 180.0f)
                    {
                        if (this.gameObject.name == "SimonSays02")
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material.color = new Color32(0, 0, 255, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 180.0f && gm.levelTwoTimeLeft > 120.0f)
                    {
                        if (this.gameObject.name == "SimonSays01")
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material.color = new Color32(0, 0, 255, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 120.0f && gm.levelTwoTimeLeft > 60.0f)
                    {
                        if (this.gameObject.name == "SimonSays03")
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material.color = new Color32(0, 0, 255, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 60.0f)
                    {
                        if (this.gameObject.name == "SimonSays02")
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material.color = new Color32(0, 0, 255, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                }
                else if (counter == 1)
                {
                    if (gm.levelTwoTimeLeft < 240.0f && gm.levelTwoTimeLeft > 180.0f)
                    {
                        if (this.gameObject.name == "SimonSays02")
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material.color = new Color32(255, 0, 0, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 180.0f && gm.levelTwoTimeLeft > 120.0f)
                    {
                        if (this.gameObject.name == "SimonSays01")
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material.color = new Color32(255, 0, 0, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 120.0f && gm.levelTwoTimeLeft > 60.0f)
                    {
                        if (this.gameObject.name == "SimonSays04")
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material.color = new Color32(255, 0, 0, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 60.0f)
                    {
                        if (this.gameObject.name == "SimonSays04")
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material.color = new Color32(255, 0, 0, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                }
                else if (counter == 2)
                {
                    if (gm.levelTwoTimeLeft < 240.0f && gm.levelTwoTimeLeft > 180.0f)
                    {
                        if (this.gameObject.name == "SimonSays01")
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                            if (PlayerPrefs.GetInt("simonSaysCounter") == 3)
                            {
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                                simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                                gm.simonSaysFinal = true;
                                numberOfModules++;
                                PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                                PlayerPrefs.Save();
                                if (numberOfModules != 5)
                                {
                                    correctSound.SetActive(true);
                                }
                            }
                        }
                        else
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            phase02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material.color = new Color32(255, 0, 0, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 180.0f && gm.levelTwoTimeLeft > 120.0f)
                    {
                        if (this.gameObject.name == "SimonSays01")
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                            if (PlayerPrefs.GetInt("simonSaysCounter") == 3)
                            {
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                                simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                                gm.simonSaysFinal = true;
                                numberOfModules++;
                                PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                                PlayerPrefs.Save();
                                if (numberOfModules != 5)
                                {
                                    correctSound.SetActive(true);
                                }
                            }
                        }
                        else
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            phase02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material.color = new Color32(255, 0, 0, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 120.0f && gm.levelTwoTimeLeft > 60.0f)
                    {
                        if (this.gameObject.name == "SimonSays02")
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                            if (PlayerPrefs.GetInt("simonSaysCounter") == 3)
                            {
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                                simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                                gm.simonSaysFinal = true;
                                numberOfModules++;
                                PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                                PlayerPrefs.Save();
                                if (numberOfModules != 5)
                                {
                                    correctSound.SetActive(true);
                                }
                            }
                        }
                        else
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            phase02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material.color = new Color32(255, 0, 0, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 60.0f)
                    {
                        if (this.gameObject.name == "SimonSays04")
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                            if (PlayerPrefs.GetInt("simonSaysCounter") == 3)
                            {
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                                simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                                gm.simonSaysFinal = true;
                                numberOfModules++;
                                PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                                PlayerPrefs.Save();
                                if (numberOfModules != 5)
                                {
                                    correctSound.SetActive(true);
                                }
                            }
                        }
                        else
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            phase02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays02.GetComponent<MeshRenderer>().material.color = new Color32(255, 0, 0, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                }
            }
        }
        else if (bombIndex == 3)
        {
            if (gm.simonSaysFinal == false)
            {
                if (counter == 0)
                {
                    if (gm.levelTwoTimeLeft < 240.0f && gm.levelTwoTimeLeft > 180.0f)
                    {
                        if (this.gameObject.name == "SimonSays01")
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays04.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays04.GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 0, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 180.0f && gm.levelTwoTimeLeft > 120.0f)
                    {
                        if (this.gameObject.name == "SimonSays04")
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays04.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays04.GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 0, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 120.0f && gm.levelTwoTimeLeft > 60.0f)
                    {
                        if (this.gameObject.name == "SimonSays02")
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays04.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays04.GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 0, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 60.0f)
                    {
                        if (this.gameObject.name == "SimonSays02")
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays04.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays04.GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 0, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase01.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                }
                else if (counter == 1)
                {
                    if (gm.levelTwoTimeLeft < 240.0f && gm.levelTwoTimeLeft > 180.0f)
                    {
                        if (this.gameObject.name == "SimonSays01")
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays04.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays03.GetComponent<MeshRenderer>().material.color = new Color32(255, 0, 0, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays04.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays04.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 180.0f && gm.levelTwoTimeLeft > 120.0f)
                    {
                        if (this.gameObject.name == "SimonSays01")
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays04.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays03.GetComponent<MeshRenderer>().material.color = new Color32(255, 0, 0, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays04.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays04.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 120.0f && gm.levelTwoTimeLeft > 60.0f)
                    {
                        if (this.gameObject.name == "SimonSays02")
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays04.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays03.GetComponent<MeshRenderer>().material.color = new Color32(255, 0, 0, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays04.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays04.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 60.0f)
                    {
                        if (this.gameObject.name == "SimonSays02")
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays04.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays03.GetComponent<MeshRenderer>().material.color = new Color32(255, 0, 0, 255);
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            phase02.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays04.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays04.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                }
                else if (counter == 2)
                {
                    if (gm.levelTwoTimeLeft < 240.0f && gm.levelTwoTimeLeft > 180.0f)
                    {
                        if (this.gameObject.name == "SimonSays02")
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                            if (PlayerPrefs.GetInt("simonSaysCounter") == 3)
                            {
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                                simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                                gm.simonSaysFinal = true;
                                numberOfModules++;
                                PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                                PlayerPrefs.Save();
                                if (numberOfModules != 5)
                                {
                                    correctSound.SetActive(true);
                                }
                            }
                        }
                        else
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            phase02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays04.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 180.0f && gm.levelTwoTimeLeft > 120.0f)
                    {
                        if (this.gameObject.name == "SimonSays04")
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                            if (PlayerPrefs.GetInt("simonSaysCounter") == 3)
                            {
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                                simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                                gm.simonSaysFinal = true;
                                numberOfModules++;
                                PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                                PlayerPrefs.Save();
                                if (numberOfModules != 5)
                                {
                                    correctSound.SetActive(true);
                                }
                            }
                        }
                        else
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            phase02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays04.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 120.0f && gm.levelTwoTimeLeft > 60.0f)
                    {
                        if (this.gameObject.name == "SimonSays01")
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                            if (PlayerPrefs.GetInt("simonSaysCounter") == 3)
                            {
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                                simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                                gm.simonSaysFinal = true;
                                numberOfModules++;
                                PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                                PlayerPrefs.Save();
                                if (numberOfModules != 5)
                                {
                                    correctSound.SetActive(true);
                                }
                            }
                        }
                        else
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            phase02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays04.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                    else if (gm.levelTwoTimeLeft < 60.0f)
                    {
                        if (this.gameObject.name == "SimonSays02")
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorPassed;
                            counter++;
                            simonSays03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            PlayerPrefs.Save();
                            if (PlayerPrefs.GetInt("simonSaysCounter") == 3)
                            {
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                                simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
                                gm.simonSaysFinal = true;
                                numberOfModules++;
                                PlayerPrefs.SetInt("numberOfModules", numberOfModules);
                                PlayerPrefs.Save();
                                if (numberOfModules != 5)
                                {
                                    correctSound.SetActive(true);
                                }
                            }
                        }
                        else
                        {
                            phase03.GetComponent<MeshRenderer>().material = indicatorStrike;
                            simonSaysIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
                            phase01.GetComponent<MeshRenderer>().material = defaultMaterial;
                            phase02.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays03.GetComponent<MeshRenderer>().material = defaultMaterial;
                            simonSays04.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, 255);
                            counter = 0;
                            PlayerPrefs.SetInt("simonSaysCounter", counter);
                            gm.levelTwoStrikes++;
                            strikesText.text = "STRIKES: " + gm.levelTwoStrikes.ToString();
                            if (strikes != 1)
                            {
                                wrongSound.SetActive(true);
                            }
                        }
                    }
                }
            }
        }
    }
}