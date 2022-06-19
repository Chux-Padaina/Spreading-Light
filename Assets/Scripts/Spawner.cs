using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform lineStart, lineEnd;
    public bool spawning = false;
    public float spawnFrequency = 5f;
    private float spawnTimer = 0f;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Spirit");
    }
    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer > spawnFrequency)
        {
            Spawn();
            spawnTimer = 0f;
        }
        DestroyIfPassed();
    }

    void Spawn()
    {
        float xRange = lineEnd.position.x - lineStart.position.x;
        float yRange = lineEnd.position.y - lineStart.position.y;
        float zRange = lineEnd.position.z - lineStart.position.z;
        Vector3 spawnLocation = new Vector3(lineStart.position.x + xRange * UnityEngine.Random.value,
            lineStart.position.y + yRange * UnityEngine.Random.value,
            lineStart.position.z + zRange * UnityEngine.Random.value);
        GameObject spawnObject = Instantiate(objectToSpawn);
        spawnObject.transform.position = spawnLocation;
    }

    void DestroyIfPassed()
    {
        if(transform.position.z < player.transform.position.z - 10f)
        {
            Destroy(gameObject);
        }
    }
}
