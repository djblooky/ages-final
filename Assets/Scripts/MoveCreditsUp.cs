using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCreditsUp : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 80f;

    private bool canMove = false;

    private void Start()
    {
        StartCoroutine(WaitToMove());
    }

    void Update()
    {
        if(canMove)
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.World);
    }

    IEnumerator WaitToMove()
    {
        yield return new WaitForSeconds(3f);
        canMove = true;
    }
}
