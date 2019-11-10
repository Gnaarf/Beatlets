using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenBPMAttack : MonoBehaviour, IOnBeat
{
    [SerializeField] int initcount = 8;
    int count;

    void OnEnable(){
        count = initcount;
        MetronomeBehave metronome = FindObjectOfType<MetronomeBehave>();
        metronome.SetBPM(180);
//         GetComponent<BeatListener>().wait0=true;
    }

    public void OnBeat(int c){
        if ( gameObject.activeInHierarchy) {
            if (--count == 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
    void OnDisable(){
        MetronomeBehave metronome = FindObjectOfType<MetronomeBehave>();
        metronome.SetBPM(120);
    }

}
