using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField]
    private float size = 1f;

    public GameObject tile;
    public float gridPositionX;
    public float gridPositionY;
    public float gridPositionZ;

    private void Start()
    {
        CreateLevel();
    }

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

    void CreateLevel()
    {
        for (float x = 0; x < 5; x += size)
        {
            for (float z = 0; z < 5; z += size)
            {
                float xPosition = x + gridPositionX;
                float yPosition = gridPositionY;
                float zPosition = z + gridPositionZ;
                Instantiate(tile, new Vector3(xPosition, yPosition, zPosition), Quaternion.identity);
            }
        }
    }
}
