using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject destinationObject;
    [SerializeField] GameObject player;

    [SerializeField] float rangeX;
    [SerializeField] float rangeY;

    private float increment = 0f;

    private void Update()
    {
        if (destinationObject.transform.position == player.transform.position)
        {
            GenerateDestination();
        }
    }

    private void GenerateDestination()
    {
        float posX = Random.Range(-rangeX, rangeX);
        float posY = Random.Range(rangeY / 2, rangeY);
        increment += rangeY + posY;
        destinationObject.transform.position = new Vector3(posX, 0, increment);
    }

    private void GenerateObstacle()
    {

    }

}

