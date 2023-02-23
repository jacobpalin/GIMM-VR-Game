using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclingSpawner : MonoBehaviour
{
    public Transform objectToCircleAround;

    public float speed;

    public float radius;

    public float elevationOffset;

    private Vector3 positionOffset;
    private float angle;
    // Update is called once per frame
    void LateUpdate()
    {
        positionOffset.Set(Mathf.Cos(angle) * radius, elevationOffset, Mathf.Sin(angle) * radius);
        transform.position = objectToCircleAround.position + positionOffset;
        angle += Time.deltaTime * speed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
}