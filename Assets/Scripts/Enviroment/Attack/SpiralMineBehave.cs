using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMineBehave : MonoBehaviour
{
    [SerializeField] AnimationCurve animationCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
    [SerializeField] int mineCount = 40;
    [SerializeField] float totalDuration = 5f;
    float durationBetweenTwoMines { get => totalDuration / (float)mineCount; }
    [SerializeField] float maxDistanceToCenter = 40f;

    WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Expand());
    }

    IEnumerator Expand()
    {
        int spawnedMinesCount = 0;
        float timer = 0f;
        while (spawnedMinesCount < mineCount)
        {
            float prevRadian = 4 * Mathf.PI * (timer) / totalDuration;
            Vector2 prevPosition = new Vector2(Mathf.Cos(prevRadian), Mathf.Sin(prevRadian)) * ((timer) / totalDuration) * maxDistanceToCenter;
            float currRadian = 4 * Mathf.PI * (timer + durationBetweenTwoMines) / totalDuration;
            Vector2 currPosition = new Vector2(Mathf.Cos(currRadian), Mathf.Sin(currRadian)) * ((timer + durationBetweenTwoMines) / totalDuration) * maxDistanceToCenter;

            while (timer < durationBetweenTwoMines)
            {
                timer += Time.fixedDeltaTime;

                float t = (timer % durationBetweenTwoMines) / durationBetweenTwoMines;
                transform.position = Vector3.Lerp(prevPosition, currPosition, animationCurve.Evaluate(t));

                yield return waitForFixedUpdate;
            }

            // todo: spawn explosion
            spawnedMinesCount++;
            timer %= durationBetweenTwoMines;
        }
       // Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            StartCoroutine(Expand());
        }
    }
}
