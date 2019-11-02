using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateBehaviour : MonoBehaviour
{
    [SerializeField] AttackManager _attackManagerReference = default;

    private void Start()
    {
        ResetToSpawnPosition();
    }

    public void ResetToSpawnPosition()
    {
        transform.position = FindObjectOfType<PlayerSpawnPositionFlag>().transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin" && _attackManagerReference != null)
        {
            _attackManagerReference.StartRandomAttackPattern();
        }
    }
}