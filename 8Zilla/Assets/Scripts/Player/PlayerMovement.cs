using System;
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public PlayerController Controller;
    public float maxSpeed = 5f;
    public float acceleration = 5f;
    private float currentSpeed = 0;

    // Use this for initialization
    private void Start()
    {
        Controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {
        currentSpeed = Mathf.MoveTowards(currentSpeed, Controller.HorizontalMovement*maxSpeed, acceleration);
        if(currentSpeed != 0) Debug.Log(currentSpeed);
        rigidbody2D.MovePosition(Vector2.right * currentSpeed * Time.deltaTime + (Vector2)transform.position);
    }
}
