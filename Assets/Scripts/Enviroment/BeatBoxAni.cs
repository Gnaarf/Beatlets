using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatBoxAni : MonoBehaviour, IOnBeat
{
    [SerializeField,Range(-1,1)]
    float rspeed = .5F;
    bool onBeat = true; 
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0,0,1), Time.deltaTime*rspeed*360);
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
