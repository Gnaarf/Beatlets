using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    // calculate beats from time
    [SerializeField, Range(30, 240)]
    int BPM = 120;
    float startTime = 0;
    float scaleTime = 0;
    int scaleXBeat = 0;
    [SerializeField,ReadOnly] int curBPM;
    [SerializeField,ReadOnly] int xbeat;
    [SerializeField,ReadOnly] int beat;
    public List<IOnCheckBeat> beatListeners = new List<IOnCheckBeat>();
    public bool go=true;

    float musicSpeedFactor => BPM / 120f;

    void Awake(){
        startTime = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        go = true;
    }

    void FixedUpdate()
    {
        float now = Time.fixedTime;
        if (go) { go=false ;Go();}
        if (curBPM==0){
            CheckBPMchange(now); //from stop always check
        }
        int nextxbeat = Mathf.RoundToInt(Mathf.Floor((now-scaleTime)/60*(float)curBPM*16/4))+scaleXBeat;
        if(nextxbeat > xbeat)
        {
            xbeat = nextxbeat;
            beat = xbeat * 4 / 16;
            foreach(IOnCheckBeat l in beatListeners){
                l.OnCheckBeat(xbeat,16);
            }
            CheckBPMchange(now);
        }
    }

    private void CheckBPMchange(float now)
    {
        if(curBPM != BPM)
        {
            curBPM = BPM;
            scaleTime = now;
            scaleXBeat = xbeat;
            foreach (IOnCheckBeat l in beatListeners)
            {
                l.SetMusicSpeedFactor(musicSpeedFactor);
            }
        }
    }

    public void SetBPM(int BPM)
    {
        this.BPM = BPM;
    }


    public void Go()
    {
        print("GO - previous StartTime: " + startTime + ", new StartTime: " + Time.fixedTime);
        xbeat = 0;
        curBPM = 0;
        scaleXBeat = xbeat;
        startTime = Time.fixedTime;
        scaleTime = startTime;
    }
}
