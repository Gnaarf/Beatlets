using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatBoxAni : MonoBehaviour
{
    [SerializeField,Range(-1,1)]
    float rspeed = .5F;

    void FixedUpdate()
    {
        gameObject.transform.Rotate(new Vector3(0,0,1), Time.fixedDeltaTime*rspeed*360);
    }
}
