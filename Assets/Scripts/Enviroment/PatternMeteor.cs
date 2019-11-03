﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternMeteor : MonoBehaviour, IOnBeat
{
    int count = 3;
    [SerializeField]
    GameObject meteorPrefab= default;
    [SerializeField]
    Transform beatBoxTransform= default;

    [SerializeField]
    ClipController clipController; 

    bool onBeat = false;
    
    void OnEnable(){
        count = 3;
        clipController.SetActive(true);
    }
    // Update is called once per frame
    
    void FixedUpdate()
    {
        if( onBeat ){
            onBeat = false;
            var meteor = Instantiate(meteorPrefab);
            var b = meteor.GetComponent<CMeteorBehave>();
            b.transform.position = beatBoxTransform.position + beatBoxTransform.transform.up * Random.Range(1f,5f);
            if (--count == 0)
            {
                clipController.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
    
    public void OnBeat(int c){
       if ( gameObject.activeInHierarchy ) onBeat =true;
        
    }
}
