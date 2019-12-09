using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMeteorBehave : MonoBehaviour
{

    public float countDown = 3;
    public float size = 10;
    public float timeScale = 1;
    [SerializeField] float warnBeginn = 2f;
    [SerializeField] float warnAnimate = 1.5f;
    [SerializeField] float warnEnd = 0.5f;
    [SerializeField] float attackEnd = -0.5f;
    [SerializeField] AnimationCurve warnOut = default;
    [SerializeField] AnimationCurve attackIn = default;

    // Start is called before the first frame update
    void Start()
    {
        var renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(1,1,1,0);
        GetComponent<Collider2D>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        countDown -=  timeScale * Time.fixedDeltaTime;
        var renderer = GetComponent<SpriteRenderer>();
        var s = 1.0f;
        if ( countDown < warnBeginn && countDown > warnAnimate){
            // Monitor
            renderer.color = ColorDataSingleton.Instance.MonitorColor;
        } else if ( countDown < warnAnimate && countDown > warnEnd){
            // Monitor shrink
            renderer.color = ColorDataSingleton.Instance.MonitorColor;
            s = (countDown - warnEnd) / (warnAnimate - warnEnd);
            s = warnOut.Evaluate(s);
        } else if ( countDown < warnEnd && countDown > 0.0f) {
            // attack expand
            GetComponent<Collider2D>().enabled = true;
            s = 1-countDown/warnEnd;
            s = attackIn.Evaluate(s);
            renderer.color = Color.Lerp(ColorDataSingleton.Instance.MonitorColor * new Color(1,1,1,s), ColorDataSingleton.Instance.AttackColor,s);
        } else if ( countDown < 0.0f && countDown > attackEnd){
            GetComponent<Collider2D>().enabled=true;
        } else if ( countDown < attackEnd ){
             Destroy(gameObject);
        }

        transform.localScale = s * Vector3.one * size;

    }
}
