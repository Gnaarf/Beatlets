using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EColor
{
    PlayerDefault,
    PlayerMove,
    PlayerDash,
    Wall,
    Monitor,
    Attack,
    BackgroundFloor,
    BackgroundVoid,
    TextColor,
    TextColor2,
}

public class ColorData : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] Color _playerDefaultColor = Color.white;
    public Color PlayerDefaultColor { get => _playerDefaultColor; }

    [SerializeField] Color _playerMoveColor = Color.white;
    public Color PlayerMoveColor { get => _playerMoveColor; }

    [SerializeField] Color _playerDashColor = Color.white;
    public Color PlayerDashColor { get => _playerDashColor; }

    [Header("Obstacles")]
    [SerializeField] Color _wallColor = Color.white;
    public Color WallColor { get => _wallColor; }

    [Header("Attacks")]
    [SerializeField] Color _monitorColor = Color.white;
    public Color MonitorColor { get => _monitorColor; }

    [SerializeField] Color _attackColor = Color.white;
    public Color AttackColor { get => _attackColor; }

    [Header("Background")]
    [SerializeField] Color _backgroundFloor = Color.white;
    public Color BackgroundFloor { get => _backgroundFloor; }

    [SerializeField] Color _backgroundVoid = Color.white;
    public Color BackgroundVoid { get => _backgroundVoid; }

    [Header("UI")]
    [SerializeField] Color _textColor = Color.magenta;
    public Color TextColor { get => _textColor; }

    [SerializeField] Color _textColor2 = Color.magenta;
    public Color TextColor2 { get => _textColor2; }
}
