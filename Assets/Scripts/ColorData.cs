using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorData : MonoBehaviour
{
    public static ColorData Instance;

    [Header("Player")]
    [SerializeField] Color _playerColor = Color.white;
    public Color PlayerColor { get => _playerColor; }

    [Header("Obstacles")]
    [SerializeField] Color _wallColor = Color.white;
    public Color WallColor { get => _wallColor; }

    [Header("Attacks")]
    [SerializeField] Color _attackColor = Color.white;
    public Color AttackColor { get => _attackColor; }

    [SerializeField] Color _monitorColor = Color.white;
    public Color MonitorColor { get => _monitorColor; }



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
