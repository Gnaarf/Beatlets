using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
    [SerializeField] float _dashDistance = 4f;
    [SerializeField] float _dashDuration = 0.2f;
    [SerializeField] float _dashCoolDown = 1f;

    [SerializeField]
    SoundEffectControl _dashEffect;
    
    public MovementState CurrentState { get; private set; } 

    public Vector3 CurrentMovement { get; private set; }

    public float DashCoolDown { get => _dashCoolDown; }

    private float DashSpeed => _dashDistance / _dashDuration;

    private float _lastDashActivationTime = float.MinValue;
    
    public enum MovementState
    {
        Idle,
        Move,
        Dash,
        None,
    }

    private float GetCurrentSpeed()
    {
        switch (CurrentState)
        {
            default:
            case MovementState.Idle:
                return 0f;
            case MovementState.Move:
                return _speed;
            case MovementState.Dash:
                return DashSpeed;
        }
    }
    private void FixedUpdate()
    {
        // get User Input
        Vector2 movementInput = Input.GetAxis("Horizontal") * Vector3.right + Input.GetAxis("Vertical") * Vector3.up;

        // update dash stuff
        float timeSinceLastDashActivation = Time.time - _lastDashActivationTime;
        if (Input.GetAxis("Fire1") > 0f && timeSinceLastDashActivation > _dashCoolDown && movementInput.sqrMagnitude > float.Epsilon)
        {
            _lastDashActivationTime = Time.time;
            _dashEffect.Play();
        }
        CurrentState = timeSinceLastDashActivation < _dashDuration ? MovementState.Dash : CurrentState;

        UpdateState(timeSinceLastDashActivation, movementInput);

        CurrentMovement = GetCurrentSpeed() * movementInput * Time.fixedDeltaTime;
        transform.position += CurrentMovement;

        // rotations
        if (movementInput.sqrMagnitude > float.Epsilon)
        {
            transform.up = Vector3.Lerp(transform.up, movementInput, 0.8f);
        }
    }

    private void UpdateState(float timeSinceLastDashActivation, Vector2 movementVector)
    {
        if (timeSinceLastDashActivation < _dashDuration)
        {
            CurrentState = MovementState.Dash;
        }
        else if (movementVector.sqrMagnitude > float.Epsilon)
        {
            CurrentState = MovementState.Move;
        }
        else
        {
            CurrentState = MovementState.Idle;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Player: onCollisionEnter: " + collision.otherCollider.name);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        print("Player: onTriggerEnter: " + collider.name);

        if (collider.tag == "Wall")
        {
            //transform.position -= CurrentMovement;
            //Vector3 closestPoint = collider.ClosestPoint(transform.position);
            //transform.position = closestPoint + (transform.position - closestPoint).normalized * (transform.lossyScale.x + transform.lossyScale.y) * 0.25f;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Wall")
        {
            //Vector3 closestPoint = collider.ClosestPoint(transform.position);
            //transform.position = closestPoint + (transform.position - closestPoint).normalized * (transform.lossyScale.x + transform.lossyScale.y) * 0.25f;
        }
    }
}