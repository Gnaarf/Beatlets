using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBeatBounceAnimation : MonoBehaviour, IOnBeat
{

    [SerializeField] Vector2 movementDirection = Vector2.up;
    [SerializeField] float _speed = 2f;

    [SerializeField] DirectionChange directionChange = DirectionChange.None;

    enum DirectionChange
    {
        None,
        Mirror,
        Rotate90Clockwise,
        Rotate90CounterClockwise,
    }

    Vector3 _startPosition;
    bool evenBeatCount = true;

    private void Start()
    {
        _startPosition = transform.localPosition;
    }

    public void OnBeat(int c)
    {
        if (!evenBeatCount)
        {
            transform.localPosition = _startPosition;
        }
        evenBeatCount = !evenBeatCount;

        if (evenBeatCount)
        {
            switch (directionChange)
            {
                case DirectionChange.None: break;
                case DirectionChange.Rotate90Clockwise: movementDirection = new Vector2(-movementDirection.y, movementDirection.x); break;
                case DirectionChange.Rotate90CounterClockwise: movementDirection = new Vector2(movementDirection.y, -movementDirection.x); break;
                case DirectionChange.Mirror: movementDirection *= -1f; break;

            }
        }
    }

    void Update()
    {
        transform.localPosition += (evenBeatCount ? 1f : -1f) * (Vector3)movementDirection * Time.deltaTime * _speed;
    }
}
