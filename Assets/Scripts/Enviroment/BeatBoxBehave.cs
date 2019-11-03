using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatBoxBehave : MonoBehaviour, IOnBeat2
{
    [SerializeField]
    GameObject meteorPrefab;

    // Start is called before the first frame update
    void Start()
    {
//         GetComponent<BeatListener>().Sixtenths();
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
       
    }
    public void OnBeat2(int c){
//         if ((c % 64) == 0){
//             var meteor = Instantiate(meteorPrefab);
//             var b = meteor.GetComponent<CMeteorBehave>();
//             b.transform.position= this.transform.position + gameObject.transform.up * Random.Range(1f,5f) ;
//         }
            
//             var meteor = Instantiate(meteorPrefab);
//             var b = meteor.GetComponent<CMeteorBehave>();
//             b.transform.position= this.transform.position + gameObject.transform.up * Random.Range(1f,5f) ;
//             
        

    }
    
}
