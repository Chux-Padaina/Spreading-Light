using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject destinationObject;
    [SerializeField] GameObject player;

    [SerializeField] float rangeX;
    [SerializeField] float rangeY;

    private LevelLoader levelLoader;

    public GameObject redScreen;

    public float health = 9;

    private float increment = 0f;

    private void Start()
    {
        levelLoader = GameObject.Find("Level Loader").GetComponent<LevelLoader>();
    }

    private void Update()
    {
        if(player.transform.position.z > 160)
        {
            levelLoader.LoadNextLevel();
        }

        if (destinationObject.transform.position == player.transform.position)
        {
            GenerateDestination();
        }

        if(health == 6)
        {
            player.GetComponent<PlayerMovement>().green.SetActive(false);
            player.GetComponent<PlayerMovement>().red.SetActive(false);
            player.GetComponent<PlayerMovement>().orange.SetActive(true);
        }

        if(health == 3)
        {
            player.GetComponent<PlayerMovement>().green.SetActive(false);
            player.GetComponent<PlayerMovement>().red.SetActive(true);
            player.GetComponent<PlayerMovement>().orange.SetActive(false);
        }

        if (health == 0)
        {
            player.GetComponent<PlayerMovement>().green.SetActive(false);
            player.GetComponent<PlayerMovement>().red.SetActive(false);
            player.GetComponent<PlayerMovement>().orange.SetActive(false);
            levelLoader.ReloadLevel();
        }
        if(redScreen.GetComponent<Image>().color.a > 0)
        {
            var color = redScreen.GetComponent<Image>().color;
            color.a -= 0.01f;
            redScreen.GetComponent<Image>().color = color;
        }
    }

    private void GenerateDestination()
    {
        float posX = Random.Range(-rangeX, rangeX);
        float posY = Random.Range(rangeY / 2, rangeY);
        increment += rangeY + posY;
        destinationObject.transform.position = new Vector3(posX, 0, increment);
    }

    public void healthReduced()
    {
        health--;
        var color = redScreen.GetComponent<Image>().color;
        color.a = 0.1f;
        redScreen.GetComponent<Image>().color = color;
    }

}

