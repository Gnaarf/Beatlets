using UnityEngine;

/// <summary>
/// Provides information on the current bar, and what note we're on.
/// </summary>
[System.Serializable]
public class BeatInfo
{
    [SerializeField] TimeSignature _timeSignature = new TimeSignature(4, 4);
    [SerializeField, Range(30, 240)] int _bpm = 120;
    [SerializeField] int _beatSubdivisions = 16;

    [SerializeField, ReadOnly] int _currentBar = 0;
    [SerializeField, ReadOnly] int _currentBeatInBar = 0;
    [SerializeField, ReadOnly] int _currentSubdivisionInBeat = 0;

    public TimeSignature TimeSignature => _timeSignature;
    /// <summary>Beats Per Minute</summary>
    public int BPM { get => _bpm; set => _bpm = value; }
    /// <summary>How many subdivisions are considered</summary>
    public int BeatSubdivisions => _beatSubdivisions;
    /// <summary>zero indexed</summary>
    public int CurrentBar => _currentBar;
    /// <summary>zero indexed. min value: 0, max value: see TimeSignature.BeatsPerBar</summary>
    public int CurrentBeatInBar => _currentBeatInBar;
    /// <summary>zero indexed [0, . min value</summary>
    public int CurrentSubdivisionInBeat => _currentSubdivisionInBeat;

    /// <summary>assumes a default speed of 120bpm</summary>
    public float MusicSpeedFactor => _bpm / 120f;
    /// <summary>length in seconds</summary>
    public float LengthOfBeat => 60f / _bpm; // : sec/beat = (sec/min) / (beats/min)
    /// <summary>length in seconds</summary>
    public float LengthOfBeatSubdivision => 60f / _bpm / _beatSubdivisions; // : : sec/beat = (sec/min) / (beats/min)
    /// <summary>length in seconds</summary>
    public float LengthOfWholeNote => _timeSignature.BeatNoteValue * (60f / _bpm);
    /// <summary>length in seconds</summary>
    public float LengthOfHalfNote => LengthOfWholeNote / 2f;
    /// <summary>length in seconds</summary>
    public float LengthOfQuarterNote => LengthOfWholeNote / 4f;
    /// <summary>length in seconds</summary>
    public float LengthOfEighthNote => LengthOfWholeNote / 8f;
    /// <summary>length in seconds</summary>
    public float LengthOfSixteenthNote => LengthOfWholeNote / 16f;
    /// <summary>length in seconds</summary>
    public float LengthOfThirtysecondNote => LengthOfWholeNote / 32f;
    /// <summary>length in seconds</summary>
    public float LengthOfSixtyfourthNote => LengthOfWholeNote / 64f;

    /// <summary>needs to have zero indexed parameters provided</summary>
    public BeatInfo(TimeSignature timeSignature, int bpm, int beatSubdivisions, int currentBar, int currentBeat, int currentBeatSubdivision)
    {
        _timeSignature = timeSignature;
        _bpm = bpm;
        _beatSubdivisions = beatSubdivisions;

        _currentBar = currentBar;
        _currentBeatInBar = currentBeat;
        _currentSubdivisionInBeat = currentBeatSubdivision;
    }

    public void AdvanceBySubbeat()
    {
        _currentSubdivisionInBeat++;
        if (_currentSubdivisionInBeat >= _beatSubdivisions)
        {
            _currentBeatInBar++;
            _currentSubdivisionInBeat = 0;
            if (_currentBeatInBar >= _timeSignature.BeatsPerBar)
            {
                _currentBar++;
                _currentBeatInBar = 0;
            }
        }
    }
}