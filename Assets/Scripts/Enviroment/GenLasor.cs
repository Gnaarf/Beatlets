using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenLasor : MonoBehaviour, IOnBeat, IMusicSpeedFactor
{
    [SerializeField] GameObject lasorPrefab= default;
    [SerializeField] Transform beatBoxTransform= default;
    [SerializeField] ClipController clipController = default;

    int count;
    float musicSpeedFactor = 1;

    void OnEnable(){
        count = 6;
        GetComponent<BeatListener>().wait0=true;
        clipController.SetActive(true);
    }

    public void OnBeat(int c){
        if ( gameObject.activeInHierarchy ) {
            if ( --count <= 0 ) {
                clipController.SetActive(false);
                gameObject.SetActive(false);
            }
            var go = Instantiate(lasorPrefab).GetComponent<LasorBehave>();
            go.musicSpeedFactor=musicSpeedFactor;
            go.transform.position = beatBoxTransform.position;
            go.transform.rotation = beatBoxTransform.rotation;
        }
    }
    public void SetMusicSpeedFactor(float musicSpeedFactor)
    {
        this.musicSpeedFactor = musicSpeedFactor;
    }
}
