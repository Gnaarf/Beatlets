using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOnBeat 
{
    void OnBeat(); 
    
    
}
public interface IOnCheckBeat 
{
    void OnCheckBeat(int c, int groundbeat); 
}

public class BeatListener : MonoBehaviour,IOnCheckBeat
{
    public int[] hits = {255,255,255,255
                        ,255,255,255,255
                        ,255,255,255,255
                        ,255,255,255,255};
    public int ground = 4;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<MetronomeBehave>().beatListeners.Add(GetComponent<IOnCheckBeat>());
        //assing to list
    }
    public void OnCheckBeat(int c, int groundbeat){
//         ic = groundbeat / ground 
        
        for(int i = 0; i < hits.Length &&
            hits[i] <= c; i++){
            if (c == hits[i])GetComponent<IOnBeat>().OnBeat();
        }
    } 
    
}
