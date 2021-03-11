using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    [SerializeField] BeatInfo _beatInfo;

    float timeTracking;
    List<BeatListener> beatListeners = new List<BeatListener>();

    void Start()
    {
    }

    void FixedUpdate()
    {
        timeTracking += Time.fixedDeltaTime * _beatInfo.MusicSpeedFactor;

        //should usually only run once per Update. I.e. it should function as an if-clause.
        while (timeTracking > _beatInfo.LengthOfBeatSubdivision)
        {
            timeTracking -= _beatInfo.LengthOfBeatSubdivision;

            _beatInfo.AdvanceBySubbeat();

            // ------------ this uses magic numbers. Todo: finish refactor since we changed to 64th notes
            if (_beatInfo.CurrentSubdivisionInBeat % 4 == 0)
            {
                foreach (BeatListener l in beatListeners)
                {
                    l.OnCheckBeat(_beatInfo.CurrentBeatInBar * 4 + _beatInfo.CurrentSubdivisionInBeat / 4, 16, _beatInfo);
                }
            }
            // --------------
        }
    }

    public void SetBPM(int BPM)
    {
        _beatInfo.BPM = BPM;
    }

    public void RegisterBeatListener(BeatListener beatListener)
    {
        beatListeners.Add(beatListener);
    }

    public void UnregisterBeatListener(BeatListener beatListener)
    {
        beatListeners.Remove(beatListener);
    }
}
