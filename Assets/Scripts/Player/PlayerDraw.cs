using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDraw : MonoBehaviour
{
    [SerializeField] SpriteRenderer _idleSpriteRef = default;
    [SerializeField] SpriteRenderer _moveSpriteRef = default;
    [SerializeField] SpriteRenderer _dashSpriteRef = default;

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
        if (_playerMovementRef != null)
        {
            switch (_playerMovementRef.CurrentState)
            {
                default:
                case PlayerMovement.MovementState.Idle:
                    _idleSpriteRef.gameObject.SetActive(true);
                    _moveSpriteRef.gameObject.SetActive(false);
                    _dashSpriteRef.gameObject.SetActive(false);
                    break;

                case PlayerMovement.MovementState.Move:
                    _idleSpriteRef.gameObject.SetActive(false);
                    _moveSpriteRef.gameObject.SetActive(true);
                    _dashSpriteRef.gameObject.SetActive(false);
                    break;

                case PlayerMovement.MovementState.Dash:
                    _idleSpriteRef.gameObject.SetActive(false);
                    _moveSpriteRef.gameObject.SetActive(false);
                    _dashSpriteRef.gameObject.SetActive(true);
                    break;
            }
            _lastMovementState = _playerMovementRef.CurrentState;
        }
    }
}
