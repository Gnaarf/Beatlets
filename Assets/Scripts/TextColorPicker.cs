using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextColorPicker : MonoBehaviour
{
    [SerializeField]
    EColor color;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI textMesh = GetComponent<TextMeshProUGUI>();

        if (textMesh != null)
        {
            textMesh.color = ColorDataSingleton.GetColor(color);
        }
        else
        {
            Debug.Log("Sprite " + this.gameObject.name + " does not have a Spriterenderer");
        }
    }
}
