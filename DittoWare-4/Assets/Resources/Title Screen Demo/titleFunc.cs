using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class titleFunc : MonoBehaviour
{
    public AudioClip titleCry;
    public AudioClip titleTheme;
    private AudioSource crySource;

    private bool confirm;

    private float timeLeft = 100.0f;

    // Use this for initialization
    void Start()
    {
        confirm = false;
        timeLeft = titleTheme.length;
        crySource = GetComponent<AudioSource>();
        crySource.PlayOneShot(titleTheme, 4.5f);
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
        crySource.PlayOneShot(titleCry, 5.0f);
        yield return new WaitForSeconds(1);
        StartCoroutine(FadeOut(crySource, 0.75f));
        StartCoroutine(ScreenFade.main.Fade(false, 0.75f));
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("startup");
    }

    IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}