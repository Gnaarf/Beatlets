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
public interface ITimeScale
{
    void SetTimeScale(float timeScale);
}
public interface IOnCheckBeat
{
    void OnCheckBeat(int c, int groundbeat);
    void SetTimeScale(float timeScale);

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
    public float timeScale = 1;


    // Start is called before the first frame update
    void Start()
    {
        MetronomeBehave metronome = FindObjectOfType<MetronomeBehave>();
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
    public void SetTimeScale(float timeScale){
        this.timeScale = timeScale;
        foreach(ITimeScale o in GetComponents<ITimeScale>()){
            o.SetTimeScale(timeScale);
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
        MetronomeBehave metronome = FindObjectOfType<MetronomeBehave>();
        if (metronome != null)
        {
            metronome.beatListeners.Remove(GetComponent<IOnCheckBeat>());
        }
    }


}
