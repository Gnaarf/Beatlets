using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDraw : MonoBehaviour
{
    [SerializeField] SpriteRenderer _idleSpriteRef = default;
    [SerializeField] SpriteRenderer _moveSpriteRef = default;
    [SerializeField] SpriteRenderer _dashSpriteRef = default;

    SpriteRenderer _activeSprite = default;

    PlayerMovement _playerMovementRef;

    PlayerMovement.MovementState _lastMovementState;

    // Start is called before the first frame update
    void Start()
    {
        _playerMovementRef = GetComponent<PlayerMovement>();
        _idleSpriteRef.color = ColorData.PlayerDefaultColor;
        _moveSpriteRef.color = ColorData.PlayerMoveColor;
        _dashSpriteRef.color = ColorData.PlayerDashColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerMovementRef != null && _lastMovementState != _playerMovementRef.CurrentState)
        {
            if (_activeSprite != null)
            {
                _activeSprite.gameObject.SetActive(false);
            }

            switch (_playerMovementRef.CurrentState)
            {
                case PlayerMovement.MovementState.Idle:
                    _activeSprite = _idleSpriteRef;
                    break;
                case PlayerMovement.MovementState.Move:
                    _activeSprite = _moveSpriteRef;
                    break;
                case PlayerMovement.MovementState.Dash:
                    _activeSprite = _dashSpriteRef;
                    break;
            }

            _activeSprite.gameObject.SetActive(true);
            _lastMovementState = _playerMovementRef.CurrentState;
        }
    }
}
