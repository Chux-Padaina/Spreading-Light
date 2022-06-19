using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubeMove : MonoBehaviour
{
    public float rotateSpeed = 10f;
    public float moveSpeed = 10f;
    public float moveSide = 1f;
    private GameObject player;

    private float startlocationZ;

    private void Start()
    {
        player = GameObject.Find("Spirit");
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(Random.Range(-1f, 1f) * moveSide, 0f, -moveSpeed);
        startlocationZ = transform.position.z;
    }

    private void Update()
    {
        transform.RotateAround(transform.position, Random.rotation.eulerAngles, Time.deltaTime * rotateSpeed * -1f);
        OutOfBounds();
    }

    void OutOfBounds()
    {
        if (transform.position.z < startlocationZ - 50f)
        {
            if(transform.position.z > player.transform.position.z + 10f || transform.position.z < player.transform.position.z - 10f)
            {
                Destroy(gameObject);
            }
        }
    }
}
