using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOnBeat
{
    void OnBeat(int c, BeatInfo beatInfo);
}
public interface IMusicSpeedFactor
{
    void SetMusicSpeedFactor(float musicSpeedFactor);
}

public class BeatListener : MonoBehaviour
{
    public bool[] hits = new bool[16];
    public bool wait0 = false;
    public float musicSpeedFactor = 1;


    void Start()
    {
        Metronome metronome = FindObjectOfType<Metronome>();
        if (metronome != null)
        {
            metronome.RegisterBeatListener(this);
        }
    }

    public void OnCheckBeat(int c, int groundbeat, BeatInfo beatInfo){
        if( wait0 ){
            wait0 = (c % hits.Length != 0);
            if( wait0 ) return;
        }
        if( hits[c % hits.Length]){
            foreach(IOnBeat o in GetComponents<IOnBeat>()){
                o.OnBeat(c, beatInfo);
            }

        }
    }
    public void SetMusicSpeedFactor(float musicSpeedFactor){
        this.musicSpeedFactor = musicSpeedFactor;
        foreach(IMusicSpeedFactor o in GetComponents<IMusicSpeedFactor>()){
            o.SetMusicSpeedFactor(musicSpeedFactor);
        }
    }
    public void Halfs(){
        for(int i = 0 ; i < hits.Length; i++){
            hits[i] = (i % 8 == 0);
        }
    }
    public void Fourths(){
        for(int i = 0 ; i < hits.Length; i++){
            hits[i] = (i % 4 == 0);
        }
    }
    public void Eights(){
        for(int i = 0 ; i < hits.Length; i++){
            hits[i] = (i % 8 == 0);
        }
    }
    public void Sixteenths(){
        for(int i = 0 ; i < hits.Length; i++)
            hits[i] = true;
    }

    void OnDestroy()
    {
        Metronome metronome = FindObjectOfType<Metronome>();
        if (metronome != null)
        {
            metronome.UnregisterBeatListener(GetComponent<BeatListener>());
        }
    }
}
