using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipController : MonoBehaviour
{
    [SerializeField]
    string _name;
    [SerializeField]
    bool _isActive = false;
    [SerializeField]
    int _loopLength;

    [SerializeField]
    AudioSource _audioSource;

    public AudioSource AudioSource { get => _audioSource; }

    public void OnLoop(int loopCount)
    {
        if (loopCount % _loopLength == 0)
        {
            _audioSource.time = 0;
            if (AudioSource.mute == true && _isActive == true)
            {
                AudioSource.mute = false;
            }
            else if (AudioSource.mute == false && _isActive == false)
            {
                AudioSource.mute = true;
            }
        }
    }

    private void OnValidate()
    {
        _audioSource = GetComponent<AudioSource>();

        if (AudioSource != null)
        {
            _name = AudioSource.clip.name;
            _loopLength = (int) Mathf.Ceil(AudioSource.clip.length / 2.01f);
        }
    }

    public void SetActive(bool active)
    {
        _isActive = active;
    }

    public void Toggle()
    {
        _isActive = !_isActive;
    }
}
