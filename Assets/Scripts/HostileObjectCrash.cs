using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileObjectCrash : MonoBehaviour
{
    private Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Crash!!!!");
        }
    }
}
