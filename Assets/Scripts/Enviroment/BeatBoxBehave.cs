using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatBoxBehave : MonoBehaviour, IOnBeat
{
    [SerializeField,Range(-1,1)]
    float rspeed = .5F;
    
    [SerializeField]
    GameObject meteorPrefab;
    
    bool onBeat = true; 
    int beat=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.Rotate(new Vector3(0,0,1), Time.fixedDeltaTime*rspeed*360);
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) ){
            //singel metore default
            var meteor = Instantiate(meteorPrefab);
            var b = meteor.GetComponent<CMeteorBehave>();
            b.transform.position= this.transform.position + gameObject.transform.up * Random.Range(1f,5f) ;
        }
        if(Input.GetKeyDown(KeyCode.M)){
            //meteorstorm
            var center = this.transform.position + gameObject.transform.up * 4 ;
            for( int i =0 ;i < 6;i++){
                var meteor = Instantiate(meteorPrefab);
                var b = meteor.GetComponent<CMeteorBehave>();
                b.size = 1;
                b.countDown  = Random.Range(3f,4f);
                b.transform.position= center + new Vector3(Random.Range(-2f,2f), Random.Range(-2f,2f),0);
            }
        }
        if(onBeat){
            transform.localScale = Vector3.one *1.3f;
        }else{
            transform.localScale = Vector3.one;
        }
        
    }
    public void OnBeat(int c){
        if ((c % 16) == 0){
            onBeat = !onBeat; 
//             var meteor = Instantiate(meteorPrefab);
//             var b = meteor.GetComponent<CMeteorBehave>();
//             b.transform.position= this.transform.position + gameObject.transform.up * Random.Range(1f,5f) ;
//             
        }

    }
    
}
