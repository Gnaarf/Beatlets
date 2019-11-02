using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class CircleEdgeCollider : MonoBehaviour
{
    [SerializeField] float _radius = 1f;
    [SerializeField] int _segmentCount = 8;

    private void Awake()
    {
        GetComponent<EdgeCollider2D>().points = GenerateVertices();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;

        Vector2[] vertices = GenerateVertices();
        for (int i = 0; i < vertices.Length; ++i)
        {
            Gizmos.DrawLine(transform.position + (Vector3)vertices[i] * transform.lossyScale.x, transform.position + (Vector3)vertices[(i + 1) % vertices.Length ] * transform.lossyScale.y);
        }
    }

    private Vector2[] GenerateVertices()
    {
        Vector2 scale = transform.lossyScale;

        Vector2[] vertices = new Vector2[_segmentCount + 1];
        Vector2 direction;
        float radian;

        for (int i = 0; i <= _segmentCount; ++i)
        {
            radian = 2 * Mathf.PI * i / _segmentCount;
            direction = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
            vertices[i] = direction * _radius;
        }

        return vertices;
    }
}
