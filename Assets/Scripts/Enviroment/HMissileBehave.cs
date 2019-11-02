using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMissileBehave : MonoBehaviour
{   [SerializeField,Range(0,10)]
    float speed = 1f;
    public float countDown = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        countDown -=  Time.fixedDeltaTime;
        
        //get PLayer
        //modify dir
        //follow
        gameObject.transform.position += gameObject.transform.up * speed* Time.fixedDeltaTime;
        
        if ( countDown < 0f ){
             Destroy(gameObject);
        }
        
    }
}
