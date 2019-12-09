using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPositioning : MonoBehaviour
{
    [SerializeField] float _spawnRadius = 50f;
    [SerializeField] float _minDistanceToLastPosition = 5f;

    [SerializeField]
    SoundEffectControl _soundEffectControl;

    int _score = 0; 

    public int Score { get => _score; }

    // Start is called before the first frame update
    void Start()
    {
        ResetToRandomPosition(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            ResetToRandomPosition(true);
            _soundEffectControl.Play();
            _score++;
        }
    }

    private void ResetToRandomPosition(bool considerMinDistance)
    {
        Vector3 newPosition;
        do
        {
            newPosition = new Vector3(Random.Range(-_spawnRadius, _spawnRadius), Random.Range(-_spawnRadius, _spawnRadius));
        }
        while (newPosition.magnitude >= _spawnRadius || (considerMinDistance && Vector2.Distance(transform.position, newPosition) < _minDistanceToLastPosition));

        transform.position = newPosition;
    }
}
