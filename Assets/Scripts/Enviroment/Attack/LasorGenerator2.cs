using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasorGenerator2 : MonoBehaviour, IOnBeat, IMusicSpeedFactor
{
    [SerializeField] GameObject lasorPrefab= default;
    [SerializeField] Transform beatBoxTransform= default;
    [SerializeField] ClipController clipController = default;

    [SerializeField] int initcount = 8;
    int count;
    float dir;
    float rndOffset;
    float musicSpeedFactor=1;

    void OnEnable(){
        count = initcount;
        GetComponent<BeatListener>().wait0=true;
        dir = ( Random.value > 0.5 )? -1f:1f;
        rndOffset = Random.Range(-1f,2f);
        clipController.SetActive(true);
    }

    public void OnBeat(int c, BeatInfo beatInfo)
    {
        if ( gameObject.activeInHierarchy ) {
            if ( --count == 0 ) {
                clipController.SetActive(false);
                gameObject.SetActive(false);
            }
            var go = Instantiate(lasorPrefab).GetComponent<Lasor>();
            go.musicSpeedFactor=musicSpeedFactor;
            float move = 3.0f * dir *((float) count - (float) initcount/2f + (float) rndOffset);
            go.transform.position = beatBoxTransform.position +  move * Vector3.right ;
            go.transform.up = Vector3.up ;
        }
    }
    public void SetMusicSpeedFactor(float musicSpeedFactor){
        this.musicSpeedFactor = musicSpeedFactor;
    }
}
