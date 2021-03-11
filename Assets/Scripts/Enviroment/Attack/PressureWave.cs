using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureWave : MonoBehaviour
{
    [SerializeField] AnimationCurve animationCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
    [SerializeField] int animationCount = 3;
    [SerializeField] float radiusExpansionPerAnimation = 5f;
    [SerializeField] float durationPerAnimation = 1f;

    [SerializeField] Transform innerGraphicTransform;
    [SerializeField] Transform outerGraphicTransform;
    [SerializeField] float width = 0.5f;

    [SerializeField] CircleEdgeCollider circleEdgeCollider;

    WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Expand());
    }

    IEnumerator Expand()
    {
        Debug.Log("START");

        float timer = 0f;
        while (timer < animationCount * durationPerAnimation)
        {
            timer += Time.fixedDeltaTime;

            float c = (int)(timer / durationPerAnimation);
            float t = timer / durationPerAnimation % 1f;

            float currentRadius = (c + animationCurve.Evaluate(t)) * radiusExpansionPerAnimation;

            innerGraphicTransform.localScale = Vector3.one * Mathf.Max(currentRadius - width * 0.5f, 0f) * 2f;
            outerGraphicTransform.localScale = Vector3.one * (currentRadius + width * 0.5f) * 2f;
            
            circleEdgeCollider.UpdateRadiusAndSegmentCount(currentRadius, circleEdgeCollider.SegmentCount);

            yield return waitForFixedUpdate;
        }
        Destroy(gameObject);
    }
}
