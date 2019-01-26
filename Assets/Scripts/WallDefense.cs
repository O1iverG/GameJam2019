using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDefense : MonoBehaviour
{
    public float wallHealth = 200f;
    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Snupu")
        {
            wallHealth = wallHealth - 1;
        }

        if (wallHealth == 0)
        {
            Destroy(wall);
        }
    }
}
