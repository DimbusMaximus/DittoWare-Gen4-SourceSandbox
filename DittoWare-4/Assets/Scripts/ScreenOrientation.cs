using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrientation : MonoBehaviour
{
    public Camera Screen1;
    public Camera Screen2;
    public Canvas Canvas1;
    public Canvas Canvas2;
    public bool Horizontal = false;

    void Start()
    {
        /*
        var newAspectRatio = 256f / 192f;
        var difference = Mathf.Abs(newAspectRatio - Screen1.aspect);
        if (difference > 0.01) Screen1.rect = new Rect(0, .5f, 1, (0.5f - (difference / 2.56f)));
        var difference2 = Mathf.Abs(newAspectRatio - Screen2.aspect);
        if (difference2 > 0.01) Screen2.rect = new Rect(0, 0f + difference2 / 2.56f, 1, (0.5f - (difference2 / 2.56f)));
        */
    }

    // Use this for initialization

    public void ChangeSplitScreen()
    {
        Horizontal = !Horizontal;

        if (Horizontal)
        {
            Screen1.rect = new Rect(0, 0.5f, 1, 1);
            Screen2.rect = new Rect(0, 0, 1, 0.5f);
            Screen.SetResolution(256, 384, Screen.fullScreen);
        }
        else
        {
            Screen1.rect = new Rect(0, 0, 0.5f, 1);
            Screen2.rect = new Rect(0.5f, 0, 0.5f, 1);
            Screen.SetResolution(512, 192, Screen.fullScreen);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
            ChangeSplitScreen();
        //if (Input.acceleration.z > 0 && !Horizontal)
        //    ChangeSplitScreen();
    }
}
