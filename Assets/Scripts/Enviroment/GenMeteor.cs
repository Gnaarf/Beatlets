using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMeteor : MonoBehaviour, IOnBeat, ITimeScale
{
    [SerializeField]
    GameObject meteorPrefab= default;
    [SerializeField]
    Transform beatBoxTransform= default;

    [SerializeField]
    ClipController clipController =default;

    [SerializeField] int initcount = 3;
    int count;
    float timeScale=1;

    void OnEnable(){
        count = initcount;
        GetComponent<BeatListener>().wait0=true;
        clipController.SetActive(true);
    }

    public void OnBeat(int c){
        if ( gameObject.activeInHierarchy) {
            var go = Instantiate(meteorPrefab).GetComponent<CMeteorBehave>();
            go.timeScale=timeScale;
            go.transform.position = beatBoxTransform.position + beatBoxTransform.transform.up * Random.Range(1f,5f);
            if (--count == 0)
            {
                clipController.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
    public void SetTimeScale(float timeScale){
        this.timeScale = timeScale;
    }

}
