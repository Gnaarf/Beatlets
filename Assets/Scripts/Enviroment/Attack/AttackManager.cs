using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _attackPatterns = new List<GameObject>();

    [Header("Debugging")]
    [SerializeField] GameObject _attackOverride;
    
    public void StartRandomAttackPattern()
    {
        int index = Random.Range(0, _attackPatterns.Count);

        GameObject attackPattern = _attackPatterns[index];

        if(_attackOverride != null)
        {
            attackPattern = _attackOverride;
        }

        int tries = 0;

        while (attackPattern.activeInHierarchy && tries < _attackPatterns.Count) // already active
        {
            tries++;
            attackPattern = _attackPatterns[(index + tries) % _attackPatterns.Count];
        }

        attackPattern.SetActive(true);
    }
}
