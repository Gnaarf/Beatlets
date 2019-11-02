using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatBoxAni : MonoBehaviour, IOnBeat
{
    bool onBeat = true; 
    // Update is called once per frame
    void Update()
    {
        if(onBeat){
            transform.localScale = Vector3.one *1.3f;
        }else{
            transform.localScale = Vector3.one;
        }
    }
    
    public void OnBeat(int c){
       onBeat = !onBeat; 
    }
}
