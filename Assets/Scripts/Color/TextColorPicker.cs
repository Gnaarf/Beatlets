using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextColorPicker : MonoBehaviour
{
    [SerializeField]
    EColor color;

    [Range(0f, 1f)]
    [SerializeField] float alphaModifier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        TMP_Text textMesh = GetComponent<TMP_Text>();

        if (textMesh != null)
        {
            Color c = ColorDataSingleton.GetColor(color);
            textMesh.color = new Color(c.r, c.g, c.b, alphaModifier * c.a);
        }
        else
        {
            Debug.Log("Sprite " + this.gameObject.name + " does not have a Spriterenderer");
        }
    }
}
