using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDraw : MonoBehaviour
{
    [SerializeField] SpriteRenderer _idleSpriteRef = default;
    [SerializeField] SpriteRenderer _moveSpriteRef = default;
    [SerializeField] SpriteRenderer _dashSpriteRef = default;

    [SerializeField] float _transitionDuration = 0.1f;

    SpriteRenderer _activeSprite = default;

    PlayerMovement _playerMovementRef;

    PlayerMovement.MovementState _lastMovementState = PlayerMovement.MovementState.None;

    WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

    // Start is called before the first frame update
    void Start()
    {
        _playerMovementRef = GetComponent<PlayerMovement>();
        _idleSpriteRef.color = ColorDataSingleton.Instance.PlayerDefaultColor;
        _idleSpriteRef.transform.localScale = Vector3.zero;
        _moveSpriteRef.color = ColorDataSingleton.Instance.PlayerMoveColor;
        _moveSpriteRef.transform.localScale = Vector3.zero;
        _dashSpriteRef.color = ColorDataSingleton.Instance.PlayerDashColor;
        _dashSpriteRef.transform.localScale = Vector3.zero;

        _activeSprite = _idleSpriteRef;

        StartCoroutine( SpriteTransition(_activeSprite, _activeSprite, _transitionDuration));
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerMovementRef != null)
        {
            // do sprite changing stuff
            if (_lastMovementState != _playerMovementRef.CurrentState)
            {
                StopAllCoroutines();

                SpriteRenderer _previousActiveSprite = _activeSprite;
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
                
                if (_lastMovementState == PlayerMovement.MovementState.Idle || _playerMovementRef.CurrentState == PlayerMovement.MovementState.Idle)
                {
                    StartCoroutine(SpriteTransition(_previousActiveSprite, _activeSprite, _transitionDuration));
                }

                _lastMovementState = _playerMovementRef.CurrentState;
            }
        }
    }

    IEnumerator SpriteTransition(SpriteRenderer current, SpriteRenderer next, float duration)
    {
        float t = 0f;
        
        while(t < 1f)
        {
            t += Time.deltaTime / duration;
            t = Mathf.Min(t, 1f);

            current.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, t * 2f);
            next.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t * 2f - 1f);
            
            yield return new WaitForEndOfFrame();
        }
    }
}
