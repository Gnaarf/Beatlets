using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlindnessSettings : MonoBehaviour
{
    public static ColorBlindMode ColorBlindMode { get; private set; }

    public bool ApplyColorFilter = false;

    bool pressed = false;
    private void Update()
    {
        if (0f < Input.GetAxis("ColorBlind") && !pressed)
        {
            ColorBlindMode = (ColorBlindMode)(((int)ColorBlindMode + 1) % Enum.GetNames(typeof(ColorBlindMode)).Length);
            pressed = true;

            ColorBlindFilter cameraColorBlindFilter = Camera.main.GetComponent<ColorBlindFilter>();
            if (ApplyColorFilter && cameraColorBlindFilter != null)
            {
                cameraColorBlindFilter.mode = ColorBlindMode;
            }
        }

        if (0f == Input.GetAxis("ColorBlind"))
        {
            pressed = false;
        }
    }
}
