using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileObjectCrash : MonoBehaviour
{
    private Rigidbody body;

    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        body = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CinemachineShake.instance.ShakeCamera(3f, 0.3f);
            gm.healthReduced();
            Destroy(gameObject);
        }
    }
}
