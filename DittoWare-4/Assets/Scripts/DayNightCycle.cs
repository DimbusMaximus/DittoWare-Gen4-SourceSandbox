//Original Scripts by IIColour (IIColour_Spectrum)

using UnityEngine;
using System.Collections;


public class DayNightCycle : MonoBehaviour
{
    public bool indoors;

    public bool modifyAmbientLight = false;

    public bool debugIgnoreTime = false;
    public bool debugCustomTime = false;
    public float customTime = 12f;
    public float customTimeScale = 0f;

    public Color filter = new Color(1, 1, 1, 1);

    private Light lightSource;

    private Color[] skyLight;
    private Color[] npcLight;

    private Color currentLight;
    private Color nextLight;

    private float r;
    private float g;
    private float b;

    private int hour;
    private int minute;
    private Material NPCMaterial;

    private float skyboxspeed = 0.6f; // SKYBOX SCROLL SPEED

    void Awake()
    {
        lightSource = this.GetComponent<Light>();
    }

    void Start()
    {
        //10AM - 5PM = 255,255,255,255
        // 6PM - 7PM = 240,170,110,255
        //       8PM = 120,130,220,255 
        //9PM - 10PM = 60, 80, 170,255 //Night starts 9PM
        //11PM - 3AM = 35, 50, 120,255 
        // 4AM - 5AM = 120,150,180,255 //Night ends 4AM
        // 6AM - 9AM = 160,190,255,255
        skyLight = new Color[24]
        {
            new Color(0.14f, 0.20f, 0.47f, 1), new Color(0.14f, 0.20f, 0.47f, 1), new Color(0.14f, 0.20f, 0.47f, 1),
            new Color(0.14f, 0.20f, 0.47f, 1),
            new Color(0.47f, 0.51f, 0.86f, 1), new Color(0.47f, 0.51f, 0.86f, 1), new Color(0.63f, 0.75f, 1, 1),
            new Color(0.63f, 0.75f, 1, 1),
            new Color(0.63f, 0.75f, 1, 1), new Color(0.63f, 0.75f, 1, 1), new Color(1, 1, 1, 1), new Color(1, 1, 1, 1),
            new Color(1, 1, 1, 1), new Color(1, 1, 1, 1), new Color(1, 1, 1, 1), new Color(1, 1, 1, 1),
            new Color(1, 1, 1, 1), new Color(1, 1, 1, 1), new Color(0.86f, 0.69f, 0.51f, 1),
            new Color(0.86f, 0.69f, 0.51f, 1),
            new Color(0.47f, 0.51f, 0.86f, 1), new Color(0.24f, 0.31f, 0.67f, 1), new Color(0.24f, 0.31f, 0.67f, 1),
            new Color(0.14f, 0.20f, 0.47f, 1)
        };
        
        npcLight = new Color[24]
        {
            new Color(0.76f, 0.80f, 1f, 1), new Color(0.76f, 0.80f, 1f, 1), new Color(0.76f, 0.80f, 1f, 1),
            new Color(0.76f, 0.80f, 1f, 1),
            new Color(0.82f, 0.84f, 1f, 1), new Color(0.82f, 0.84f, 1f, 1), new Color(0.92f, 0.96f, 1, 1),
            new Color(0.92f, 0.96f, 1, 1),
            new Color(0.92f, 0.96f, 1, 1), new Color(0.92f, 0.96f, 1, 1), new Color(1, 1, 1, 1), new Color(1, 1, 1, 1),
            new Color(1, 1, 1, 1), new Color(1, 1, 1, 1), new Color(1, 1, 1, 1), new Color(1, 1, 1, 1),
            new Color(1, 1, 1, 1), new Color(1, 1, 1, 1), new Color(1f, 0.92f, 0.86f, 1),
            new Color(1f, 0.92f, 0.86f, 1),
            new Color(0.91f, 0.88f, .92f, 1), new Color(0.82f, 0.84f, 1f, 1), new Color(0.82f, 0.84f, 1f, 1),
            new Color(0.76f, 0.80f, 1f, 1)
        };
        NPCMaterial = Resources.Load("Materials/Sprites_npc", typeof(Material)) as Material;
        StartCoroutine("SetTimeColor");
    }

    void Update()
    {
        if (debugCustomTime)
        {
            customTime += (Time.deltaTime / 3600f) * customTimeScale;
        }
        if (!indoors) {
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyboxspeed); //slowly scrolls the skybox
        }
    }

    void OnApplicationQuit()
    {
        currentLight = new Color(1, 1, 1, 1); //set the currentLight and nextLight appropriately
        NPCMaterial.color = new Color(1, 1, 1, 1); //Sets the tint of all npcs with material "Sprites_npc"
    }

    private IEnumerator SetTimeColor()
    {
        //repeat every second
        while (true)
        {
            hour = System.DateTime.Now.Hour; //keep track of time
            minute = System.DateTime.Now.Minute;
            if (debugCustomTime)
            {
                while (customTime >= 24)
                {
                    customTime -= 24;
                }
                while (customTime < 0)
                {
                    customTime += 24;
                }
                hour = Mathf.FloorToInt(customTime);
                minute = Mathf.FloorToInt((customTime - hour) * 60);
            }
            if (!indoors) {
                currentLight = skyLight[hour]; //set the currentLight and nextLight appropriately
                NPCMaterial.color = npcLight[hour]; //Sets the tint of all npcs with material "Sprites_npc"

                if (RenderSettings.skybox.GetColor("_Tint") != skyLight[hour])
                {
                    RenderSettings.skybox.SetColor("_Tint", skyLight[hour]);
                }
            }
            else
            {
                currentLight = filter; //set the currentLight and nextLight appropriately
                NPCMaterial.color = filter; //Sets the tint of all npcs with material "Sprites_npc"
            }
            

            if (hour < 23)
            {
                //loop back to 0
                nextLight = skyLight[hour + 1];
            }
            else
            {
                nextLight = skyLight[0];
            } //find the relative 60th fraction between current and next light
            r = currentLight.r - (((currentLight.r - nextLight.r) / 60) * minute);
            g = currentLight.g - (((currentLight.g - nextLight.g) / 60) * minute);
            b = currentLight.b - (((currentLight.b - nextLight.b) / 60) * minute);
            if (!debugIgnoreTime)
            {
                lightSource.color = new Color(r, g, b, 1) * filter;
            } //set light to be appropriately between the two points.
            if (modifyAmbientLight)
            {
                RenderSettings.ambientLight = lightSource.color;
            }

            if (!debugCustomTime)
            {
                yield return new WaitForSeconds(1f);
            } //wait a second before repeating
            else
            {
                yield return null;
            }
        }
    }
}