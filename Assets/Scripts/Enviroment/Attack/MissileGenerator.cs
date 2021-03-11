using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileGenerator : MonoBehaviour, IOnBeat
{
    int count;
    [SerializeField]
    GameObject missilePrefab= default;
    [SerializeField]
    Transform beatBoxTransform= default;

    [SerializeField]
    ClipController clipController;

    bool measureStarted;

    void OnEnable(){
        count = 32;
        measureStarted = false;
        clipController.SetActive(true);
    }

    // Update is called once per frame
    public void OnBeat(int c, BeatInfo beatInfo)
    {
        if (measureStarted == false)
        {
            BeatListener beatListener = GetComponent<BeatListener>();
            measureStarted = c % beatListener.hits.Length == 0;
        }


        if ( gameObject.activeInHierarchy && measureStarted){
            var missile = Instantiate(missilePrefab);
            var b = missile.GetComponent<Missile>();
            b.transform.position = beatBoxTransform.position + beatBoxTransform.transform.up * 0.5f;
            b.transform.rotation = beatBoxTransform.rotation;
            if (--count == 0)
            {
                clipController.SetActive(false);
                gameObject.SetActive(false);
            }

        }
    }
}
