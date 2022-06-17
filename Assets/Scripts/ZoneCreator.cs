using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCreator : MonoBehaviour
{
    public GameObject spawner;
    public float spawnLocation;
    public float zoneSize;

    private void Start()
    {
        SpawnZone();
    }
    public void SpawnZone()
    {
        Vector3 spawnVector = new Vector3(0f, 0f, spawnLocation);
        for(int i = 0; i < zoneSize; i++)
        {
            Instantiate(spawner, spawnVector, transform.rotation);
            spawnVector.z += 10f;
        }
    }



}
