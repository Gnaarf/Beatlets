using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasorGenerator3 : MonoBehaviour, IOnBeat, IMusicSpeedFactor
{
    [SerializeField] GameObject lasorPrefab= default;
    [SerializeField] Transform beatBoxTransform= default;
    [SerializeField] ClipController clipController = default;

    [SerializeField] int _lasorCount = 8;
    [SerializeField] float _arenaRadius = 20;
    [SerializeField] Orientation _lasorOrientation = Orientation.Horizontal;
    
    int _lasorsFiredSinceEnabled;
    float dir;
    float rndOffset;
    float musicSpeedFactor=1;

    public enum Orientation
    {
        Horizontal,
        Vertical,
    }

    void OnEnable(){
        _lasorsFiredSinceEnabled = _lasorCount;
        GetComponent<BeatListener>().wait0=true;
        dir = ( Random.value > 0.5 )? -1f:1f;
        rndOffset = Random.Range(-1f,2f);
        clipController.SetActive(true);
    }

    public void OnBeat(int c, BeatInfo beatInfo)
    {
        if ( gameObject.activeInHierarchy && beatInfo.NewBeatJustStarted)
        {
            if ( --_lasorsFiredSinceEnabled == 0 ) 
            {
                clipController.SetActive(false);
                gameObject.SetActive(false);
            }
            var lasor = Instantiate(lasorPrefab).GetComponent<Lasor>();
            lasor.musicSpeedFactor=musicSpeedFactor;
            float move = 3.0f * dir *((float) _lasorsFiredSinceEnabled - (float) _lasorCount/2f + (float) rndOffset);
            lasor.transform.position = beatBoxTransform.position +  move * Vector3.up ;
            lasor.transform.up = Vector3.right;
        }
    }
    public void SetMusicSpeedFactor(float musicSpeedFactor)
    {
        this.musicSpeedFactor = musicSpeedFactor;
    }
}
