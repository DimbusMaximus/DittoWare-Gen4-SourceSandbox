using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class BottomScreen : MonoBehaviour {

    private AudioSource PauseAudio;
    public AudioClip selectClip;
    public AudioClip openClip;

    GUIText trainerName;
    GUIText trainerNameShadow;
    GUIText trainerNameShadow2;
    GUIText trainerNameShadow3;

    SpriteRenderer toggleInteract;
    SpriteRenderer runToggle;
    SpriteRenderer keyItem;
    SpriteRenderer keyItem2;
    SpriteRenderer buttonPokedex;
    SpriteRenderer buttonTrainer;
    SpriteRenderer buttonParty;
    SpriteRenderer buttonSave;
    SpriteRenderer buttonBag;
    SpriteRenderer buttonOptions;
    SpriteRenderer buttonGear;
    SpriteRenderer cursor;

    Camera BottomScreenCamera;

    private DialogBoxHandler Dialog;

    private GUITexture saveDataDisplay;
    private GUIText mapName;
    private GUIText mapNameShadow;
    private GUIText dataText;
    private GUIText dataTextShadow;

    private bool runForced;
    public bool menuEnabled = true;
    public bool preventClick = false;

    public bool menuSelected = false;
    private int selectedIndex = 0;

    // Use this for initialization
    void Start () {
        // Update name based on save content.
        trainerName = GameObject.Find("Button Trainer/Text").GetComponent<GUIText>();
        trainerNameShadow = GameObject.Find("Button Trainer/TextShadow").GetComponent<GUIText>();
        trainerNameShadow2 = GameObject.Find("Button Trainer/TextShadow2").GetComponent<GUIText>();
        trainerNameShadow3 = GameObject.Find("Button Trainer/TextShadow3").GetComponent<GUIText>();
        BottomScreenCamera = GameObject.Find(transform.parent.name).GetComponent<Camera>();

        toggleInteract = GameObject.Find("Toggle Interact").GetComponent<SpriteRenderer>();
        runToggle = GameObject.Find("Toggle Run").GetComponent<SpriteRenderer>();
        keyItem = GameObject.Find("Toggle KeyItem").GetComponent<SpriteRenderer>();
        keyItem2 = GameObject.Find("Toggle KeyItem2").GetComponent<SpriteRenderer>();
        buttonPokedex = GameObject.Find("Button Pokedex/Sprite").GetComponent<SpriteRenderer>();
        buttonTrainer = GameObject.Find("Button Trainer/Sprite").GetComponent<SpriteRenderer>();
        buttonParty = GameObject.Find("Button Party/Sprite").GetComponent<SpriteRenderer>();
        buttonSave = GameObject.Find("Button Save/Sprite").GetComponent<SpriteRenderer>();
        buttonBag = GameObject.Find("Button Bag/Sprite").GetComponent<SpriteRenderer>();
        buttonOptions = GameObject.Find("Button Options/Sprite").GetComponent<SpriteRenderer>();
        buttonGear = GameObject.Find("Button Gear/Sprite").GetComponent<SpriteRenderer>();

        cursor = GameObject.Find("Cursor").GetComponent<SpriteRenderer>();

        saveDataDisplay = GameObject.Find(transform.parent.parent.name + "/GUI/SaveDataDisplay").GetComponent<GUITexture>();
        mapName = saveDataDisplay.transform.Find("MapName").GetComponent<GUIText>();
        mapNameShadow = mapName.transform.Find("MapNameShadow").GetComponent<GUIText>();
        dataText = saveDataDisplay.transform.Find("DataText").GetComponent<GUIText>();
        dataTextShadow = dataText.transform.Find("DataTextShadow").GetComponent<GUIText>();

        runForced = PlayerMovement.player.runningforced;
        menuEnabled = true;

        cursor.gameObject.SetActive(false);
    }

    void Awake()
    {
        Dialog = GameObject.Find(transform.parent.parent.name + "/GUI").GetComponent<DialogBoxHandler>();
    }

    // Update is called once per frame
    void Update () {
        trainerName.text = SaveData.currentSave.playerName;
        trainerNameShadow.text = SaveData.currentSave.playerName;
        trainerNameShadow2.text = SaveData.currentSave.playerName;
        trainerNameShadow3.text = SaveData.currentSave.playerName;


        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = BottomScreenCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 4.0f) && menuEnabled && !preventClick)
            {
                
                Debug.Log("You selected the " + hit.transform.name);
                switch (hit.transform.name)
                {
                    case "Toggle Run":
                        toggleForcedRunning();
                        break;
                    case "Button Pokedex":
                        StartCoroutine(SelectMenuItemClick(hit.transform,"Pokedex"));
                        break;
                    case "Button Party":
                        StartCoroutine(SelectMenuItemClick(hit.transform, "Party"));
                        break;
                    case "Button Bag":
                        StartCoroutine(SelectMenuItemClick(hit.transform, "Bag"));
                        break;
                    case "Button Gear":
                        StartCoroutine(SelectMenuItemClick(hit.transform, "Gear"));
                        break;
                    case "Button Trainer":
                        StartCoroutine(SelectMenuItemClick(hit.transform, "Trainer"));
                        break;
                    case "Button Options":
                        StartCoroutine(SelectMenuItemClick(hit.transform, "Options"));
                        break;
                    case "Button Save":
                        StartCoroutine(SaveRoutine(hit.transform));
                        break;
                    default:
                        break;
                }
            }
        }
        
        if (Dialog.messageActive || !menuEnabled)
        {
            fadeOutIcons();
        }
        else
        {
            fadeInIcons();

            if (PlayerMovement.player.running)
            {
                runToggle.color = new Vector4(1f, 1f, 1f, 1f);
            }
            else
            {
                runToggle.color = new Vector4(1f, 1f, 1f, 0.5f);
            }
        }
    }

    private void toggleForcedRunning()
    {
        runForced = !runForced;
        if (runForced)
        {
            PlayerMovement.player.runningforced = true;
        }
        else
        {
            PlayerMovement.player.runningforced = false;
        }
    }
    
    private void fadeOutIcons()
    {
        if (!Dialog.messageActive)
        {
            toggleInteract.color = new Vector4(1f, 1f, 1f, 0.5f);
        }
        runToggle.color = new Vector4(1f, 1f, 1f, 0.5f);
        keyItem.color = new Vector4(1f, 1f, 1f, 0.5f);
        keyItem2.color = new Vector4(1f, 1f, 1f, 0.5f);
        buttonPokedex.color = new Vector4(1f, 1f, 1f, 0.5f);
        buttonTrainer.color = new Vector4(1f, 1f, 1f, 0.5f);
        buttonParty.color = new Vector4(1f, 1f, 1f, 0.5f);
        buttonSave.color = new Vector4(1f, 1f, 1f, 0.5f);
        buttonBag.color = new Vector4(1f, 1f, 1f, 0.5f);
        buttonOptions.color = new Vector4(1f, 1f, 1f, 0.5f);
        buttonGear.color = new Vector4(1f, 1f, 1f, 0.5f);
    }

    private void fadeInIcons()
    {
        if (Dialog.messageActive)
        {
            toggleInteract.color = new Vector4(1f, 1f, 1f, 1f);
        }
        runToggle.color = new Vector4(1f, 1f, 1f, 1f);
        keyItem.color = new Vector4(1f, 1f, 1f, 1f);
        keyItem2.color = new Vector4(1f, 1f, 1f, 1f);
        buttonPokedex.color = new Vector4(1f, 1f, 1f, 1f);
        buttonTrainer.color = new Vector4(1f, 1f, 1f, 1f);
        buttonParty.color = new Vector4(1f, 1f, 1f, 1f);
        buttonSave.color = new Vector4(1f, 1f, 1f, 1f);
        buttonBag.color = new Vector4(1f, 1f, 1f, 1f);
        buttonOptions.color = new Vector4(1f, 1f, 1f, 1f);
        buttonGear.color = new Vector4(1f, 1f, 1f, 1f);
    }

    private IEnumerator SelectMenuItemClick(Transform objTr, string action = "")
    {
        objTr = GameObject.Find(objTr.gameObject.name + "/Sprite").GetComponent<Transform>();

        menuEnabled = false;
         Vector3 temp = objTr.transform.position;
        SfxHandler.Play(selectClip);
        PlayerMovement.player.setCheckBusyWith(objTr.gameObject);
        StartCoroutine(ScreenFade.main.Fade(false, ScreenFade.defaultSpeed));
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 0.125f /*seconds*/)
        {
            objTr.transform.position += (new Vector3(0f, 0.5f, 0f) * Time.deltaTime * 8f);
            yield return null;
        }
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 0.125f /*seconds*/)
        {
            objTr.transform.position += (new Vector3(0f, -0.5f, 0f) * Time.deltaTime * 8f);
            yield return null;
        }
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 0.125f /*seconds*/)
        {
            objTr.transform.position += (new Vector3(0f, 0.5f, 0f) * Time.deltaTime * 8f);
            yield return null;
        }
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 0.125f /*seconds*/)
        {
            objTr.transform.position += (new Vector3(0f, -0.5f, 0f) * Time.deltaTime * 8f);
            yield return null;
        }
        objTr.transform.position = temp;

        yield return new WaitForSeconds(0.5f);

        switch (action)
        {
            case "Pokedex":
                //Pokedex Unfinished
                break;
            case "Party":
                yield return StartCoroutine(runSceneUntilDeactivated(Scene.main.Party.gameObject));
                break;
            case "Bag":
                yield return StartCoroutine(runSceneUntilDeactivated(Scene.main.Bag.gameObject));
                break;
            case "Trainer":
                yield return StartCoroutine(runSceneUntilDeactivated(Scene.main.Trainer.gameObject));
                break;
            //SAVING IS HANDLED ELSEWHERE
            case "Options":
                yield return StartCoroutine(runSceneUntilDeactivated(Scene.main.Settings.gameObject));
                break;
            case "Gear":
                //Pokegear unfinished
                break;
            default:
                break;
        }
        StartCoroutine(ScreenFade.main.Fade(true, ScreenFade.defaultSpeed));
        yield return new WaitForSeconds(0.5f);
        PlayerMovement.player.unsetCheckBusyWith(objTr.gameObject);
        menuEnabled = true;
    }

    private IEnumerator NavigateMenu()
    {
        Debug.Log("Navigating Menu");
        cursor.gameObject.SetActive(true);
        while (!(Input.GetButtonDown("Back") || CrossPlatformInputManager.GetButtonDown("B")) 
            && !(Input.GetButtonDown("X") || CrossPlatformInputManager.GetButtonDown("X")))
        {
            if (Input.GetAxisRaw("Horizontal") < 0 || CrossPlatformInputManager.GetAxisRaw("Horizontal") < 0)
            {
                if (selectedIndex != 0 && selectedIndex != 2 && selectedIndex != 4 && selectedIndex != 6)
                {
                    selectedIndex -= 1;
                }
                else if (selectedIndex == 0)
                {
                    selectedIndex = 1;//end of row 1
                }
                else if (selectedIndex == 2)
                {
                    selectedIndex = 3;//end of row 2
                }
                else if (selectedIndex == 4)
                {
                    selectedIndex = 5;//end of row 3
                }
                else if (selectedIndex == 6)
                {
                    selectedIndex = 5;//end of row 3
                }
            }
            else if (Input.GetAxisRaw("Horizontal") > 0 || CrossPlatformInputManager.GetAxisRaw("Horizontal") > 0)
            {
                if (selectedIndex != 1 && selectedIndex != 3 && selectedIndex != 5 && selectedIndex != 6)
                {
                    selectedIndex += 1;
                }
                else if (selectedIndex == 1)
                {
                    selectedIndex = 0;//top of row 1
                }
                else if (selectedIndex == 3)
                {
                    selectedIndex = 2;//top of row 2
                }
                else if (selectedIndex == 5)
                {
                    selectedIndex = 4;//top of row 3
                }
                else if (selectedIndex == 6)
                {
                    selectedIndex = 5;//end of row 3
                }
            }
            else if (Input.GetAxisRaw("Vertical") > 0 || CrossPlatformInputManager.GetAxisRaw("Vertical") > 0)
            {
                if (selectedIndex != 0 && selectedIndex != 1)
                {
                    selectedIndex -= 2;
                }
                else if (selectedIndex == 5)
                {
                    selectedIndex = 5;//bottom of column two
                }
                else if (selectedIndex == 6)
                {
                    selectedIndex = 6;//bottom of column one
                }
            }
            else if (Input.GetAxisRaw("Vertical") < 0 || CrossPlatformInputManager.GetAxisRaw("Horizontal") < 0)
            {
                if (selectedIndex != 5 && selectedIndex != 6)
                {
                    selectedIndex += 2;
                }
                else if (selectedIndex == 5)
                {
                    selectedIndex = 1;//top of column two
                }
                else if (selectedIndex == 6)
                {
                    selectedIndex = 0;//top of column one
                }
            }
            switch (selectedIndex)
            {
                case 0://POKEDEX
                    cursor.gameObject.transform.localPosition = new Vector3(-5.25f, 3.75f, 1f);
                    break;
                case 1://TRAINER
                    cursor.gameObject.transform.localPosition = new Vector3(-0.25f, 3.75f, 1f);
                    break;
                case 2://PARTY
                    cursor.gameObject.transform.localPosition = new Vector3(-5.25f, 1.25f, 1f);
                    break;
                case 3://SAVE
                    cursor.gameObject.transform.localPosition = new Vector3(-0.25f, 1.25f, 1f);
                    break;
                case 4://BAG
                    cursor.gameObject.transform.localPosition = new Vector3(-5.25f, -1.25f, 1f);
                    break;
                case 5://OPTIONS
                    cursor.gameObject.transform.localPosition = new Vector3(-0.25f, -1.25f, 1f);
                    break;
                case 6://GEAR
                    cursor.gameObject.transform.localPosition = new Vector3(-5.25f, -3.75f, 1f);
                    break;
                default:
                    break;
            }
            if (Input.GetButtonDown("Select") || CrossPlatformInputManager.GetButtonDown("A"))
            {
                switch (selectedIndex)
                {
                    case 0:
                        StartCoroutine(SelectMenuItemClick(buttonPokedex.gameObject.transform, "Pokedex"));
                        break;
                    case 1:
                        StartCoroutine(SelectMenuItemClick(buttonTrainer.gameObject.transform, "Trainer"));
                        break;
                    case 2:
                        StartCoroutine(SelectMenuItemClick(buttonParty.gameObject.transform, "Party"));
                        break;
                    case 3:
                        StartCoroutine(SaveRoutine(buttonSave.gameObject.transform));
                        break;
                    case 4:
                        StartCoroutine(SelectMenuItemClick(buttonBag.gameObject.transform, "Bag"));
                        break;
                    case 5:
                        StartCoroutine(SelectMenuItemClick(buttonOptions.gameObject.transform, "Options"));
                        break;
                    case 6:
                        StartCoroutine(SelectMenuItemClick(buttonGear.gameObject.transform, "Gear"));
                        break;
                    default:
                        break;
                }
            }
            yield return null;
        }
        menuSelected = false;
        Debug.Log("Ended Navigating Menu");
        yield return new WaitForSeconds(0.5f);
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

    private IEnumerator SaveRoutine(Transform objTr)
    {
        PlayerMovement.player.setCheckBusyWith(objTr.gameObject);
        menuEnabled = false;
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
        yield return new WaitForSeconds(0.2f);
        menuEnabled = true;
        PlayerMovement.player.unsetCheckBusyWith(objTr.gameObject);
    }

}
