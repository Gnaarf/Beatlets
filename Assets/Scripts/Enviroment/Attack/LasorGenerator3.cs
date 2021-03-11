using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasorGenerator3 : MonoBehaviour, IOnBeat, IMusicSpeedFactor
{
    [SerializeField] GameObject _lasorPrefab= default;
    [SerializeField] Transform _beatBoxTransform= default;
    [SerializeField] ClipController _clipController = default;

    [SerializeField] int _lasorCount = 8;
    [SerializeField] float _arenaRadius = 10;
    [SerializeField] Orientation _lasorOrientation = Orientation.Horizontal;
    
    int _lasorsFiredSinceEnabled;
    float _direction;
    float _rndOffset;
    float _musicSpeedFactor = 1;

    public enum Orientation
    {
        Horizontal,
        Vertical,
    }

    void OnEnable()
    {
        _lasorsFiredSinceEnabled = 0;
        GetComponent<BeatListener>().wait0 = true;
        _direction = (Random.value > 0.5) ? -1f : 1f;
        _rndOffset = Random.Range(-0.5f, 0.5f) * DistanceBetweenLasors();
        _clipController.SetActive(true);
    }

    public void OnBeat(int c, BeatInfo beatInfo)
    {
        if ( gameObject.activeInHierarchy && beatInfo.NewBeatJustStarted)
        {
            var lasor = Instantiate(_lasorPrefab).GetComponent<Lasor>();
            lasor.musicSpeedFactor = _musicSpeedFactor;
            float move = _direction * (_arenaRadius - _lasorsFiredSinceEnabled * DistanceBetweenLasors()) + _rndOffset;
            lasor.transform.position = _beatBoxTransform.position + move * (_lasorOrientation == Orientation.Horizontal ? Vector3.up : Vector3.right);
            lasor.transform.up = _lasorOrientation == Orientation.Horizontal ? Vector3.right : Vector3.up;

            _lasorsFiredSinceEnabled++;
            if(_lasorsFiredSinceEnabled >= _lasorCount)
            {
                _clipController.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }

    public void SetMusicSpeedFactor(float musicSpeedFactor)
    {
        this._musicSpeedFactor = musicSpeedFactor;
    }

    private float DistanceBetweenLasors()
    {
        return _arenaRadius * 2f / (_lasorCount - 1);
    }
}
