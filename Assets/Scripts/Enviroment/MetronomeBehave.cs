using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetronomeBehave : MonoBehaviour
{
    [SerializeField,Range(30,240)]
    int BPM = 140;
    float startTime;
    [SerializeField,ReadOnly] int xbeat;
    [SerializeField,ReadOnly] int beat;
    public List<IOnCheckBeat> beatListeners = new List<IOnCheckBeat>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        int nextxbeat = Mathf.RoundToInt(Mathf.Floor(Time.fixedTime/60*(float)BPM*16));
        if(nextxbeat > xbeat){
            xbeat = nextxbeat;
            beat = xbeat / 4;
            int c = xbeat % 16; 
            foreach(IOnCheckBeat l in beatListeners){
                l.OnCheckBeat(c,16);
            }
            print("BEAT");
        }
        
    }
    void Go(){
        
    }
}
