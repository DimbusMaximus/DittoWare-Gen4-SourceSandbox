using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleFunctDPP : MonoBehaviour
{
    public AudioClip titleCry;
    public AudioClip titleTheme;
    private AudioSource crySource;

    private bool confirm;

    public float timeLeft = 100.0f;
    public bool forcePalkia;
    public bool forceDialga;
    public bool dialgaPalkia = true; // true => dialga | false => palkia | Do not modify. Use the force variables instead.

    public SpriteRenderer TopBG;
    public SpriteRenderer BotBG;
    public Text verName;
    public GameObject Palkia;
    public GameObject Dialga;

    // Use this for initialization
    void Start()
    {
        confirm = false;
        crySource = GetComponent<AudioSource>();
        BgmHandler.main.PlayMain(titleTheme, 212436);

        dialgaPalkia = Random.Range(0, 255) > 128 ? true : false;
        if ((dialgaPalkia || forceDialga) && !forcePalkia)
        {
            verName.alignment = TextAnchor.UpperRight;
            TopBG.sprite = Resources.Load<Sprite>("Gen 4 Title Screen/TopBG_diamond");
            BotBG.sprite = Resources.Load<Sprite>("Gen 4 Title Screen/BotBG_diamond");
            Palkia.SetActive(false);
            Dialga.SetActive(true);
        }
        else
        {
            verName.alignment = TextAnchor.UpperLeft;
            TopBG.sprite = Resources.Load<Sprite>("Gen 4 Title Screen/TopBG_pearl");
            BotBG.sprite = Resources.Load<Sprite>("Gen 4 Title Screen/BotBG_pearl");
            Palkia.SetActive(true);
            Dialga.SetActive(false);
        }
    }

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0 && !confirm)
        {
            StartCoroutine(OpenMenu());
            confirm = true;
        }

        if (CrossPlatformInputManager.GetButtonDown("A") || Input.GetButtonDown("Select"))
        {
            if (!confirm)
            {
                StartCoroutine(OpenMenu());
                confirm = true;
            }
        }
    }

    private IEnumerator OpenMenu()
    {
        crySource.PlayOneShot(titleCry, 2.5f);
        yield return new WaitForSeconds(1);
        StartCoroutine(FadeOut(crySource, 0.75f));
        StartCoroutine(ScreenFade.main.Fade(false, 0.75f));
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("startup");
    }

    IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0f)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}