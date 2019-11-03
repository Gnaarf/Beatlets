using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// struct BeatData{
//     totalCount;
//
//
// }

public interface IOnBeat
{
    void OnBeat(int c);


}
public interface IOnBeat2
{
    void OnBeat2(int c);


}
public interface IOnCheckBeat
{
    void OnCheckBeat(int c, int groundbeat);
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


    // Start is called before the first frame update
    void Start()
    {

        FindObjectOfType<MetronomeBehave>().beatListeners.Add(GetComponent<IOnCheckBeat>());
        //assing to list
    }
    public void OnCheckBeat(int c, int groundbeat){
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

    void OnDestroy(){
        FindObjectOfType<MetronomeBehave>().beatListeners.Remove(this.GetComponent<IOnCheckBeat>());
    }


}
