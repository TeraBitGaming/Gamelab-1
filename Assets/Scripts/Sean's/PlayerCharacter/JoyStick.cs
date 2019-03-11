using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStick : ScrollRect
{
    /// <summary>
    /// Radius of the joystick.
    /// </summary>
    private float rad = 0;
    /// <summary>
    /// Output value of the joystick.
    /// </summary>
    public Vector2 value;

    /// <summary>
    /// 1)Set the radius of the joystick area.
    /// </summary>
    void Start()
    {
        rad = (transform as RectTransform).sizeDelta.x * 0.45f;
    }

    /// <summary>
    /// Drag-able function from [ScrollRect(Class)]
    /// </summary>
    /// <param name="eventData"></param>
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
