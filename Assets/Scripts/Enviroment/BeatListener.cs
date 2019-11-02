using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOnBeat 
{
    void OnBeat(int c); 
    
    
}
public interface IOnCheckBeat 
{
    void OnCheckBeat(int c, int groundbeat); 
}

public class BeatListener : MonoBehaviour,IOnCheckBeat
{
    public bool[] hits = new bool[16];
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
        if( hits[c]){GetComponent<IOnBeat>().OnBeat(c);}
    } 
    
    public void Halfs(){
        for(int i = 0 ; i < hits.Length; i++){
            hits[i]= (i % 8 == 0);
        }
    }
    public void Fourths(){
        for(int i = 0 ; i < hits.Length; i++){
            hits[i]= (i % 4 == 0);
        }
    }
    public void Eights(){
        for(int i = 0 ; i < hits.Length; i++){
            hits[i]= (i % 8 == 0);
        }
    }
    public void Sixteenths(){
        for(int i = 0 ; i < hits.Length; i++)
            hits[i]= true;
    }

    
}
