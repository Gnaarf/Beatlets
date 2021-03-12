using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileGenerator : MonoBehaviour, IOnBeat
{
    [SerializeField]
    GameObject _missilePrefab = default;
    [SerializeField]
    Transform _beatBoxTransform = default;

    [SerializeField]
    ClipController _clipController;

    [SerializeField] int _missilesPerBeat = 4;
    [SerializeField] float _durationInBeats = 8;

    bool _barStarted;
    int _misslesFiredSinceEnabled;

    void OnEnable()
    {
        _barStarted = false;
        _misslesFiredSinceEnabled = 0;
        _clipController.SetActive(true);
    }

    // Update is called once per frame
    public void OnBeat(int c, BeatInfo beatInfo)
    {
        if(!_barStarted && beatInfo.NewBarJustStarted)
        {
            _barStarted = true;
        }
        
        if (gameObject.activeInHierarchy && _barStarted && beatInfo.CurrentSubdivisionInBeat % (beatInfo.BeatSubdivisions / _missilesPerBeat) == 0)
        {
            var missile = Instantiate(_missilePrefab).GetComponent<Missile>();
            missile.transform.position = _beatBoxTransform.position + _beatBoxTransform.transform.up * 0.5f;
            missile.transform.rotation = _beatBoxTransform.rotation;
            _misslesFiredSinceEnabled++;
            if (_misslesFiredSinceEnabled >= _durationInBeats * _missilesPerBeat)
            {
                _clipController.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
