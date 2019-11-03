using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColorMixPicker : MonoBehaviour
{
    [SerializeField]
    EColor color1;

    [SerializeField]
    EColor color2;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        if (sprite != null)
        {
            sprite.color = Color.Lerp(ColorDataSingleton.GetColor(color1), ColorDataSingleton.GetColor(color2), 0.5f);
        }
        else
        {
            Debug.Log("Sprite " + this.gameObject.name + " does not have a Spriterenderer");
        }
    }
}
