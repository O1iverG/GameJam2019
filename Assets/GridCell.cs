using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    Renderer rend;
    public GameObject defense;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Vector3 center = rend.bounds.center;
        GameObject cube = Instantiate(defense, center, Quaternion.identity);
        cube.transform.localScale = new Vector3(4, 4, 4);
    }
}
