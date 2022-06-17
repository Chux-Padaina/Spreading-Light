using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonMove : MonoBehaviour
{
    public float rotateSpeed = 10f;
    public float moveSpeed = 10f;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-moveSpeed, 0f, -moveSpeed/2);
    }

    private void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * rotateSpeed * -1f);
        OutOfBounds();
    }

    void OutOfBounds()
    {
        if(transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
