using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDataSingleton : MonoBehaviour
{
    public static ColorData Instance;

    [SerializeField]
    ColorData selectedColorData;

    [Header("Debugging")]
    [SerializeField]
    ColorData _testData; 

    private void Awake()
    {
        if (Instance == null)
        {
            if (_testData != null)
            {
                Instance = _testData;
            }
            else
            {
                SetRandomColorData();
            }
            selectedColorData = Instance;
        }
    }

    void SetRandomColorData()
    {
        ColorData[] colorDataArray = GetComponentsInChildren<ColorData>();
        int index = Random.Range(0, colorDataArray.Length);
        print("index: " + index);

        Instance = colorDataArray[index];
    }
}
