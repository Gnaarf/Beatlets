using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehave : MonoBehaviour
{   
    [SerializeField,Range(0,10)]
    float speed = 1f;
    public float countDown = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position += gameObject.transform.up * speed* Time.fixedDeltaTime;
        if ( countDown < 0f ){
            Destroy(gameObject);
        }
    }
}
