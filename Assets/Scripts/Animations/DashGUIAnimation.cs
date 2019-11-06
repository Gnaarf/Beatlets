using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DashGUIAnimation : MonoBehaviour
{
    Image _thisImageReference;

    [SerializeField]
    PlayerMovement _playerMovementReference = default;
    
    OnBeatGrowShrinkAnimation _thisIdleAnimationReference = default;

    PlayerMovement.MovementState _previousPlayerMovementState = PlayerMovement.MovementState.None;

    private void Awake()
    {
        _thisImageReference = GetComponent<Image>();
        _thisIdleAnimationReference = GetComponent<OnBeatGrowShrinkAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_previousPlayerMovementState != PlayerMovement.MovementState.Dash && _playerMovementReference.CurrentState == PlayerMovement.MovementState.Dash)
        {
            StopAllCoroutines();
            StartCoroutine(FillEnumerator());
        }
        _previousPlayerMovementState = _playerMovementReference.CurrentState;
    }

    IEnumerator FillEnumerator()
    {
        _thisIdleAnimationReference.enabled = false;

        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

        _thisImageReference.fillAmount = 0f;

        float t = 0;

        while(t < 1f)
        {
            t += Time.deltaTime / _playerMovementReference.DashCoolDown;

            _thisImageReference.fillAmount = t;

            yield return waitForEndOfFrame;
        }

        _thisImageReference.fillAmount = 1f;
        _thisIdleAnimationReference.enabled = true;
    }
}

