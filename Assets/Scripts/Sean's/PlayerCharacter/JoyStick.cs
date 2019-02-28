using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStick : ScrollRect
{
    //Radius of the joystick.
    private float rad = 0;
    //Output value of the joystick.
    public Vector2 value;
    
    void Start()
    {
        rad = (transform as RectTransform).sizeDelta.x * 0.45f;
    }

    public override void OnDrag(PointerEventData eventData)
    {
        //Position of the stick.
        base.OnDrag(eventData);

    }

    void Update()
    {
        JoystickLimit();
        UpdateOutputValue();
    }

    /// <summary>
    /// Restrict the joystick to move inside the given area.
    /// </summary>
    void JoystickLimit()
    {
        Vector2 pos = content.anchoredPosition;
        if (pos.magnitude > rad)
        {
            pos = pos.normalized * rad;
            SetContentAnchoredPosition(pos);
        }
    }
    
    /// <summary>
    /// Update the output value of the joystick.
    /// </summary>
    void UpdateOutputValue()
    {
        value = content.localPosition / rad;
    }
}
