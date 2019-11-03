using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorData : MonoBehaviour
{
    static ColorData Instance;

    [Header("Player")]
    [SerializeField] Color _playerDefaultColor = Color.white;
    public static Color PlayerDefaultColor { get => Instance._playerDefaultColor; }

    [SerializeField] Color _playerMoveColor = Color.white;
    public static Color PlayerMoveColor { get => Instance._playerMoveColor; }

    [SerializeField] Color _playerDashColor = Color.white;
    public static Color PlayerDashColor { get => Instance._playerDashColor; }

    [Header("Obstacles")]
    [SerializeField] Color _wallColor = Color.white;
    public static Color WallColor { get => Instance._wallColor; }

    [Header("Attacks")]
    [SerializeField] Color _attackColor = Color.white;
    public static Color AttackColor { get => Instance._attackColor; }

    [SerializeField] Color _monitorColor = Color.white;
    public static Color MonitorColor { get => Instance._monitorColor; }


    [Header("UI")]
    [SerializeField] Color _textColor = Color.magenta;
    public static Color TextColor { get => Instance._textColor; }
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
