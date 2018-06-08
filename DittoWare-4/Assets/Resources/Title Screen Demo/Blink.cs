using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {

    public Vector2 Scroll = new Vector2(0f, 0.25f);
    Vector2 Offset = new Vector2(0f, 0.25f);
    public Renderer rend;

    public float timeLeft = 5.0f;
    float reset;

    // Use this for initialization
    void Start ()
    {
        rend = GetComponent<Renderer>();
        reset = timeLeft;
    }
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            StartCoroutine(blink());
            timeLeft = reset;
        }
    }

    private IEnumerator blink()
    {
        Offset += Scroll;
        Offset += Scroll;
        rend.material.SetTextureOffset("_MainTex", Offset);
        yield return new WaitForSeconds(0.025f);
        Offset -= Scroll;
        rend.material.SetTextureOffset("_MainTex", Offset);
        yield return new WaitForSeconds(0.025f);
        Offset += Scroll;
        rend.material.SetTextureOffset("_MainTex", Offset);
        yield return new WaitForSeconds(0.05f);
        Offset += Scroll;
        rend.material.SetTextureOffset("_MainTex", Offset);
        yield return new WaitForSeconds(2f);
        Offset += Scroll;
        rend.material.SetTextureOffset("_MainTex", Offset);
    }
}
