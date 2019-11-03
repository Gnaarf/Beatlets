using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour, IOnBeat
{ 
    [SerializeField]
    private MetronomeBehave _metronomeBehave;

    
    [SerializeField]
    ClipController _baseLine; 

    [SerializeField]
    List<ClipController> _clipList;

    private float _lastBaseLineTime = 0f;
    [SerializeField]
    private int _currentLoopCounter = 0;
    [SerializeField]
    private int _maxLoop = 7;

    [SerializeField]
    AudioClip _startGameSound;
    [SerializeField]
    AudioClip _stopGameSound;

    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        startPlaying();
    }

    private void startPlaying()
    {
        _audioSource.clip = _startGameSound;
        _audioSource.Play();
        _metronomeBehave.Go();
        _baseLine.SetActive(true);

    }

    private void Update()
    {
        debugSongControlUpdate();

        /*
        if (_lastBaseLineTime > _baseLine.AudioSource.time)
        {
            // next loop started
            _currentLoopCounter++;
            if (_currentLoopCounter > _maxLoop)
            {
                _currentLoopCounter = 0;
            }
            foreach (ClipController clipController in _clipList)
            {
                clipController.OnLoop(_currentLoopCounter);
            }
        }
        _lastBaseLineTime = _baseLine.AudioSource.time;
        */
    }

    public void StopPlaying()
    {
        _metronomeBehave.gameObject.SetActive(false);
        foreach (ClipController clipController in _clipList)
        {
            clipController.Stop();
        }
        _audioSource.clip = _stopGameSound;
        _audioSource.Play();

    }

    public void OnBeat(int c)
    {
        // next loop started
        // _baseLine.AudioSource.time = 0;
        _currentLoopCounter++;
        if (_currentLoopCounter > _maxLoop)
        {
            _currentLoopCounter = 0;
        }
        foreach (ClipController clipController in _clipList)
        {
            clipController.OnLoop(_currentLoopCounter);
        }
    }

    void debugSongControlUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            int i = 0; 
            if (_clipList.Count > i)
            {
                _clipList[i].Toggle();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            int i = 1;
            if (_clipList.Count > i)
            {
                _clipList[i].Toggle();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            int i = 2;
            if (_clipList.Count > i)
            {
                _clipList[i].Toggle();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            int i = 3;
            if (_clipList.Count > i)
            {
                _clipList[i].Toggle();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            int i = 4;
            if (_clipList.Count > i)
            {
                _clipList[i].Toggle();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            int i = 5;
            if (_clipList.Count > i)
            {
                _clipList[i].Toggle();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            int i = 6;
            if (_clipList.Count > i)
            {
                _clipList[i].Toggle();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            int i = 7;
            if (_clipList.Count > i)
            {
                _clipList[i].Toggle();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            int i = 7;
            if (_clipList.Count > i)
            {
                _clipList[i].Toggle();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            int i = 8;
            if (_clipList.Count > i)
            {
                _clipList[i].Toggle();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            int i = 9;
            if (_clipList.Count > i)
            {
                _clipList[i].Toggle();
            }
        }
    }
}