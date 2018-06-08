using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Introduction : MonoBehaviour {
    private int PROFESSOR_POKEMON_SPECIESID = 132; // SPECIES ID OF THE POKEMON THE PROFESSORE SENDS OUT

    public AudioClip bgm;
    private AudioClip silence;
    public AudioClip selectClip;
    public AudioClip ballOpen;
    public AudioClip pokeCry;

    private DialogBoxHandler Dialog;

    public GameObject topFade;
    public GameObject bottomFade;
    private SpriteRenderer tFade;
    private SpriteRenderer bFade;

    public GameObject topScreenElements;
    public GameObject female;
    public GameObject femaleShrink;
    public GameObject male;
    public GameObject maleShrink;
    public GameObject prof;
    public GameObject profPoke;
    public GameObject rival;
    public GameObject player;

    public GameObject bottomScreenElements;
    public GameObject touchButton;
    private SpriteRenderer touchSprite;
    public GameObject touchButtonBall;
    private BottomScreen owBottomScreen;
    private Camera TouchScreen;


    private string[] maleNames =
    {
        "Diamond", "Pearl", "Plato", "Ash", "Nic", "Jimmy",
        "Duncan", "Todd", "Ross", "Steven", "Darrel", "Reed",
        "Chris", "Brad", "Dwight", "Randy", "Andy", "Joey",
        "Eric", "Mark", "Gold", "Silver", "Chris", "Ethan"
    };

    private string[] femaleNames =
    {
        "Diamond", "Pearl", "Plato", "Karla", "Joelle", "Britney",
        "Kelli", "Nina", "Heidi", "Miriam", "Teresa", "Aubrey",
        "Kelly", "Naomi", "Abby", "Denise", "Tamara", "Linda",
        "Faith", "Mari", "Maggie", "Heart", "Soul", "Chris", "Lyra"
    };

    private string[] rivalNames =
    {
        "New Name", "Barry", "Nolan", "Roy", "Gavin"
    };

    void Awake() {
        owBottomScreen = GameObject.Find("Global/BottomScreen/Menu").GetComponent<BottomScreen>();

        Dialog = GameObject.Find("Interface").GetComponent<DialogBoxHandler>();
        tFade = topFade.GetComponent<SpriteRenderer>();
        bFade = bottomFade.GetComponent<SpriteRenderer>();
        tFade.color = new Color(0f, 0f, 0f, 1f);
        bFade.color = new Color(0f, 0f, 0f, 1f);

        touchSprite = touchButton.GetComponent<SpriteRenderer>();
        touchSprite.color = new Color(1f, 1f, 1f, 0f);
        silence = Resources.Load<AudioClip>("Audio/bgm/silence");

        SpriteRenderer pokeSprite = profPoke.GetComponent<SpriteRenderer>();
        string shiny = (Random.Range(0f, 8192f) < 1f) ? "s" : "";
        pokeSprite.sprite = Resources.Load<Sprite>("PokemonSprites/"+ PROFESSOR_POKEMON_SPECIESID.ToString("000") + shiny);

        pokeCry = Resources.Load<AudioClip>("Audio/sfx/cries/" + PROFESSOR_POKEMON_SPECIESID.ToString("000") + "Cry");

        TouchScreen = GameObject.Find("Bottom Screen").GetComponent<Camera>();


    }
    // Use this for initialization
    void Start () {
        beginEvent();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void beginEvent()
    {
        StartCoroutine("mainScript");

    }
    private IEnumerator mainScript() {
        //FADE IN
        yield return StartCoroutine(ScreenFade.main.Fade(true, 0.0f));
        float startAlpha = 1f;
        float fadeLength = 2.0f;
        float endAlpha = 0.0f;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeLength)
        {
            Color newColor = new Color(0f, 0f, 0f, Mathf.Lerp(startAlpha, endAlpha, t));
            bFade.color = newColor;
            yield return null;
        }
        Dialog.drawDialogBox();
        yield return Dialog.StartCoroutine("drawTextSilent", "Hello There!\nIt's so very nice to meet you!");
        while (!(Input.GetButtonDown("Select") || CrossPlatformInputManager.GetButtonDown("A")) && !(Input.GetButtonDown("Back") || CrossPlatformInputManager.GetButtonDown("B")))
        {
            yield return null;
        }
        Dialog.undrawDialogBox();
        Dialog.drawDialogBox();
        yield return Dialog.StartCoroutine("drawText", "Welcome to the world of Pokémon!");
        while (!(Input.GetButtonDown("Select") || CrossPlatformInputManager.GetButtonDown("A")) && !(Input.GetButtonDown("Back") || CrossPlatformInputManager.GetButtonDown("B")))
        {
            yield return null;
        }
        Dialog.undrawDialogBox();
        BgmHandler.main.PlayMain(bgm, 128796);
        startAlpha = 1f;
        fadeLength = 4.0f;
        endAlpha = 0.0f;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeLength)
        {
            Color newColor = new Color(0f, 0f, 0f, Mathf.Lerp(startAlpha, endAlpha, t));
            tFade.color = newColor;
            yield return null;
        }

        //LECTURE
        Dialog.drawDialogBox();
        yield return Dialog.StartCoroutine("drawText", "I'm Dimbus Maximus.\nWelcome to the Gen IV DittoWare engine.");
        while (!(Input.GetButtonDown("Select") || CrossPlatformInputManager.GetButtonDown("A")) && !(Input.GetButtonDown("Back") || CrossPlatformInputManager.GetButtonDown("B")))
        {
            yield return null;
        }

        //TOUCHSCREEN DEMO
        startAlpha = 0.0f;
        fadeLength = 1.0f;
        endAlpha = 1f;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeLength)
        {
            Color newColor = new Color(1f, 1f, 1f, Mathf.Lerp(startAlpha, endAlpha, t));
            touchSprite.color = newColor;
            yield return null;
        }
        Dialog.undrawDialogBox();
        Dialog.drawDialogBox();
        yield return Dialog.StartCoroutine("drawTextSilent", "Press the A or B button if you'd please.");
        while (!(Input.GetButtonDown("Select") || CrossPlatformInputManager.GetButtonDown("A")) && !(Input.GetButtonDown("Back") || CrossPlatformInputManager.GetButtonDown("B")))
        {
            yield return null;
        }
        Dialog.undrawDialogBox();
        
        SfxHandler.Play(ballOpen);
        startAlpha = 0f;
        fadeLength = 0.25f;
        endAlpha = 1.0f;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeLength)
        {
            Color newColor = new Color(1f, 1f, 1f, Mathf.Lerp(startAlpha, endAlpha, t));
            tFade.color = newColor;
            bFade.color = newColor;
            yield return null;
        }
        profPoke.transform.position = new Vector3(0f, profPoke.transform.position.y, profPoke.transform.position.z);
        profPoke.SetActive(true);
        startAlpha = 1.0f;
        fadeLength = 0.25f;
        endAlpha = 0f;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 0.33f /*seconds*/)
        {
            profPoke.transform.position += (new Vector3( -0.0625f, 0.8f, 0f) * Time.deltaTime*3f);
            Color newColor = new Color(1f, 1f, 1f, Mathf.Lerp(startAlpha, endAlpha, t*3f));
            tFade.color = newColor;
            bFade.color = newColor;
            yield return null;
        }
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 0.33f /*seconds*/)
        {
            profPoke.transform.position += (new Vector3(-0.0625f, -0.8f, 0f) * Time.deltaTime *3f);

            yield return null;
        }

        SfxHandler.Play(pokeCry);
        SpriteRenderer pokeSprite = profPoke.GetComponent<SpriteRenderer>();
        startAlpha = 1.0f;
        fadeLength = 0.25f;
        endAlpha = 0.5f;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 0.33f /*seconds*/)
        {
            Color newColor = new Color(Mathf.Lerp(startAlpha, endAlpha, t * 3f), Mathf.Lerp(startAlpha, endAlpha, t * 3f), Mathf.Lerp(startAlpha, endAlpha, t * 3f),0.5f);
            pokeSprite.color = newColor;
            yield return null;
        }

        startAlpha = 1.0f;
        fadeLength = 1.0f;
        endAlpha = 0f;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeLength)
        {
            Color newColor = new Color(1f, 1f, 1f, Mathf.Lerp(startAlpha, endAlpha, t));
            touchSprite.color = newColor;
            yield return null;
        }

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 1f /*seconds*/)
        {
            yield return null;
        }


        Dialog.drawDialogBox();
        yield return Dialog.StartCoroutine("drawText", "This is a Pokémon,\na crucial part of your game.");
        while (!(Input.GetButtonDown("Select") || CrossPlatformInputManager.GetButtonDown("A")) && !(Input.GetButtonDown("Back") || CrossPlatformInputManager.GetButtonDown("B")))
        {
            yield return null;
        }
        Dialog.undrawDialogBox();
        
        //GENDER SELECT        
        SpriteRenderer profSprite = prof.GetComponent<SpriteRenderer>();
        SpriteRenderer femaleSprite = female.GetComponent<SpriteRenderer>();
        SpriteRenderer maleSprite = male.GetComponent<SpriteRenderer>();
        Animator femaleAnim = female.GetComponent<Animator>();
        Animator maleAnim = male.GetComponent<Animator>();
        femaleSprite.color = new Color(1f, 1f, 1f, 0f);
        female.SetActive(true);
        maleSprite.color = new Color(1f, 1f, 1f, 0f);
        male.SetActive(true);


        femaleAnim.speed = 0f;
        maleAnim.speed = 0f;

        startAlpha = 1f;
        fadeLength = 1.0f;
        endAlpha = 0.0f;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeLength)
        {
            Color newColor = new Color(1f, 1f, 1f, Mathf.Lerp(startAlpha, endAlpha, t));
            profSprite.color = newColor;
            newColor = new Color(0.5f, 0.5f, 0.5f, Mathf.Lerp(startAlpha, endAlpha, 0.5f + t/2));
            pokeSprite.color = newColor;
            yield return null;
        }
        startAlpha = 1f;
        fadeLength = 1.0f;
        endAlpha = 0.0f;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeLength)
        {
            Color newColor2 = new Color(1f, 1f, 1f, Mathf.Lerp(endAlpha, startAlpha, t));
            femaleSprite.color = newColor2;
            maleSprite.color = newColor2;
            yield return null;
        }
        Dialog.drawDialogBox();
        yield return Dialog.StartCoroutine("drawText", "Now, let me get to know you a bit.\nWhat do you look like?");
        while (!(Input.GetButtonDown("Select") || CrossPlatformInputManager.GetButtonDown("A")) && !(Input.GetButtonDown("Back") || CrossPlatformInputManager.GetButtonDown("B")))
        {
            yield return null;
        }
        Dialog.undrawDialogBox();
        Dialog.drawDialogBox();
        yield return Dialog.StartCoroutine("drawTextSilent", "Are you a boy or a girl?");
        while (!(Input.GetButtonDown("Select") || CrossPlatformInputManager.GetButtonDown("A")) && !(Input.GetButtonDown("Back") || CrossPlatformInputManager.GetButtonDown("B")))
        {
            yield return null;
        }
        femaleAnim.speed = 1f;
        maleAnim.speed = 1f;

        Dialog.drawChoiceBox(new string[] { "Male", "Female" });
        yield return new WaitForSeconds(0.2f);
        yield return Dialog.StartCoroutine("choiceNavigate");
        int chosenIndex = Dialog.chosenIndex;
        Dialog.undrawChoiceBox();
        if (chosenIndex == 1)
        {
            SaveData.currentSave.isMale = true; //Male
        }
        else
        {
            SaveData.currentSave.isMale = false; //Female
        }

        startAlpha = 1f;
        fadeLength = 1.0f;
        endAlpha = 0.0f;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeLength)
        {
            Color newColor = new Color(1f, 1f, 1f, Mathf.Lerp(startAlpha, endAlpha, t));
            femaleSprite.color = newColor;
            maleSprite.color = newColor;
            yield return null;
        }

        //PLAYER NAME
        Dialog.undrawDialogBox();
        Dialog.drawDialogBox();
        yield return Dialog.StartCoroutine("drawTextSilent", "What is your name?");
        while (!(Input.GetButtonDown("Select") || CrossPlatformInputManager.GetButtonDown("A")) && !(Input.GetButtonDown("Back") || CrossPlatformInputManager.GetButtonDown("B")))
        {
            yield return null;
        }
        Sprite[] playerIcon = Resources.LoadAll<Sprite>("PlayerSprites/" + SaveData.currentSave.getPlayerSpritePrefix() + "walk");//get player sprites
        Sprite[] playerIconFront = { playerIcon[8], playerIcon[9], playerIcon[10], playerIcon[11] };//get fronte sprite anim

        string chosenName = "";
        do {
            Scene.main.Typing.gameObject.SetActive(true);
            StartCoroutine(Scene.main.Typing.control(10, "", Pokemon.Gender.NONE, playerIconFront));
            while (Scene.main.Typing.gameObject.activeSelf)
            {
                yield return null;
            }
            if (Scene.main.Typing.typedString.Length > 0)
            {
                chosenName = Scene.main.Typing.typedString;
                SaveData.currentSave.playerName = Scene.main.Typing.typedString;
            }

            yield return StartCoroutine(ScreenFade.main.Fade(true, 0.4f));
            
            if (Scene.main.Typing.typedString.Length == 0)
            {
                Scene.main.Typing.gameObject.SetActive(false);
                string suggestedName;
                if (SaveData.currentSave.isMale)
                {
                    suggestedName = maleNames[Random.Range(0,maleNames.Length-1)]; //Pick a male name
                }
                else
                {
                    suggestedName = femaleNames[Random.Range(0, femaleNames.Length - 1)]; //Pick a female name
                }
                Dialog.undrawDialogBox();
                Dialog.drawDialogBox();
                yield return Dialog.StartCoroutine("drawTextSilent", "Is your name "+ suggestedName +"?");
                Dialog.undrawChoiceBox();
                Dialog.drawChoiceBox();
                yield return new WaitForSeconds(0.2f);
                yield return Dialog.StartCoroutine("choiceNavigate");
                chosenIndex = Dialog.chosenIndex;
                Dialog.undrawChoiceBox();
                if (chosenIndex == 1)
                {
                    chosenName = suggestedName;
                    SaveData.currentSave.playerName = chosenName;
                }
            }
        }
        while (chosenName.Length <= 0);

        //RIVAL NAME
        SpriteRenderer rivalSprite = rival.GetComponent<SpriteRenderer>();
        rivalSprite.color = new Color(1f,1f,1f,0f);
        rival.SetActive(true);

        startAlpha = 0.0f;
        fadeLength = 1.0f;
        endAlpha = 1f;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeLength)
        {
            Color newColor = new Color(1f, 1f, 1f, Mathf.Lerp(startAlpha, endAlpha, t));
            rivalSprite.color = newColor;
            yield return null;
        }
        Dialog.undrawDialogBox();
        Dialog.drawDialogBox();
        yield return Dialog.StartCoroutine("drawText", "This is a long-time friend of yours, right?\nWhat is his name?");
        while (!(Input.GetButtonDown("Select") || CrossPlatformInputManager.GetButtonDown("A")) && !(Input.GetButtonDown("Back") || CrossPlatformInputManager.GetButtonDown("B")))
        {
            yield return null;
        }
        chosenName = "";
        do
        {
            Dialog.undrawChoiceBox();
            Dialog.drawChoiceBox(rivalNames);
            yield return new WaitForSeconds(0.2f);
            yield return Dialog.StartCoroutine(Dialog.choiceNavigate(rivalNames));
            chosenIndex = Dialog.chosenIndex;
            Dialog.undrawChoiceBox();
            if (chosenIndex == 4)
            {
                Scene.main.Typing.gameObject.SetActive(true);
                StartCoroutine(Scene.main.Typing.control(10, "", Pokemon.Gender.NONE, playerIconFront));
                while (Scene.main.Typing.gameObject.activeSelf)
                {
                    yield return null;
                }
                if (Scene.main.Typing.typedString.Length > 0)
                {
                    chosenName = Scene.main.Typing.typedString;
                    SaveData.currentSave.rivalName = Scene.main.Typing.typedString;
                }
                yield return StartCoroutine(ScreenFade.main.Fade(true, 0.4f));
            }
            else
            {
                chosenName = rivalNames[chosenIndex];
                SaveData.currentSave.rivalName = rivalNames[chosenIndex];
            }
           
        }
        while (chosenName.Length <= 0);

        startAlpha = 1.0f;
        fadeLength = 1.0f;
        endAlpha = 0f;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeLength)
        {
            Color newColor = new Color(1f, 1f, 1f, Mathf.Lerp(startAlpha, endAlpha, t));
            rivalSprite.color = newColor;
            yield return null;
        }

        //PLAYER SEND OFF
        SpriteRenderer playerSprite = player.GetComponent<SpriteRenderer>();
        playerSprite.sprite = (SaveData.currentSave.isMale) ? Resources.Load<Sprite>("PlayerSprites/male_Intro") : Resources.Load<Sprite>("PlayerSprites/female_Intro");

        playerSprite.color = new Color(1f, 1f, 1f, 0f);
        player.SetActive(true);

        startAlpha = 0.0f;
        fadeLength = 1.0f;
        endAlpha = 1f;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeLength)
        {
            Color newColor = new Color(1f, 1f, 1f, Mathf.Lerp(startAlpha, endAlpha, t));
            playerSprite.color = newColor;
            yield return null;
        }
        Dialog.undrawDialogBox();
        Dialog.drawDialogBox();
        yield return Dialog.StartCoroutine("drawText", "Time to enter the world of pokémon!\nI'm sure many adventures await.");
        while (!(Input.GetButtonDown("Select") || CrossPlatformInputManager.GetButtonDown("A")) && !(Input.GetButtonDown("Back") || CrossPlatformInputManager.GetButtonDown("B")))
        {
            yield return null;
        }
        Dialog.undrawDialogBox();
        Dialog.drawDialogBox();
        yield return Dialog.StartCoroutine("drawText", "See you soon!");
        while (!(Input.GetButtonDown("Select") || CrossPlatformInputManager.GetButtonDown("A")) && !(Input.GetButtonDown("Back") || CrossPlatformInputManager.GetButtonDown("B")))
        {
            yield return null;
        }

        BgmHandler.main.PlayMain(silence, 0);
        Dialog.undrawDialogBox();
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 1.0f /*seconds*/)
        {
            yield return null; //wait for animation
        }

        Animator playerAnim = player.GetComponent<Animator>();
        if (SaveData.currentSave.isMale)
        {
            playerAnim.Play("male");
        }
        else
        {
            playerAnim.Play("female");
        }

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 2.0f /*seconds*/)
        {
            yield return null; //wait for animation
        }

        //FADE OUT
        startAlpha = 0f;
        fadeLength = 2.0f;
        endAlpha = 1.0f;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeLength)
        {
            Color newColor = new Color(0f, 0f, 0f, Mathf.Lerp(startAlpha, endAlpha, t));
            tFade.color = newColor;
            bFade.color = newColor;
            yield return null;
        }

        GlobalVariables.global.playerPosition = new Vector3(78, 0, 29);
        GlobalVariables.global.playerDirection = 2;
        GlobalVariables.global.fadeIn = true;
        Application.LoadLevel("indoorsNW");
        owBottomScreen.menuEnabled = true;
    }
}
