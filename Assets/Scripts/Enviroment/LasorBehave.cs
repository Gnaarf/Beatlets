using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasorBehave : MonoBehaviour
{
    public float countDown = 2;
    public float size = 1;
    [SerializeField] float attackEnd = -0.5f;
    [SerializeField] AnimationCurve attackIn;
    [SerializeField] GameObject monitor;
    [SerializeField] GameObject attack;

    // Start is called before the first frame update
    void Start()
    {
        attack.SetActive(false);
        attack.GetComponent<SpriteRenderer>().color=ColorDataSingleton.Instance.AttackColor;
        monitor.GetComponent<SpriteRenderer>().color= ColorDataSingleton.Instance.MonitorColor;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        countDown -=  Time.fixedDeltaTime;
        if ( countDown < 0.0f && countDown >= attackEnd){
            attack.SetActive(true);
            float s = countDown / attackEnd;
            s = attackIn.Evaluate(s);
            attack.transform.localScale = s * Vector3.right * size + Vector3.up;
        } else if ( countDown < attackEnd ){
             Destroy(gameObject);
        }
    }
}
