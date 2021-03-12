using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasorGenerator : MonoBehaviour, IOnBeat, IMusicSpeedFactor
{
    [SerializeField] GameObject _lasorPrefab = default;
    [SerializeField] Transform _beatBoxTransform = default;
    [SerializeField] ClipController _clipController = default;

    int _count;
    float _musicSpeedFactor = 1;
    
    void OnEnable()
    {
        _count = 6;
        GetComponent<BeatListener>().wait0 = true;
        _clipController.SetActive(true);
    }

    public void OnBeat(int c, BeatInfo beatInfo)
    {
        if (gameObject.activeInHierarchy)
        {
            if (--_count <= 0)
            {
                _clipController.SetActive(false);
                gameObject.SetActive(false);
            }
            var go = Instantiate(_lasorPrefab).GetComponent<Lasor>();
            go.musicSpeedFactor = _musicSpeedFactor;
            go.transform.position = _beatBoxTransform.position;
            go.transform.rotation = _beatBoxTransform.rotation;
        }
    }
    public void SetMusicSpeedFactor(float musicSpeedFactor)
    {
        this._musicSpeedFactor = musicSpeedFactor;
    }
}
