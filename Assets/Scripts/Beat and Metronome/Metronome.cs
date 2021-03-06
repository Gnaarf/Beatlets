using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    // calculate beats from time
    [SerializeField, Range(30, 240)]
    int BPM = 120;
    [SerializeField]
    int notesPerBar = 64;
    [SerializeField, ReadOnly] int currentBar;
    [SerializeField, ReadOnly] int currentNoteInBar;

    float timeTracking;
    List<IOnCheckBeat> beatListeners = new List<IOnCheckBeat>();

    float musicSpeedFactor => BPM / 120f; // assumes a default speed of 120bpm
    float lengthOfSixtyfourthNote => 60f / (BPM * notesPerBar / 4f); // : sec/sixtyfourthnote = sec/min / (quarternotes/min * sixtyfourthnotes/quarternote)

    void Start()
    {
        currentBar = 0;
        currentNoteInBar = 0;
        timeTracking = 0;
    }

    void FixedUpdate()
    {
        timeTracking += Time.fixedDeltaTime * musicSpeedFactor;

        //should usually only run once. I.e. it should function as an if-clause.
        while(timeTracking > lengthOfSixtyfourthNote)
        {
            currentNoteInBar++;
            timeTracking -= lengthOfSixtyfourthNote;
            if(currentNoteInBar >= notesPerBar)
            {
                currentBar++;
                currentNoteInBar = 0;
            }

            BeatInfo beatInfo = new BeatInfo(currentBar, currentNoteInBar);
            // ------------ this uses magic numbers. Todo: finish refactor since we changed to 64th notes
            if (currentNoteInBar % 4 == 0)
            {
                foreach (IOnCheckBeat l in beatListeners)
                {
                    l.OnCheckBeat(currentNoteInBar / 4, 16);
                }
            }
            // --------------
        }
    }

    public void SetBPM(int BPM)
    {
        this.BPM = BPM;
    }

    public void RegisterBeatListener(IOnCheckBeat beatListener)
    {
        beatListeners.Add(beatListener);
    }

    public void UnregisterBeatListener(IOnCheckBeat beatListener)
    {
        beatListeners.Remove(beatListener);
    }
}
