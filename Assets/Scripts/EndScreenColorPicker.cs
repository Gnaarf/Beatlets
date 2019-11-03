using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreenColorPicker : MonoBehaviour
{
    private void OnEnable()
    {
        TextMeshProUGUI[] textMeshes = GetComponentsInChildren<TextMeshProUGUI>();

        foreach(TextMeshProUGUI textMesh in textMeshes)
        {
            textMesh.color = ColorData.TextColor;
        }
    }
}
