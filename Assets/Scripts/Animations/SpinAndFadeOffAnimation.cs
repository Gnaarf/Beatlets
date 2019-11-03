using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpinAndFadeOffAnimation : MonoBehaviour
{
    [SerializeField] float maxRotationSpeed = 360f;
    [SerializeField] AnimationCurve _spinAnimationCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1f), new Keyframe(1, 1));
    [SerializeField] AnimationCurve _fadeAnimationCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1f), new Keyframe(1, 1));
    [SerializeField] float _maxRotationSpeed = 360f;
    [SerializeField] float _animationDuration = 1.5f;

    float _timer = 0f;
    SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sortingLayerName = "Foreground";
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if(_timer < _animationDuration)
        {
            float t = _timer / _animationDuration;
            transform.Rotate(Vector3.forward, _spinAnimationCurve.Evaluate(t) * maxRotationSpeed);
            _spriteRenderer.color = Color.Lerp(_spriteRenderer.color, Color.clear, _fadeAnimationCurve.Evaluate(t));
        }
    }
}
