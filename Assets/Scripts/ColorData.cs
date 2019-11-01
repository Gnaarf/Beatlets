using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorData : MonoBehaviour
{
    static ColorData Instance;

    [Header("Player")]
    [SerializeField] Color _playerColor = Color.white;
    public static Color PlayerColor { get => Instance._playerColor; }

    [Header("Obstacles")]
    [SerializeField] Color _wallColor = Color.white;
    public static Color WallColor { get => Instance._wallColor; }

    [Header("Attacks")]
    [SerializeField] Color _attackColor = Color.white;
    public static Color AttackColor { get => Instance._attackColor; }

    [SerializeField] Color _monitorColor = Color.white;
    public static Color MonitorColor { get => Instance._monitorColor; }
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
