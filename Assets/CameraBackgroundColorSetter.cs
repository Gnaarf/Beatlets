using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackgroundColorSetter : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Camera>().backgroundColor = ColorDataSingleton.Instance.BackgroundVoid;
    }
}
