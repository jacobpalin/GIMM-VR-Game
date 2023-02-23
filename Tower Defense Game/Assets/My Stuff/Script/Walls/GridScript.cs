using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    [SerializeField]
    private float size = 1f;

    //public float Size { get { return size; } }

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;
        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = Mathf.RoundToInt(position.z / size);

        Vector3 result = new Vector3((float)xCount * size, (float)yCount * size, (float)zCount * size);
        result += transform.position;
        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        for (float x = -0.7f; x < .7; x += size)
        {
            for (float z = -0.7f; z < .7; z += size)
            {
                var spot = GetNearestPointOnGrid(new Vector3(x, 0.92f, z));
                Gizmos.DrawWireSphere(spot, 0.01f);
            }
        }
    }
}
