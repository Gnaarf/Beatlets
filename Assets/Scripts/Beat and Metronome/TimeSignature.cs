using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TimeSignature 
{
    public int BeatsPerBar;
    public int BeatNoteValue;

    public TimeSignature(int beatsPerBar, int beatNoteValue)
    {
        BeatsPerBar = beatsPerBar;
        BeatNoteValue = beatNoteValue;
    }
}
