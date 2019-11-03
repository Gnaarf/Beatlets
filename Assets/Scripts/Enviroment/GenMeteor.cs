using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMeteor : MonoBehaviour, IOnBeat
{
    [SerializeField]
    GameObject meteorPrefab= default;
    [SerializeField]
    Transform beatBoxTransform= default;

    [SerializeField]
    ClipController clipController =default;

    [SerializeField] int initcount = 3;
    bool measureStarted;
    int count;

    void OnEnable(){
        count = initcount;
        measureStarted = false;
        clipController.SetActive(true);
    }

    public void OnBeat(int c){
        if (measureStarted == false)
        { //wait for Meassure (start at 0 of pattern)
            BeatListener beatListener = GetComponent<BeatListener>();
            measureStarted = c % beatListener.hits.Length == 0;
        }
        if ( gameObject.activeInHierarchy && measureStarted) {
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

}
