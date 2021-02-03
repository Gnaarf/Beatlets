using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputChecker : MonoBehaviour
{
    private static InputChecker _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public enum InputType
    {
        MouseKeyboard,
        Controller
    };

    private InputType InputState = InputType.MouseKeyboard;

    void Update()
    {
        switch (InputState)
        {
            case InputType.MouseKeyboard:
                if (isControllerInput())
                {
                    InputState = InputType.Controller;
                    Debug.Log("Switched Input to Controller");
                }
                break;
            case InputType.Controller:
                if (isMouseKeyboard() && !isControllerInput())
                {
                    InputState = InputType.MouseKeyboard;
                    Debug.Log("Switched Input to Mouse/Keyboard");
                }
                break;
        }
    }

    public static InputType GetInputType()
    {
        return _instance.InputState;
    }

    public static bool IsUsingController()
    {
        return _instance.InputState == InputType.Controller;
    }

    public static bool IsUsingMouseKeyboard()
    {
        return _instance.InputState == InputType.MouseKeyboard;
    }

    private bool isMouseKeyboard()
    {
        // mouse & keyboard buttons and mouse movement
        if (Input.anyKey ||
            Input.GetMouseButton(0) ||
            Input.GetMouseButton(1) ||
            Input.GetMouseButton(2) ||
            Input.GetAxis("Mouse ScrollWheel") != 0.0f)
        {
            return true;
        }
        return false;
    }

    private bool isControllerInput()
    {
        // joystick buttons
        // check if we're not using a key for the axis' at the end 
        if (Input.GetKey(KeyCode.Joystick1Button0) ||
           Input.GetKey(KeyCode.Joystick1Button1) ||
           Input.GetKey(KeyCode.Joystick1Button2) ||
           Input.GetKey(KeyCode.Joystick1Button3) ||
           Input.GetKey(KeyCode.Joystick1Button4) ||
           Input.GetKey(KeyCode.Joystick1Button5) ||
           Input.GetKey(KeyCode.Joystick1Button6) ||
           Input.GetKey(KeyCode.Joystick1Button7) ||
           Input.GetKey(KeyCode.Joystick1Button8) ||
           Input.GetKey(KeyCode.Joystick1Button9) ||
           Input.GetKey(KeyCode.Joystick1Button10) ||
           Input.GetKey(KeyCode.Joystick1Button11) ||
           Input.GetKey(KeyCode.Joystick1Button12) ||
           Input.GetKey(KeyCode.Joystick1Button13) ||
           Input.GetKey(KeyCode.Joystick1Button14) ||
           Input.GetKey(KeyCode.Joystick1Button15) ||
           Input.GetKey(KeyCode.Joystick1Button16) ||
           Input.GetKey(KeyCode.Joystick1Button17) ||
           Input.GetKey(KeyCode.Joystick1Button18) ||
           Input.GetKey(KeyCode.Joystick1Button19) ||
           Input.GetAxis("Controler LeftStick Horizontal") != 0.0f ||
           Input.GetAxis("Controler LeftStick Vertical") != 0.0f ||
           Input.GetAxis("Controler Triggers") != 0.0f ||
           Input.GetAxis("Controler RightStick Horizontal") != 0.0f ||
           Input.GetAxis("Controler RightStick Horizontal") != 0.0f)
        {
            return true;
        }

        return false;
    }
}