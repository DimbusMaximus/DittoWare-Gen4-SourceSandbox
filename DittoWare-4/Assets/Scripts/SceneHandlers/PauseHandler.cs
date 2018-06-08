//Original Scripts by IIColour (IIColour_Spectrum)

using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PauseHandler : MonoBehaviour
{
    
    private GameObject buttonPokedex;
    private GameObject buttonTrainer;
    private GameObject buttonParty;
    private GameObject buttonSave;
    private GameObject buttonBag;
    private GameObject buttonOptions;
    private GameObject buttonGear;
    private SpriteRenderer cursor;

    private GameObject bar;

    private GUITexture saveDataDisplay;
    private GUIText mapName;
    private GUIText mapNameShadow;
    private GUIText dataText;
    private GUIText dataTextShadow;

    private DialogBoxHandler Dialog;

    private BottomScreen BottomScreen;


    private AudioSource PauseAudio;
    public AudioClip selectClip;
    public AudioClip openClip;

    private int selectedIcon;
    private RotatableGUIItem targetIcon;

    private bool running;

    void Awake()
    {

        Dialog = GameObject.Find("GUI").GetComponent<DialogBoxHandler>();

        PauseAudio = transform.GetComponent<AudioSource>();
        
        saveDataDisplay = transform.Find("SaveDataDisplay").GetComponent<GUITexture>();
        mapName = saveDataDisplay.transform.Find("MapName").GetComponent<GUIText>();
        mapNameShadow = mapName.transform.Find("MapNameShadow").GetComponent<GUIText>();
        dataText = saveDataDisplay.transform.Find("DataText").GetComponent<GUIText>();
        dataTextShadow = dataText.transform.Find("DataTextShadow").GetComponent<GUIText>();

        bar = GameObject.Find("ScenePause/Bar");

        BottomScreen = GameObject.Find("BottomScreen/Menu").GetComponent<BottomScreen>();

        buttonPokedex = GameObject.Find("BottomScreen/Menu/Button Pokedex");
        buttonTrainer = GameObject.Find("BottomScreen/Menu/Button Trainer");
        buttonParty = GameObject.Find("BottomScreen/Menu/Button Party");
        buttonSave = GameObject.Find("BottomScreen/Menu/Button Save");
        buttonBag = GameObject.Find("BottomScreen/Menu/Button Bag");
        buttonOptions = GameObject.Find("BottomScreen/Menu/Button Options");
        buttonGear = GameObject.Find("BottomScreen/Menu/Button Gear");
        cursor = GameObject.Find("BottomScreen/Menu/Cursor").GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        selectedIcon = 0;

        saveDataDisplay.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public IEnumerator updateIcon(int index)
    {
        if (selectedIcon == 0)
        {
            cursor.transform.localPosition = buttonPokedex.transform.localPosition;
        }
        else if (selectedIcon == 1)
        {
            cursor.transform.localPosition = buttonTrainer.transform.localPosition;
        }
        else if (selectedIcon == 2)
        {
            cursor.transform.localPosition = buttonParty.transform.localPosition;
        }
        else if (selectedIcon == 3)
        {
            cursor.transform.localPosition = buttonSave.transform.localPosition;
        }
        else if (selectedIcon == 4)
        {
            cursor.transform.localPosition = buttonBag.transform.localPosition;
        }
        else if (selectedIcon == 5)
        {
            cursor.transform.localPosition = buttonOptions.transform.localPosition;
        }
        else if (selectedIcon == 6)
        {
            cursor.transform.localPosition = buttonGear.transform.localPosition;
        }
        yield return null;
    }


    public IEnumerator control()
    {
        BottomScreen.preventClick = true;
        bar.SetActive(true);
        cursor.gameObject.SetActive(true);
        selectedIcon = 0;
        StartCoroutine(updateIcon(selectedIcon));
        SfxHandler.Play(openClip);
        running = true;
        bool firstFrame = true; //prevents instantanious open/close
        while (running)
        {
            if (Input.GetAxisRaw("Vertical") > 0 ||CrossPlatformInputManager.GetAxisRaw("Vertical") > 0 )
            {
                if (selectedIcon > 1)
                {
                    selectedIcon -= 2;
                }
                else if (selectedIcon == 1)
                {
                    selectedIcon = 5;
                }
                else if (selectedIcon == 0)
                {
                    selectedIcon = 6;
                }
                StartCoroutine(updateIcon(selectedIcon));
                SfxHandler.Play(selectClip);
                yield return new WaitForSeconds(0.1f);
            }
            else if (Input.GetAxisRaw("Horizontal") > 0 ||CrossPlatformInputManager.GetAxisRaw("Horizontal") < 0 )
            {
                if (selectedIcon == 0 || selectedIcon == 2 || selectedIcon == 4)
                {
                    selectedIcon += 1;
                }
                else if (selectedIcon == 1 || selectedIcon == 3 || selectedIcon == 5)
                {
                    selectedIcon -= 1;
                }
                else if (selectedIcon == 6)
                {
                    selectedIcon -= 1;
                }
                StartCoroutine(updateIcon(selectedIcon));
                SfxHandler.Play(selectClip);
                yield return new WaitForSeconds(0.1f);
            }
            else if (Input.GetAxisRaw("Vertical") < 0 ||CrossPlatformInputManager.GetAxisRaw("Vertical") < 0 )
            {
                if (selectedIcon < 5)
                {
                    selectedIcon += 2;
                }
                else if (selectedIcon == 5)
                {
                    selectedIcon = 1;
                }
                else if (selectedIcon == 6)
                {
                    selectedIcon = 0;
                }
                StartCoroutine(updateIcon(selectedIcon));
                SfxHandler.Play(selectClip);
                yield return new WaitForSeconds(0.1f);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0 || CrossPlatformInputManager.GetAxisRaw("Horizontal") > 0)
            {
                if (selectedIcon == 0 || selectedIcon == 2 || selectedIcon == 4)
                {
                    selectedIcon += 1;
                }
                else if (selectedIcon == 1 || selectedIcon == 3 || selectedIcon == 5)
                {
                    selectedIcon -= 1;
                }
                else if (selectedIcon == 6)
                {
                    selectedIcon -= 1;
                }
                StartCoroutine(updateIcon(selectedIcon));
                SfxHandler.Play(selectClip);
                yield return new WaitForSeconds(0.1f);
            }
            else if (Input.GetButton("Select") || CrossPlatformInputManager.GetButtonDown("A"))
            {
                if (selectedIcon == 0)
                {
                    //Pokedex
                    Debug.Log("Pokédex not yet implemented");
                    yield return new WaitForSeconds(0.2f);
                }
                else if (selectedIcon == 1)
                {
                    //TrainerCard
                    SfxHandler.Play(selectClip);
                    yield return StartCoroutine(ScreenFade.main.Fade(false, 0.4f));
                    yield return StartCoroutine(runSceneUntilDeactivated(Scene.main.Trainer.gameObject));
                    yield return StartCoroutine(ScreenFade.main.Fade(true, 0.4f));
                }
                else if (selectedIcon == 2)
                {
                    //Party
                    SfxHandler.Play(selectClip);
                    yield return StartCoroutine(ScreenFade.main.Fade(false, 0.4f));
                    yield return StartCoroutine(runSceneUntilDeactivated(Scene.main.Party.gameObject));
                    yield return StartCoroutine(ScreenFade.main.Fade(true, 0.4f));
                }
                else if (selectedIcon == 3)
                {
                    bar.SetActive(false);
                    cursor.gameObject.SetActive(false);
                    //Save
                    saveDataDisplay.gameObject.SetActive(true);
                    saveDataDisplay.texture =
                        Resources.Load<Texture>("Frame/choice" + PlayerPrefs.GetInt("frameStyle"));
                    int badgeTotal = 0;
                    for (int i = 0; i < 12; i++)
                    {
                        if (SaveData.currentSave.gymsBeaten[i])
                        {
                            badgeTotal += 1;
                        }
                    }
                    string playerTime = "" + SaveData.currentSave.playerMinutes;
                    if (playerTime.Length == 1)
                    {
                        playerTime = "0" + playerTime;
                    }
                    playerTime = SaveData.currentSave.playerHours + " : " + playerTime;

                    mapName.text = PlayerMovement.player.accessedMapSettings.mapName;
                    dataText.text = SaveData.currentSave.playerName + "\n" +
                                    badgeTotal + "\n" +
                                    "0" + "\n" + //pokedex not yet implemented
                                    playerTime;
                    mapNameShadow.text = mapName.text;
                    dataTextShadow.text = dataText.text;

                    Dialog.drawDialogBox();
                    yield return StartCoroutine(Dialog.drawText("Would you like to save the game?"));
                    Dialog.drawChoiceBoxNo();
                    yield return new WaitForSeconds(0.2f);
                    yield return StartCoroutine(Dialog.choiceNavigateNo());
                    int chosenIndex = Dialog.chosenIndex;
                    if (chosenIndex == 1)
                    {
                        //update save file
                        Dialog.undrawChoiceBox();
                        Dialog.drawDialogBox();

                        SaveData.currentSave.levelName = Application.loadedLevelName;
                        SaveData.currentSave.playerPosition = new SeriV3(PlayerMovement.player.transform.position);
                        SaveData.currentSave.playerDirection = PlayerMovement.player.direction;
                        SaveData.currentSave.mapName = PlayerMovement.player.accessedMapSettings.mapName;

                        NonResettingHandler.saveDataToGlobal();

                        SaveLoad.Save();

                        yield return
                            StartCoroutine(Dialog.drawText(SaveData.currentSave.playerName + " saved the game!"));
                        while (!Input.GetButtonDown("Select") && !Input.GetButtonDown("Back") || CrossPlatformInputManager.GetButtonDown("A") || CrossPlatformInputManager.GetButtonDown("B"))
                        {
                            yield return null;
                        }
                    }
                    Dialog.undrawDialogBox();
                    Dialog.undrawChoiceBox();
                    saveDataDisplay.gameObject.SetActive(false);
                    cursor.gameObject.SetActive(true);
                    bar.SetActive(true);
                    yield return new WaitForSeconds(0.2f);
                }
                else if (selectedIcon == 4)
                {
                    //Bag
                    SfxHandler.Play(selectClip);
                    yield return StartCoroutine(ScreenFade.main.Fade(false, 0.4f));
                    yield return StartCoroutine(runSceneUntilDeactivated(Scene.main.Bag.gameObject));
                    yield return StartCoroutine(ScreenFade.main.Fade(true, 0.4f));
                }
                else if (selectedIcon == 5)
                {
                    //Settings
                    SfxHandler.Play(selectClip);
                    yield return StartCoroutine(ScreenFade.main.Fade(false, 0.4f));
                    yield return StartCoroutine(runSceneUntilDeactivated(Scene.main.Settings.gameObject));
                    yield return StartCoroutine(ScreenFade.main.Fade(true, 0.4f));
                }
                else if (selectedIcon == 6)
                {
                    //TrainerCard
                    SfxHandler.Play(selectClip);
                    yield return StartCoroutine(ScreenFade.main.Fade(false, 0.4f));
                    yield return StartCoroutine(ScreenFade.main.Fade(true, 0.4f));
                }
            }
            if ((Input.GetButtonDown("Start") || Input.GetButtonDown("Back") || CrossPlatformInputManager.GetButtonDown("X") || CrossPlatformInputManager.GetButtonDown("B")) && !firstFrame)
            {
                running = false;
            }
            Input.ResetInputAxes();
            firstFrame = false;
            yield return null;
        }

        bar.SetActive(false);
        cursor.gameObject.SetActive(false);
        BottomScreen.menuEnabled = false;
        yield return new WaitForSeconds(0.2f);
        BottomScreen.menuEnabled = true;
        BottomScreen.preventClick = false;
        this.gameObject.SetActive(false);
    }

    /// Only runs the default scene (no parameters)
    private IEnumerator runSceneUntilDeactivated(GameObject sceneInterface)
    {
        sceneInterface.SetActive(true);
        sceneInterface.SendMessage("control");
        while (sceneInterface.activeSelf)
        {
            yield return null;
        }
    }
}