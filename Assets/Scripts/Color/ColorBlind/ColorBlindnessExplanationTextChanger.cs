using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorBlindnessExplanationTextChanger : MonoBehaviour
{
    [SerializeField] TMP_Text guiTMPText = default;
    [SerializeField] Text guiText = default;

    // Update is called once per frame
    void Update()
    {
        ColorBlindMode mode = ColorBlindnessSettings.ColorBlindMode;
        if (mode != ColorBlindMode.Normal)
        {
            if(guiTMPText != null) guiTMPText.text = $"[{ColorBlindnessSettings.ColorBlindMode}]\nthis will disable certain color palettes on level start";
            if (guiText != null) guiText.text = $"[{ColorBlindnessSettings.ColorBlindMode}]\nthis will disable certain color palettes on level start";
        }
        else
        {
            if(guiTMPText != null) guiTMPText.text = "Colorblind? Press [C] key or (Y) button";
            if(guiText!= null) guiText.text = "Colorblind? Press [C] key or (Y) button";
        }
    }
}
