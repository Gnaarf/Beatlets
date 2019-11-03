using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenLasor3 : MonoBehaviour, IOnBeat
{
    [SerializeField] GameObject lasorPrefab= default;
    [SerializeField] Transform beatBoxTransform= default;
    [SerializeField] ClipController clipController = default;

    [SerializeField] int initcount = 4;
    bool measureStarted;
    int count;
    float dir;
    float rndOffset;

    void OnEnable(){
        count = initcount;
        dir = ( Random.value > 0.5 )? -1f:1f;
        rndOffset = Random.Range(-1f,2f);
        measureStarted = false;
//         clipController.SetActive(true);
    }

    public void OnBeat(int c){
        if (measureStarted == false)
        {
            BeatListener beatListener = GetComponent<BeatListener>();
            measureStarted = c % beatListener.hits.Length == 0;
        }


        if ( gameObject.activeInHierarchy && measureStarted) {
            if ( --count == 0 ) {
//                 clipController.SetActive(false);
                gameObject.SetActive(false);
            }
            var go = Instantiate(lasorPrefab);
            float move = 3.0f * dir *((float) count - (float) initcount/2f + (float) rndOffset);
            go.transform.position = beatBoxTransform.position +  move * Vector3.up ;
            go.transform.up = Vector3.right;
        }
    }
}
