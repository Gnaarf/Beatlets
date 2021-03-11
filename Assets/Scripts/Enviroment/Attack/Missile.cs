using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{   
    [SerializeField,Range(0,10)]
    float speed = 1f;
    public float countDown = 4f;

    SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = ColorDataSingleton.Instance.AttackColor;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        countDown -=  Time.fixedDeltaTime;
        
        gameObject.transform.position += gameObject.transform.up * speed* Time.fixedDeltaTime;
        if ( countDown < 0f ){
            Destroy(gameObject);
        }
    }
}
