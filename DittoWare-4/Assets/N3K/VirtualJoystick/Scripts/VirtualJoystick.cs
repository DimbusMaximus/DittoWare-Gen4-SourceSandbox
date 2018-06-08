﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Image bgImg, jsImg;
    public Vector3 InputDirection { set; get; }

    private void Start()
    {
        bgImg = GetComponent<Image>();
        jsImg = GetComponentsInChildren<Image>()[1];
        InputDirection = Vector3.zero;
    }

    //EventSystems interfaces
    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle
            (   bgImg.rectTransform,
                ped.position,
                ped.pressEventCamera,
                out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

            float x = (bgImg.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
            float y = (bgImg.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

            InputDirection = new Vector3(x, 0, y);
            InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;
            jsImg.rectTransform.anchoredPosition = new Vector3(InputDirection.x * (bgImg.rectTransform.sizeDelta.x / 3)
                , InputDirection.z * (bgImg.rectTransform.sizeDelta.y / 3));
        }
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        InputDirection = Vector3.zero;
        jsImg.rectTransform.anchoredPosition = Vector3.zero;
    }
    private void Update()
    {
        CrossPlatformInputManager.SetAxisZero("Vertical");
        CrossPlatformInputManager.SetAxisZero("Horizontal");

        CrossPlatformInputManager.SetButtonUp("Vertical");
        CrossPlatformInputManager.SetButtonUp("Horizontal");

        if (Mathf.Abs(InputDirection.x) < Mathf.Abs(InputDirection.z)){
            CrossPlatformInputManager.SetButtonDown("Vertical");
            //Vertical
            if (InputDirection.z > 0)
            {
                //UP
                CrossPlatformInputManager.SetAxisPositive("Vertical");
            }
            else if (InputDirection.z < 0)
            {
                //DOWN
                CrossPlatformInputManager.SetAxisNegative("Vertical");
            }
        }
        else if(Mathf.Abs(InputDirection.x) > Mathf.Abs(InputDirection.z)) {
            CrossPlatformInputManager.SetButtonDown("Horizontal");
            //Horizontal
            if (InputDirection.x > 0)
            {
                //RIGHT
                CrossPlatformInputManager.SetAxisPositive("Horizontal");
            }
            else if (InputDirection.x < 0)
            {
                //LEFT
                CrossPlatformInputManager.SetAxisNegative("Horizontal");
            }
        }
    }
}
