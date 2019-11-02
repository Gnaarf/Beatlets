using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDying : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Attack")
        {
            print("u ded");
        }
    }
}