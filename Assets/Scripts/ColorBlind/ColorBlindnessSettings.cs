using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlindnessSettings : MonoBehaviour
{
    public static ColorBlindMode ColorBlindMode { get; private set; }
    
    bool pressed = false;
    private void Update()
    {
        if (0f < Input.GetAxis("ColorBlind") && !pressed)
        {
            ColorBlindMode = (ColorBlindMode)(((int)ColorBlindMode + 1) % Enum.GetNames(typeof(ColorBlindMode)).Length);
            pressed = true;
        }

        if (0f == Input.GetAxis("ColorBlind"))
        {
            pressed = false;
        }
    }
}
