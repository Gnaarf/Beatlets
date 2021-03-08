using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBeatGrowShrinkAnimation : MonoBehaviour, IOnBeat
{
    [SerializeField] float _maxScaleChange = 0.5f;
    [SerializeField] GrowShrinkType _type = GrowShrinkType.Grow;
    [SerializeField] float _maxDuration = 1f;
    [SerializeField] AnimationCurve _animationCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));

    enum GrowShrinkType
    {
        Grow,
        Shrink,
        Alternate,
        None,
    }

    Vector3 _startScale;
    bool _evenBeatCount = true;
    GrowShrinkType _currentType = GrowShrinkType.None;
    float timer = 0f;

    private void Start()
    {
        _startScale = transform.localScale;
    }

    public void OnBeat(int c, BeatInfo beatInfo)
    {
        if(_type == GrowShrinkType.Alternate)
        {
            _currentType = _evenBeatCount ? GrowShrinkType.Grow : GrowShrinkType.Shrink;
        }
        else
        {
            _currentType = _type;
        }
        timer = 0f;
        _evenBeatCount = !_evenBeatCount;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (_currentType == GrowShrinkType.Grow)
        {
            transform.localScale = _startScale + _animationCurve.Evaluate(timer / _maxDuration) * _maxScaleChange * Vector3.one;
        }
        else if(_currentType == GrowShrinkType.Shrink)
        {
            transform.localScale = _startScale + _animationCurve.Evaluate(1f - timer / _maxDuration) * _maxScaleChange * Vector3.one;
        }

    }
}
