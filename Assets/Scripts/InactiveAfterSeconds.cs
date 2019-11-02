using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactiveAfterSeconds : MonoBehaviour
{
    [SerializeField] float _seconds = 3f;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(SetInactiveAfterSeconds(gameObject, _seconds));
    }

    public static IEnumerator SetInactiveAfterSeconds(GameObject gameObject, float duration)
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }
}
