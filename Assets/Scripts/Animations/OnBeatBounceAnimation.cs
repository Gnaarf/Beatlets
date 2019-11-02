using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBeatBounceAnimation : MonoBehaviour, IOnBeat
{

    [SerializeField] Vector2 movementDirection = Vector2.up;
    [SerializeField] float _speed = 2f;

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
        movementDirection *= -1f;
        evenBeatCount = !evenBeatCount;
    }

    void Update()
    {
        transform.localPosition += (Vector3)movementDirection * Time.deltaTime * _speed;
    }
}
