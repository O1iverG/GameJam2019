using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementTopLeft : MonoBehaviour
{
    public float speed = 40f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0.0f, 0.0f, -1.0f);
        rb.AddForce(movement * speed);
    }
}
