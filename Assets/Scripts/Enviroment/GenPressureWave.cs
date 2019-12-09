using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenPressureWave : MonoBehaviour, IOnBeat
{
    [SerializeField] GameObject pressureWavePrefab= default;
    [SerializeField] Transform beatBoxTransform= default;
    [SerializeField] ClipController clipController = default;

    bool measureStarted;
    int count;

    void OnEnable(){
        count = 1;
        measureStarted = false;
        clipController.SetActive(true);
    }

    public void OnBeat(int c){
        if (measureStarted == false)
        {
            BeatListener beatListener = GetComponent<BeatListener>();
            measureStarted = c % beatListener.hits.Length == 0;
        }


        if ( gameObject.activeInHierarchy && measureStarted) {
            if ( --count <= 0 ) {
                clipController.SetActive(false);
                gameObject.SetActive(false);
            }
            var go = Instantiate(pressureWavePrefab);
            go.transform.position = beatBoxTransform.position;
        }
    }
}
