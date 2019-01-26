using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensePlacer : MonoBehaviour
{
    public GameObject defense;
    private Grid gridLayout;
    // Start is called before the first frame update
    void Start()
    {
        gridLayout = transform.parent.GetComponent<Grid>();
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
        Debug.Log("Click here");
        Debug.Log(clickPoint); 
        var finalPosition = gridLayout.LocalToCell(new Vector3(clickPoint[0], clickPoint[1], 0));
        var finaPo = gridLayout.CellToLocal(finalPosition);
        Debug.Log(finalPosition);
        Debug.Log(finaPo);
        GameObject cube = Instantiate(defense, finaPo, Quaternion.identity);
        cube.transform.localScale = new Vector3(4, 4, 4);
    }

    
}
