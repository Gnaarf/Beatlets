using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMeteorStorm : MonoBehaviour, IOnBeat
{
    int count = 3;
    [SerializeField]
    GameObject meteorPrefab= default;
    [SerializeField]
    Transform refTransform= default;

    [SerializeField]
    ClipController clipController;

    [SerializeField] int initcount = 16;
    bool measureStarted;
    float spread;


    void OnEnable(){
        count = initcount;
        clipController.SetActive(true);

        //set this.position using refPosition and Direction (BeatBox)
        //transform.position = refTransform.position + ref.transform.up * Random.Range(1f,5f);
        //set this.position (Player)
        transform.position = refTransform.position;
        spread = 5;

    }

    public void OnBeat(int c){
        if (measureStarted == false)
        {
            BeatListener beatListener = GetComponent<BeatListener>();
            measureStarted = c % beatListener.hits.Length == 0;
        }
        if ( gameObject.activeInHierarchy && measureStarted) {
            var meteor = Instantiate(meteorPrefab);
            //just use small meteor
//             var b = meteor.GetComponent<CMeteorBehave>();
//             b.size=2;

            // random x, y auf Einheitskreis
            float x,y;
            do{
                x = Random.value*2-1;
                y = Random.value*2-1;
            }while(Mathf.Sqrt(x*x+y*y)>1);

            meteor.transform.position = transform.position
                                       + Vector3.right * x * spread
                                       + Vector3.up * y * spread;

            if (--count == 0)
            {
                clipController.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
