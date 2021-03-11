using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float size;
    public float speed;
    public float distance;
    bool boom = false;
    // Start is called before the first frame update
    void Start()
    {
        var f = 1/(1+distance);
        var renderer = GetComponent<SpriteRenderer>();
        renderer.color = Color.Lerp(ColorDataSingleton.Instance.MonitorColor * new Color(1,1,1,1/(1+distance)), ColorDataSingleton.Instance.AttackColor,1/(1+distance));
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance -= speed * Time.fixedDeltaTime;
        var f = 2/(2+distance);
        f =  f<1&&f>0?f:1;
        transform.localScale = f * Vector3.one * size;
        var renderer = GetComponent<SpriteRenderer>();
        renderer.color = Color.Lerp(ColorDataSingleton.Instance.MonitorColor * new Color(1,1,1,f), ColorDataSingleton.Instance.AttackColor,f);
        if( boom ){
            //spawn Wall??
            Destroy(gameObject);
        } else if( distance < 0 ){ 
            boom = true;
            GetComponent<Collider2D>().enabled=true;
        }
        
    }
}
