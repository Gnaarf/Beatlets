using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
    [SerializeField] float _dashDistance = 4f;
    [SerializeField] float _dashDuration = 0.2f;
    [SerializeField] float _dashCoolDown = 1f;
    
    public MovementState CurrentState { get; private set; } 

    private float DashSpeed => _dashDistance / _dashDuration;

    private float _lastDashActivationTime = float.MinValue;
    
    public enum MovementState
    {
        Idle,
        Move,
        Dash,
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
        // update dash stuff
        float timeSinceLastDashActivation = Time.time - _lastDashActivationTime;
        if (Input.GetAxis("Jump") > 0f && timeSinceLastDashActivation > _dashCoolDown)
        {
            _lastDashActivationTime = Time.time;
        }
        CurrentState = timeSinceLastDashActivation < _dashDuration ? MovementState.Dash : CurrentState;

        // actual movement
        Vector2 movementInput = GetCurrentMovementInput();

        UpdateState(timeSinceLastDashActivation, movementInput);

        transform.position += (Vector3)(GetCurrentSpeed() * movementInput * Time.fixedDeltaTime);

    }

    private static Vector3 GetCurrentMovementInput()
    {
        return Input.GetAxis("Horizontal") * Vector3.right + Input.GetAxis("Vertical") * Vector3.up;
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
            Vector3 closestPoint = collider.ClosestPoint(transform.position);
            transform.position -= (Vector3)(GetCurrentSpeed() * GetCurrentMovementInput() * Time.fixedDeltaTime);
            transform.position = closestPoint + (transform.position - closestPoint).normalized * (transform.lossyScale.x + transform.lossyScale.y) * 0.25f;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Wall")
        {
            Vector3 closestPoint = collider.ClosestPoint(transform.position);
            transform.position = closestPoint + (transform.position - closestPoint).normalized * (transform.lossyScale.x + transform.lossyScale.y) * 0.25f;
        }
    }
}