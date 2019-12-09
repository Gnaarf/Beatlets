using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageColorMixPicker : MonoBehaviour
{
    [SerializeField]
    EColor color1;
    [SerializeField]
    EColor color2;

    [Range(0f, 1f)]
    [SerializeField] float alphaModifier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Image image = GetComponent<Image>();

        if (image != null)
        {
            Color c = Color.Lerp(ColorDataSingleton.GetColor(color1), ColorDataSingleton.GetColor(color2), 0.5f);
            image.color = new Color(c.r, c.g, c.b, alphaModifier * c.a);
        }
        else
        {
            Debug.Log("Sprite " + this.gameObject.name + " does not have an Image component");
        }
    }
}
