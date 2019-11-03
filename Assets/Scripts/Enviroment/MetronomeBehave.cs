using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetronomeBehave : MonoBehaviour
{
    [SerializeField,Range(30,240)]
    int BPM = 120;
    float startTime = 0;
    [SerializeField,ReadOnly] int xbeat;
    [SerializeField,ReadOnly] int beat;
    public List<IOnCheckBeat> beatListeners = new List<IOnCheckBeat>();
    public bool go=true;
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
        if (go) { go=false ;Go();}
        
        int nextxbeat = Mathf.RoundToInt(Mathf.Floor((Time.fixedTime-startTime)/60*(float)BPM*4));
        if(nextxbeat > xbeat){
            xbeat = nextxbeat;
            beat = xbeat / 16;
            foreach(IOnCheckBeat l in beatListeners){
                l.OnCheckBeat(xbeat,16);
            }
        }
        
    }
    public void Go(){
        print("GO - previous StartTime: " + startTime + ", new StartTime: " + Time.fixedTime);
        xbeat=0;
        startTime=Time.fixedTime;
    }
}
