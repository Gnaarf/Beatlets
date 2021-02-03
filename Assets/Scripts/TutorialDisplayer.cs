using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TutorialDisplayer : MonoBehaviour
{
    [Header("Time until Tutorials appear:")]
    [SerializeField] float _firstMoveTutorialAppear = 7f;
    [SerializeField] float _moveTutorialReappear = 30f;
    [SerializeField] float _MoveDurationUntilDashTutorialAppear = 8f;

    [Space]
    [SerializeField] PlayerMovement _playerMovement;

    [SerializeField] InputChecker.InputType _defaultInputDevice;

    [SerializeField] GameObject _tutorialBoxBackground;
    [SerializeField] GameObject _keyboardMove;
    [SerializeField] GameObject _keyboardDash;
    [SerializeField] GameObject _gamePadMove;
    [SerializeField] GameObject _gamePadDash;

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
        _currentInputDevice = _defaultInputDevice;
    }

    float a = 0f;

    // Update is called once per frame
    void Update()
    {
        UpdateTimeVariables();

        if((Time.time - _timeOfLastMovement > _firstMoveTutorialAppear && !_hasMovedBefore) ||
            Time.time - _timeOfLastMovement > _moveTutorialReappear)
        {
            _tutorialBoxBackground.SetActive(true);
            SetTutorialActive(Mechanic.Move);
        }
        else if(
            !_hasDashedBefore && 
            _timeOfLastMovement == Time.time &&
            (_hasShownDashTutorial || Time.time - _timeOfLastStandStill > _MoveDurationUntilDashTutorialAppear))
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
