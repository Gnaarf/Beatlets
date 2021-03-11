using System;
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
        if (colorDataArray.Length > 0)
        {
            bool isForbiddenInColorBlindMode = false;

            do
            {
                int index = UnityEngine.Random.Range(0, colorDataArray.Length);
                print("index: " + index);

                Instance = colorDataArray[index];

                isForbiddenInColorBlindMode = Instance.IgnoreOnColorBlindModes.Contains(ColorBlindnessSettings.ColorBlindMode);
            }
            while (isForbiddenInColorBlindMode);
        }
    }

    public static Color GetColor(EColor eColor)
    {
        switch (eColor)
        {
            case EColor.PlayerDefault:
                return Instance.PlayerDefaultColor;
            case EColor.PlayerMove:
                return Instance.PlayerMoveColor;
            case EColor.PlayerDash:
                return Instance.PlayerDashColor;
            case EColor.Wall:
                return Instance.WallColor;
            case EColor.Monitor:
                return Instance.MonitorColor;
            case EColor.Attack:
                return Instance.AttackColor;
            case EColor.BackgroundFloor:
                return Instance.BackgroundFloor;
            case EColor.BackgroundVoid:
                return Instance.BackgroundVoid;
            case EColor.TextColor:
                return Instance.TextColor;
            case EColor.TextColor2:
                return Instance.TextColor2;
            default:
                return Instance.BackgroundVoid;
        }
    }
}
