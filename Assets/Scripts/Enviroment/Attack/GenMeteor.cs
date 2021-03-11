using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMeteor : MonoBehaviour, IOnBeat, IMusicSpeedFactor
{
    [SerializeField]
    GameObject meteorPrefab= default;
    [SerializeField]
    Transform beatBoxTransform= default;

    [SerializeField]
    ClipController clipController =default;

    [SerializeField] int initcount = 3;
    int count;
    float musicSpeedFactor=1;

    void OnEnable(){
        count = initcount;
        GetComponent<BeatListener>().wait0=true;
        clipController.SetActive(true);
    }

    public void OnBeat(int c, BeatInfo beatInfo)
    {
        if ( gameObject.activeInHierarchy) {
            var go = Instantiate(meteorPrefab).GetComponent<CMeteorBehave>();
            go.musicSpeedFactor = musicSpeedFactor;
            go.transform.position = beatBoxTransform.position + beatBoxTransform.transform.up * Random.Range(1f,5f);
            if (--count == 0)
            {
                clipController.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
    public void SetMusicSpeedFactor(float musicSpeedFactor){
        this.musicSpeedFactor = musicSpeedFactor;
    }

}
