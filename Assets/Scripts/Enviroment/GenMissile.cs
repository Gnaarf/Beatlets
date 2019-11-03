using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMissile : MonoBehaviour, IOnBeat
{
    int count = 30;
    [SerializeField]
    GameObject missilePrefab= default;
    [SerializeField]
    Transform beatBoxTransform= default;

    bool onBeat = false;
    
    void OnEnable(){
        count = 30;
    }
    // Update is called once per frame
    
    void FixedUpdate()
    {
        if( onBeat ){
            onBeat = false;
            var missile = Instantiate(missilePrefab);
            var b = missile.GetComponent<MissileBehave>();
            b.transform.position = beatBoxTransform.position + beatBoxTransform.transform.up * 0.5f;
            b.transform.rotation = beatBoxTransform.rotation;
            if (--count == 0 )gameObject.SetActive(false);
        }
    }
    
    public void OnBeat(int c){
       if ( gameObject.activeInHierarchy ) onBeat =true;
        
    }
}
