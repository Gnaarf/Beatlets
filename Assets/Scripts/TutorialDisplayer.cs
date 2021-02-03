using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TutorialDisplayer : MonoBehaviour
{
    [SerializeField] PlayerMovement _playerMovement;

    [SerializeField] InputChecker.InputType _defaultInputDevice;

    [SerializeField] GameObject _tutorialBoxBackground;
    [SerializeField] GameObject _keyboardMove;
    [SerializeField] GameObject _keyboardDash;
    [SerializeField] GameObject _gamePadMove;
    [SerializeField] GameObject _gamePadDash;

    Renderer[] _tutorialBoxBackgroundRenderers;
    Renderer[] _keyboardMoveRenderers;
    Renderer[] _keyboardDashRenderers;
    Renderer[] _gamePadMoveRenderers;
    Renderer[] _gamePadDashRenderers;

    InputChecker.InputType _currentInputDevice;

    bool _hasMovedBefore = false;
    float _timeOfLastStandStill = 0f;
    float _timeOfLastMovement = 0f;
    bool _hasDashedBefore = false;
    bool _hasShownDashTutorial = false;

    enum Mechanic
    {
        Move,
        Dash,
    }

    void Start()
    {
        _tutorialBoxBackgroundRenderers = _tutorialBoxBackground.GetComponentsInChildren<Renderer>();
        _keyboardMoveRenderers = _keyboardMove.GetComponentsInChildren<Renderer>();
        _keyboardDashRenderers = _keyboardDash.GetComponentsInChildren<Renderer>();
        _gamePadMoveRenderers = _gamePadMove.GetComponentsInChildren<Renderer>();
        _gamePadDashRenderers = _gamePadDash.GetComponentsInChildren<Renderer>();

        _currentInputDevice = _defaultInputDevice;
    }

    float a = 0f;

    // Update is called once per frame
    void Update()
    {
        UpdateTimeVariables();

        if((Time.time - _timeOfLastMovement > 2 && !_hasMovedBefore) ||
            Time.time - _timeOfLastMovement > 10)
        {
            _tutorialBoxBackground.SetActive(true);
            SetTutorialActive(Mechanic.Move);
        }
        else if(
            !_hasDashedBefore && 
            _timeOfLastMovement == Time.time &&
            (_hasShownDashTutorial || Time.time - _timeOfLastStandStill > 8f))
        {
            _tutorialBoxBackground.SetActive(true);
            SetTutorialActive(Mechanic.Dash);
            _hasShownDashTutorial = true;
        }
        else
        {
            _tutorialBoxBackground.SetActive(false);
            _keyboardDash.SetActive(false);
            _keyboardMove.SetActive(false);
            _gamePadDash.SetActive(false);
            _gamePadMove.SetActive(false);
        }
    }

    private void SetTutorialActive(Mechanic mechanic)
    {
        _currentInputDevice = InputChecker.GetInputType();
        _keyboardMove.SetActive(mechanic == Mechanic.Move && _currentInputDevice == InputChecker.InputType.MouseKeyboard);
        _gamePadMove.SetActive(mechanic == Mechanic.Move && _currentInputDevice == InputChecker.InputType.Controller);
        _keyboardDash.SetActive(mechanic == Mechanic.Dash && _currentInputDevice == InputChecker.InputType.MouseKeyboard);
        _gamePadDash.SetActive(mechanic == Mechanic.Dash && _currentInputDevice == InputChecker.InputType.Controller);
    }

    private void UpdateTimeVariables()
    {
        switch (_playerMovement.CurrentState)
        {
            case PlayerMovement.MovementState.Idle:
                _timeOfLastStandStill = Time.time;
                break;

            case PlayerMovement.MovementState.Move:
                _timeOfLastMovement = Time.time;
                _hasMovedBefore = true;
                break;

            case PlayerMovement.MovementState.Dash:
                _hasDashedBefore = true;
                break;
        }
    }
}
