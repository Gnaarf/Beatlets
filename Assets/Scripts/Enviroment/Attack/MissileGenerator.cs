using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileGenerator : MonoBehaviour, IOnBeat
{
    [SerializeField]
    GameObject missilePrefab= default;
    [SerializeField]
    Transform beatBoxTransform= default;

    [SerializeField]
    ClipController clipController;

    [SerializeField] int _missilesPerBeat = 4;
    [SerializeField] float _durationInBeats = 8;

    bool barStarted;
    int misslesFiredSinceEnabled;

    void OnEnable()
    {
        barStarted = false;
        misslesFiredSinceEnabled = 0;
        clipController.SetActive(true);
    }

    // Update is called once per frame
    public void OnBeat(int c, BeatInfo beatInfo)
    {
        if(!barStarted && beatInfo.NewBarJustStarted)
        {
            barStarted = true;
        }
        
        if (gameObject.activeInHierarchy && barStarted && beatInfo.CurrentSubdivisionInBeat % (beatInfo.BeatSubdivisions / _missilesPerBeat) == 0)
        {
            var missile = Instantiate(missilePrefab).GetComponent<Missile>();
            missile.transform.position = beatBoxTransform.position + beatBoxTransform.transform.up * 0.5f;
            missile.transform.rotation = beatBoxTransform.rotation;
            misslesFiredSinceEnabled++;
            if (misslesFiredSinceEnabled >= _durationInBeats * _missilesPerBeat)
            {
                clipController.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
