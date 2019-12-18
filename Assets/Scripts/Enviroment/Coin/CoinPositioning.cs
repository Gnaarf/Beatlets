using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinPositioning : MonoBehaviour
{
    [SerializeField] float _spawnRadius = 50f;
    [SerializeField] float _minDistanceToLastPosition = 5f;

    [SerializeField]
    SoundEffectControl _soundEffectControl = default;

    [SerializeField] TextMeshPro _scoreText = default;

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
            _score++;

            Vector3 previousPos = transform.position;
            
            ResetToRandomPosition(true);
            _soundEffectControl.Play();

            _scoreText.transform.position = previousPos;
            _scoreText.text = "" + _score;
            StopAllCoroutines();
            StartCoroutine(MoveAndFade(previousPos - collider.transform.position, 1.5f));
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

    IEnumerator MoveAndFade(Vector3 direction, float fadeDuration)
    {
        direction = direction.normalized;

        float timer = 0f;
        while (timer < fadeDuration && _scoreText != null)
        {
            timer += Time.deltaTime;
            timer = Mathf.Min(timer, fadeDuration);

            _scoreText.transform.position += direction * Time.deltaTime * (fadeDuration - timer);
            _scoreText.color = new Color(_scoreText.color.r, _scoreText.color.g, _scoreText.color.b, (fadeDuration - timer) / fadeDuration);

            yield return new WaitForEndOfFrame();
        }
    }
}
