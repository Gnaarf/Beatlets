using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateBehaviour : MonoBehaviour
{
    private void Start()
    {
        ResetToSpawnPosition();
    }

    public void ResetToSpawnPosition()
    {
        transform.position = FindObjectOfType<PlayerSpawnPositionFlag>().transform.position;
    }
}