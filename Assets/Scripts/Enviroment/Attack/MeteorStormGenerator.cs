using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorStormGenerator : MonoBehaviour, IOnBeat, IMusicSpeedFactor
{
    public float musicSpeedFactor = 1;
    int count = 3;
    //just use a small fast meteor
    [SerializeField]
    GameObject meteorPrefab= default;
    [SerializeField]
    Transform refTransform= default;

    [SerializeField]
    ClipController clipController;

    [SerializeField] int initcount = 16;
    float spread;


    void OnEnable(){
        count = initcount;
        clipController.SetActive(true);
        GetComponent<BeatListener>().wait0=true;


        //set this.position using refPosition and Direction (BeatBox)
        //transform.position = refTransform.position + ref.transform.up * Random.Range(1f,5f);
        //set this.position (Player)
        transform.position = refTransform.position;
        spread = 5;

    }

    public void OnBeat(int c, BeatInfo beatInfo)
    {
        if ( gameObject.activeInHierarchy) {
            var go = Instantiate(meteorPrefab).GetComponent<CMeteor>();
            go.musicSpeedFactor = musicSpeedFactor;

            // random x, y auf Einheitskreis
            float x,y;
            do{
                x = Random.value*2-1;
                y = Random.value*2-1;
            }while(Mathf.Sqrt(x*x+y*y)>1);

            go.transform.position = refTransform.position
                                       + Vector3.right * x * spread
                                       + Vector3.up * y * spread;

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
