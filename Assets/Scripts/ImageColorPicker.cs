using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageColorPicker : MonoBehaviour
{
    [SerializeField]
    EColor color;

    // Start is called before the first frame update
    void Start()
    {
        Image image = GetComponent<Image>();

        if (image != null)
        {
            image.color = ColorDataSingleton.GetColor(color);
        }
        else
        {
            Debug.Log("Sprite " + this.gameObject.name + " does not have an Image component");
        }
    }
}
