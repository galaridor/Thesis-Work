using System.Collections;
using UnityEngine;
using TMPro;

public class MorseCodeModuleLevel03Script : MonoBehaviour
{
    public GameObject wrongSound;
    public GameObject correctSound;

    private int bombIndex;

    private int strikes;

    [SerializeField]
    private int numberOfModules = 0;

    private bool pass = false;
    private bool fail = false;

    [SerializeField]
    private int counterNumber01 = 0;
    [SerializeField]
    private int counterNumber02 = 0;
    [SerializeField]
    private int counterNumber03 = 0;
    [SerializeField]
    private int counterNumber04 = 0;

    public GameObject morseCodeIndicator;

    public Material indicatorPassed;

    public Material indicatorStrike;

    public Material defaultMaterial;

    public Material blinkMaterial;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public GameObject wire;

    public GameObject blinker;

    public Light spotLight;

    public GameObject arrowUp01;
    public GameObject arrowUp02;
    public GameObject arrowUp03;
    public GameObject arrowUp04;
    public GameObject arrowDown01;
    public GameObject arrowDown02;
    public GameObject arrowDown03;
    public GameObject arrowDown04;

    public GameObject number01;
    public GameObject number02;
    public GameObject number03;
    public GameObject number04;

    public Material materialNumber00;
    public Material materialNumber01;
    public Material materialNumber02;
    public Material materialNumber03;
    public Material materialNumber04;
    public Material materialNumber05;
    public Material materialNumber06;
    public Material materialNumber07;
    public Material materialNumber08;
    public Material materialNumber09;

    public Material[] arr = new Material[10];

    public TextMeshProUGUI strikesText;

    public Light morseCodeIndicatorLight;

    [SerializeField] 
    private float dotTime;
    [SerializeField] 
    private string textToShow;
    private float dashTime;
    private char[] letters = { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
    private string[] morseLetters = { "    ", ". _", "_ . . .", "_ . _ .", "_ . .", ".", ". . _ .", "_ _ .", ". . . .", ". .", ". _ _ _", "_ . _", ". _ . .", "_ _", "_ .", "_ _ _", ". _ _ .", "_ _ . _", ". _ .", ". . .", "_", ". . _", ". . . _", ". _ _", "_ . . _", "_ . _ _", "_ _ . .", ". _ _ _ _", ". . _ _ _", ". . . _ _", ". . . . _", ". . . . .", "_ . . . .", "_ _ . . .", "_ _ _ . .", "_ _ _ _ .", "_ _ _ _ _" };

    public void OnMouseEnter()
    {
        GameObject theGM = GameObject.Find("GameManagerLevel03");
        GameManagerLevel03 gm = theGM.GetComponent<GameManagerLevel03>();

        if (gm.morseCodeFinal == false)
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
        GameObject theGM = GameObject.Find("GameManagerLevel03");
        GameManagerLevel03 gm = theGM.GetComponent<GameManagerLevel03>();

        if(gm.bombIndex == 1)
        {
            StartCoroutine(Flash(blinker, "lvs", 0.5f, 1.0f, 2.0f, 4.0f));
        }
        else if (gm.bombIndex == 2)
        {
            StartCoroutine(Flash(blinker, "psg", 0.5f, 1.0f, 2.0f, 4.0f));
        }
        else if (gm.bombIndex == 3)
        {
            StartCoroutine(Flash(blinker, "chfc", 0.5f, 1.0f, 2.0f, 4.0f));
        }

        PlayerPrefs.SetInt("numberOfModules", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("CounterMorseCodeNumber01", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("CounterMorseCodeNumber02", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("CounterMorseCodeNumber03", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("CounterMorseCodeNumber04", 0);
        PlayerPrefs.Save();

        arr[0] = materialNumber00;
        arr[1] = materialNumber01;
        arr[2] = materialNumber02;
        arr[3] = materialNumber03;
        arr[4] = materialNumber04;
        arr[5] = materialNumber05;
        arr[6] = materialNumber06;
        arr[7] = materialNumber07;
        arr[8] = materialNumber08;
        arr[9] = materialNumber09;
    }

    private void SwitchNumbers()
    {
        if (this.gameObject.name == "ArrowUp01")
        {
            counterNumber01++;
            if (counterNumber01 > 9)
            {
                counterNumber01 = 0;
            }
            if (counterNumber01 < 0)
            {
                counterNumber01 = 9;
            }

            PlayerPrefs.SetInt("CounterMorseCodeNumber01", counterNumber01);
            PlayerPrefs.Save();

            for (int i = 0; i < arr.Length; i++)
            {
                number01.GetComponent<MeshRenderer>().material = arr[counterNumber01];
            }
        }
        else if (this.gameObject.name == "ArrowDown01")
        {
            counterNumber01--;
            if (counterNumber01 > 9)
            {
                counterNumber01 = 0;
            }
            if (counterNumber01 < 0)
            {
                counterNumber01 = 9;
            }

            PlayerPrefs.SetInt("CounterMorseCodeNumber01", counterNumber01);
            PlayerPrefs.Save();

            for (int i = 0; i < arr.Length; i++)
            {
                number01.GetComponent<MeshRenderer>().material = arr[counterNumber01];
            }
        }

        if (this.gameObject.name == "ArrowUp02")
        {
            counterNumber02++;
            if (counterNumber02 > 9)
            {
                counterNumber02 = 0;
            }
            if (counterNumber02 < 0)
            {
                counterNumber02 = 9;
            }

            PlayerPrefs.SetInt("CounterMorseCodeNumber02", counterNumber02);
            PlayerPrefs.Save();

            for (int i = 0; i < arr.Length; i++)
            {
                number02.GetComponent<MeshRenderer>().material = arr[counterNumber02];
            }
        }
        else if (this.gameObject.name == "ArrowDown02")
        {
            counterNumber02--;
            if (counterNumber02 > 9)
            {
                counterNumber02 = 0;
            }
            if (counterNumber02 < 0)
            {
                counterNumber02 = 9;
            }

            PlayerPrefs.SetInt("CounterMorseCodeNumber02", counterNumber02);
            PlayerPrefs.Save();

            for (int i = 0; i < arr.Length; i++)
            {
                number02.GetComponent<MeshRenderer>().material = arr[counterNumber02];
            }
        }

        if (this.gameObject.name == "ArrowUp03")
        {
            counterNumber03++;
            if (counterNumber03 > 9)
            {
                counterNumber03 = 0;
            }
            if (counterNumber03 < 0)
            {
                counterNumber03 = 9;
            }

            PlayerPrefs.SetInt("CounterMorseCodeNumber03", counterNumber03);
            PlayerPrefs.Save();

            for (int i = 0; i < arr.Length; i++)
            {
                number03.GetComponent<MeshRenderer>().material = arr[counterNumber03];
            }
        }
        else if (this.gameObject.name == "ArrowDown03")
        {
            counterNumber03--;
            if (counterNumber03 > 9)
            {
                counterNumber03 = 0;
            }
            if (counterNumber03 < 0)
            {
                counterNumber03 = 9;
            }

            PlayerPrefs.SetInt("CounterMorseCodeNumber03", counterNumber03);
            PlayerPrefs.Save();

            for (int i = 0; i < arr.Length; i++)
            {
                number03.GetComponent<MeshRenderer>().material = arr[counterNumber03];
            }
        }

        if (this.gameObject.name == "ArrowUp04")
        {
            counterNumber04++;
            if (counterNumber04 > 9)
            {
                counterNumber04 = 0;
            }
            if (counterNumber04 < 0)
            {
                counterNumber04 = 9;
            }

            PlayerPrefs.SetInt("CounterMorseCodeNumber04", counterNumber04);
            PlayerPrefs.Save();

            for (int i = 0; i < arr.Length; i++)
            {
                number04.GetComponent<MeshRenderer>().material = arr[counterNumber04];
            }
        }
        else if (this.gameObject.name == "ArrowDown04")
        {
            counterNumber04--;
            if (counterNumber04 > 9)
            {
                counterNumber04 = 0;
            }
            if (counterNumber04 < 0)
            {
                counterNumber04 = 9;
            }

            PlayerPrefs.SetInt("CounterMorseCodeNumber04", counterNumber04);
            PlayerPrefs.Save();

            for (int i = 0; i < arr.Length; i++)
            {
                number04.GetComponent<MeshRenderer>().material = arr[counterNumber04];
            }
        }
    }

    private void Update()
    {
        GameObject theGM = GameObject.Find("GameManagerLevel03");
        GameManagerLevel03 gm = theGM.GetComponent<GameManagerLevel03>();

        if (gm.morseCodeFinal == false)
        {
            if (gm.bombIndex == 1)
            {
                if (gm.levelThreeTimeLeft < 144.0f && gm.levelThreeTimeLeft > 108.0f)
                {
                    wire.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, 255);
                }
                else if (gm.levelThreeTimeLeft < 108.0f && gm.levelThreeTimeLeft > 72.0f)
                {
                    wire.GetComponent<MeshRenderer>().material.color = new Color32(0, 0, 255, 255);
                }
                else if (gm.levelThreeTimeLeft < 72.0f && gm.levelThreeTimeLeft > 36.0f)
                {
                    wire.GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 0, 255);
                }
                else if (gm.levelThreeTimeLeft < 36.0f)
                {
                    wire.GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 255, 255);
                }
            }
            else if (gm.bombIndex == 2)
            {
                if (gm.levelThreeTimeLeft < 144.0f && gm.levelThreeTimeLeft > 108.0f)
                {
                    wire.GetComponent<MeshRenderer>().material.color = new Color32(0, 0, 255, 255);
                }
                else if (gm.levelThreeTimeLeft < 108.0f && gm.levelThreeTimeLeft > 72.0f)
                {
                    wire.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, 255);
                }
                else if (gm.levelThreeTimeLeft < 72.0f && gm.levelThreeTimeLeft > 36.0f)
                {
                    wire.GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 255, 255);
                }
                else if (gm.levelThreeTimeLeft < 36.0f)
                {
                    wire.GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 0, 255);
                }
            }
            else if (gm.bombIndex == 3)
            {
                if (gm.levelThreeTimeLeft < 144.0f && gm.levelThreeTimeLeft > 108.0f)
                {
                    wire.GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 255, 255);
                }
                else if (gm.levelThreeTimeLeft < 108.0f && gm.levelThreeTimeLeft > 72.0f)
                {
                    wire.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, 255);
                }
                else if (gm.levelThreeTimeLeft < 72.0f && gm.levelThreeTimeLeft > 36.0f)
                {
                    wire.GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 0, 255);
                }
                else if (gm.levelThreeTimeLeft < 36.0f)
                {
                    wire.GetComponent<MeshRenderer>().material.color = new Color32(0, 0, 255, 255);
                }
            }
        }

        if (pass == true && morseCodeIndicator.GetComponent<MeshRenderer>().material.color != indicatorPassed.color)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            morseCodeIndicator.GetComponent<MeshRenderer>().material = indicatorPassed;
            gm.morseCodeFinal = true;
            numberOfModules++;
            PlayerPrefs.SetInt("numberOfModules", numberOfModules);
            PlayerPrefs.Save();
            if (numberOfModules != 6)
            {
                correctSound.SetActive(true);
            }
        }

        if (fail == true && morseCodeIndicator.GetComponent<MeshRenderer>().material.color != indicatorPassed.color)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            gm.levelThreeStrikes++;
            strikesText.text = "STRIKES: " + gm.levelThreeStrikes.ToString();
            morseCodeIndicator.GetComponent<MeshRenderer>().material = indicatorStrike;
            if (strikes != 0)
            {
                wrongSound.SetActive(true);
            }
        }

        if (morseCodeIndicator.GetComponent<MeshRenderer>().material.color == new Color32(255, 0, 0, 255) || morseCodeIndicator.GetComponent<MeshRenderer>().material.color == new Color32(0, 255, 0, 255) && morseCodeIndicatorLight.enabled == false)
        {
            morseCodeIndicatorLight.enabled = true;
        }

        if(gm.morseCodeFinal == true && blinker.GetComponent<MeshRenderer>().material.color == blinkMaterial.color)
        {
            blinker.GetComponent<MeshRenderer>().material.color = defaultMaterial.color;
        }
    }

    public void OnMouseDown()
    {
        string materialName01 = number01.GetComponent<MeshRenderer>().material.name.ToString();
        string materialName02 = number02.GetComponent<MeshRenderer>().material.name.ToString();
        string materialName03 = number03.GetComponent<MeshRenderer>().material.name.ToString();
        string materialName04 = number04.GetComponent<MeshRenderer>().material.name.ToString();

        counterNumber01 = PlayerPrefs.GetInt("CounterMorseCodeNumber01");
        counterNumber02 = PlayerPrefs.GetInt("CounterMorseCodeNumber02");
        counterNumber03 = PlayerPrefs.GetInt("CounterMorseCodeNumber03");
        counterNumber04 = PlayerPrefs.GetInt("CounterMorseCodeNumber04");
        numberOfModules = PlayerPrefs.GetInt("numberOfModules");

        correctSound.SetActive(false);
        wrongSound.SetActive(false);

        if (PlayerPrefs.GetString("started") == "False")
        {
            PlayerPrefs.SetString("started", "True");
            PlayerPrefs.Save();
        }

        GameObject theGM = GameObject.Find("GameManagerLevel03");
        GameManagerLevel03 gm = theGM.GetComponent<GameManagerLevel03>();

        bombIndex = gm.bombIndex;

        strikes = gm.levelThreeStrikes;

        if (bombIndex == 1)
        {
            if (gm.morseCodeFinal == false)
            {
                if (this.gameObject.name == "SendMorseCodeButton")
                {
                    if (wire.GetComponent<MeshRenderer>().material.color == new Color32(255, 0, 0, 255))
                    {
                        if (materialName01 == "NumberOneMaterial (Instance)" && materialName02 == "NumberNineMaterial (Instance)" && materialName03 == "NumberOneMaterial (Instance)" && materialName04 == "NumberFourMaterial (Instance)")
                        {
                            pass = true;
                        }
                        else
                        {
                            fail = true;
                        }
                    }
                    else if (wire.GetComponent<MeshRenderer>().material.color == new Color32(0, 255, 0, 255))
                    {
                        if (materialName01 == "NumberFourMaterial (Instance)" && materialName02 == "NumberNineMaterial (Instance)" && materialName03 == "NumberOneMaterial (Instance)" && materialName04 == "NumberFourMaterial (Instance)")
                        {
                            pass = true;
                        }
                        else
                        {
                            fail = true;
                        }
                    }
                    else if (wire.GetComponent<MeshRenderer>().material.color == new Color32(0, 0, 255, 255))
                    {
                        if (materialName01 == "NumberTwoMaterial (Instance)" && materialName02 == "NumberNineMaterial (Instance)" && materialName03 == "NumberOneMaterial (Instance)" && materialName04 == "NumberFourMaterial (Instance)")
                        {
                            pass = true;
                        }
                        else
                        {
                            fail = true;
                        }
                    }
                    else if (wire.GetComponent<MeshRenderer>().material.color == new Color32(255, 255, 0, 255))
                    {
                        if (materialName01 == "NumberThreeMaterial (Instance)" && materialName02 == "NumberNineMaterial (Instance)" && materialName03 == "NumberOneMaterial (Instance)" && materialName04 == "NumberFourMaterial (Instance)")
                        {
                            pass = true;
                        }
                        else
                        {
                            fail = true;
                        }
                    }
                    else if (wire.GetComponent<MeshRenderer>().material.color == new Color32(255, 255, 255, 255))
                    {
                        if (materialName01 == "NumberFiveMaterial (Instance)" && materialName02 == "NumberNineMaterial (Instance)" && materialName03 == "NumberOneMaterial (Instance)" && materialName04 == "NumberFourMaterial (Instance)")
                        {
                            pass = true;
                        }
                        else
                        {
                            fail = true;
                        }
                    }
                }
                SwitchNumbers();
            }
        }
        else if (bombIndex == 2)
        {
            if (gm.morseCodeFinal == false)
            {
                if (this.gameObject.name == "SendMorseCodeButton")
                {
                    if (wire.GetComponent<MeshRenderer>().material.color == new Color32(255, 0, 0, 255))
                    {
                        if (materialName01 == "NumberOneMaterial (Instance)" && materialName02 == "NumberNineMaterial (Instance)" && materialName03 == "NumberSevenMaterial (Instance)" && materialName04 == "NumberZeroMaterial (Instance)")
                        {
                            pass = true;
                        }
                        else
                        {
                            fail = true;
                        }
                    }
                    else if (wire.GetComponent<MeshRenderer>().material.color == new Color32(0, 0, 255, 255))
                    {
                        if (materialName01 == "NumberTwoMaterial (Instance)" && materialName02 == "NumberNineMaterial (Instance)" && materialName03 == "NumberSevenMaterial (Instance)" && materialName04 == "NumberZeroMaterial (Instance)")
                        {
                            pass = true;
                        }
                        else
                        {
                            fail = true;
                        }
                    }
                    else if (wire.GetComponent<MeshRenderer>().material.color == new Color32(255, 255, 255, 255))
                    {
                        if (materialName01 == "NumberFiveMaterial (Instance)" && materialName02 == "NumberNineMaterial (Instance)" && materialName03 == "NumberSevenMaterial (Instance)" && materialName04 == "NumberZeroMaterial (Instance)")
                        {
                            pass = true;
                        }
                        else
                        {
                            fail = true;
                        }
                    }
                    else if (wire.GetComponent<MeshRenderer>().material.color == new Color32(0, 255, 0, 255))
                    {
                        if (materialName01 == "NumberFourMaterial (Instance)" && materialName02 == "NumberNineMaterial (Instance)" && materialName03 == "NumberSevenMaterial (Instance)" && materialName04 == "NumberZeroMaterial (Instance)")
                        {
                            pass = true;
                        }
                        else
                        {
                            fail = true;
                        }
                    }
                    else if (wire.GetComponent<MeshRenderer>().material.color == new Color32(255, 255, 0, 255))
                    {
                        if (materialName01 == "NumberThreeMaterial (Instance)" && materialName02 == "NumberNineMaterial (Instance)" && materialName03 == "NumberSevenMaterial (Instance)" && materialName04 == "NumberZeroMaterial (Instance)")
                        {
                            pass = true;
                        }
                        else
                        {
                            fail = true;
                        }
                    }
                }
                SwitchNumbers();
            }
        }
        else if (bombIndex == 3)
        {
            if (gm.morseCodeFinal == false)
            {
                if (this.gameObject.name == "SendMorseCodeButton")
                {
                    if (wire.GetComponent<MeshRenderer>().material.color == new Color32(255, 0, 0, 255))
                    {
                        if (materialName01 == "NumberOneMaterial (Instance)" && materialName02 == "NumberNineMaterial (Instance)" && materialName03 == "NumberZeroMaterial (Instance)" && materialName04 == "NumberFiveMaterial (Instance)")
                        {
                            pass = true;
                        }
                        else
                        {
                            fail = true;
                        }
                    }
                    else if (wire.GetComponent<MeshRenderer>().material.color == new Color32(255, 255, 255, 255))
                    {
                        if (materialName01 == "NumberFiveMaterial (Instance)" && materialName02 == "NumberNineMaterial (Instance)" && materialName03 == "NumberZeroMaterial (Instance)" && materialName04 == "NumberFiveMaterial (Instance)")
                        {
                            pass = true;
                        }
                        else
                        {
                            fail = true;
                        }
                    }
                    else if (wire.GetComponent<MeshRenderer>().material.color == new Color32(255, 255, 0, 255))
                    {
                        if (materialName01 == "NumberThreeMaterial (Instance)" && materialName02 == "NumberNineMaterial (Instance)" && materialName03 == "NumberZeroMaterial (Instance)" && materialName04 == "NumberFiveMaterial (Instance)")
                        {
                            pass = true;
                        }
                        else
                        {
                            fail = true;
                        }
                    }
                    else if (wire.GetComponent<MeshRenderer>().material.color == new Color32(0, 0, 255, 255))
                    {
                        if (materialName01 == "NumberTwoMaterial (Instance)" && materialName02 == "NumberNineMaterial (Instance)" && materialName03 == "NumberZeroMaterial (Instance)" && materialName04 == "NumberFiveMaterial (Instance)")
                        {
                            pass = true;
                        }
                        else
                        {
                            fail = true;
                        }
                    }
                    else if (wire.GetComponent<MeshRenderer>().material.color == new Color32(0, 255, 0, 255))
                    {
                        if (materialName01 == "NumberFourMaterial (Instance)" && materialName02 == "NumberNineMaterial (Instance)" && materialName03 == "NumberZeroMaterial (Instance)" && materialName04 == "NumberFiveMaterial (Instance)")
                        {
                            pass = true;
                        }
                        else
                        {
                            fail = true;
                        }
                    }
                }
                SwitchNumbers();
            }
        }
    }

    private IEnumerator Flash(GameObject objectToFlash, string textToConvert, float timeOfDot, float timeOfDash, float timeOfInterval, float pause)
    {
        GameObject theGM = GameObject.Find("GameManagerLevel03");
        GameManagerLevel03 gm = theGM.GetComponent<GameManagerLevel03>();

        string textInMorse = "";
        ConvertTextToMorseCode(textToConvert, out textInMorse);
        for (int i = 0; i < textInMorse.Length; i++)
        {
            if (gm.morseCodeFinal == false)
            {
                if (textInMorse[i] == ' ')
                {
                    spotLight.enabled = false;
                    objectToFlash.GetComponent<MeshRenderer>().material = defaultMaterial;
                    yield return 0;
                    yield return new WaitForSeconds(timeOfInterval);
                }
                else if (textInMorse[i] == '.')
                {
                    spotLight.enabled = true;
                    objectToFlash.GetComponent<MeshRenderer>().material = blinkMaterial;
                    yield return 0;
                    yield return new WaitForSeconds(timeOfDot);
                }
                else if (textInMorse[i] == '_')
                {
                    spotLight.enabled = true;
                    objectToFlash.GetComponent<MeshRenderer>().material = blinkMaterial;
                    yield return 0;
                    yield return new WaitForSeconds(timeOfDash);
                }
                if (i == textInMorse.Length - 1)
                {
                    yield return 0;
                    yield return new WaitForSeconds(pause);
                    i = -1; //COULD BE 0 
                }
            }
        }
    }

    private void ConvertTextToMorseCode(string textToConvert, out string convertedText)
    {
        convertedText = "";
        textToConvert = textToConvert.ToLower();
        for (int i = 0; i < textToConvert.Length; i++)
        {
            for (short j = 0; j < 37; j++)
            {
                if (textToConvert[i] == letters[j])
                {
                    convertedText += morseLetters[j];
                    convertedText += "   ";
                    break;
                }
            }
        }
    }
}