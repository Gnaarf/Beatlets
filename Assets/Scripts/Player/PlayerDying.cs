using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDying : MonoBehaviour
{
    PlayerStateBehaviour _playerStateBehaviourRef;

    private void Start()
    {
        _playerStateBehaviourRef = GetComponent<PlayerStateBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Attack")
        {
            _playerStateBehaviourRef.ResetToSpawnPosition();
        }
    }
}