using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridClass : MonoBehaviour
{
    [SerializeField]
    private float size = 1f;
 


    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = Mathf.RoundToInt(position.z / size);

        Vector3 result = new Vector3(
            (float)xCount * size,
            0,
            (float)zCount * size
        );

        result += transform.position;

        return result;
    }

}
