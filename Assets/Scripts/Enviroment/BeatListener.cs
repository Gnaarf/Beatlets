using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOnBeat
{
    void OnBeat(int c);
}
public interface IOnBeat2
{
    void OnBeat2(int c);
}
public interface IMusicSpeedFactor
{
    void SetMusicSpeedFactor(float musicSpeedFactor);
}
public interface IOnCheckBeat
{
    void OnCheckBeat(int c, int groundbeat);
    void SetMusicSpeedFactor(float musicSpeedFactor);

}

public class BeatListener : MonoBehaviour,IOnCheckBeat
{
    public bool[] hits = new bool[16];
    public bool[] hits2 = new bool[1];
    enum Style{
        Halfs,
        Fourths,
        Eights,
        Sixteenths
    };
    public bool wait0 = false;
    public float musicSpeedFactor = 1;


    // Start is called before the first frame update
    void Start()
    {
        Metronome metronome = FindObjectOfType<Metronome>();
        if (metronome != null)
        {
            metronome.beatListeners.Add(GetComponent<IOnCheckBeat>());
        }
        //assing to list
    }
    public void OnCheckBeat(int c, int groundbeat){
        if( wait0 ){
            wait0 = (c % hits.Length != 0);
            if( wait0 ) return;
        }
        if( hits[c % hits.Length]){
            foreach(IOnBeat o in GetComponents<IOnBeat>()){
                o.OnBeat(c);
            }

        }
        if( hits2[c % hits2.Length]){
            foreach(IOnBeat2 o in GetComponents<IOnBeat2>()){
                o.OnBeat2(c);

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
            metronome.beatListeners.Remove(GetComponent<IOnCheckBeat>());
        }
    }


}
