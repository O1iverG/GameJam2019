using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePlacement : MonoBehaviour
{
    public GameObject defense;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse Click");
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                PlaceDefenseNear(hitInfo.point);
            }
        }
    }

    private void PlaceDefenseNear(Vector3 clickPoint)
    {
        GameObject cube = Instantiate(defense, clickPoint, Quaternion.identity);
    }
}
