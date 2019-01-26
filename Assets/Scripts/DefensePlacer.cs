using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensePlacer : MonoBehaviour
{
    private Grid grid;
    public GameObject defense;
    // Start is called before the first frame update
    void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if(Physics.Raycast(ray, out hitInfo))
            {
                PlaceDefenseNear(hitInfo.point);
            }
        }
    }

    private void PlaceDefenseNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        GameObject cube = Instantiate(defense, finalPosition, Quaternion.identity);
        cube.transform.localScale = new Vector3(4, 4, 4);
    }

    
}
