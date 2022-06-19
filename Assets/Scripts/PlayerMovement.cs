using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject destinationObject;
    [SerializeField] float jumpTime = 1.0f;

    public bool isMoving = false;

    public GameObject green;
    public GameObject red;
    public GameObject orange;

    // input call function
    void OnJump(InputValue value)
    {
        if (isMoving)
        {
            return;
        }
        StartCoroutine(MoveOverSeconds(gameObject, destinationObject.transform.position, jumpTime));
    }


    // move from A to B in X seconds
    private IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        isMoving = true;
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        isMoving = false;
        objectToMove.transform.position = end;
    }
}


