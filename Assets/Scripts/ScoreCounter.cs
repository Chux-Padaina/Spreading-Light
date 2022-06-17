using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public float score = 0;

    private void Update()
    {
        score = transform.position.z;
    }
}
