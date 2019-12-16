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
        if (count > 0)
        {
            if (measureStarted == false)
            {
                BeatListener beatListener = GetComponent<BeatListener>();
                measureStarted = c % beatListener.hits.Length == 0;
            }


            if (gameObject.activeInHierarchy && measureStarted)
            {
                if (--count <= 0)
                {
                    clipController.SetActive(false);
                    StartCoroutine(SetActiveAfterSeconds(4.5f, false));
                }
                var go = Instantiate(pressureWavePrefab);
                go.transform.position = beatBoxTransform.position;
            }
        }
    }

    IEnumerator SetActiveAfterSeconds(float seconds, bool active)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(active);
    }
}

