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

    int callCount = 0;

    void OnEnable(){
        count = 1;
        measureStarted = false;
        clipController.SetActive(true);
    }

    public void OnBeat(int c)
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
                gameObject.SetActive(false);
            }
            var go = Instantiate(pressureWavePrefab);
            go.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = callCount * 2; // outer Image
            go.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = callCount * 2 + 1; // outer Image
            callCount++;
            go.transform.position = beatBoxTransform.position - Vector3.forward * 0.5f;
        }
    }

    IEnumerator SetActiveAfterSeconds(float seconds, bool active)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(active);
    }
}

