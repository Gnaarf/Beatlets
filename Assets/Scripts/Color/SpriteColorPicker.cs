using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColorPicker : MonoBehaviour
{
    [SerializeField]
    EColor color;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        if (sprite != null)
        {
            sprite.color = ColorDataSingleton.GetColor(color);
        }
        else
        {
            Debug.Log("Sprite " + this.gameObject.name + " does not have a Spriterenderer");
        }
    }
}
