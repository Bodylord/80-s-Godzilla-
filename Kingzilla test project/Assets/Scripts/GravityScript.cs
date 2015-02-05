using UnityEngine;
using System.Collections;

public class GravityScript : MonoBehaviour
{

    public float gravityAcceleration = 5;
    public float maxGravitySpeed = 5;
    private float currentGravity;
    private Vector3 previousPosition;
    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        currentGravity = Mathf.MoveTowards(currentGravity, maxGravitySpeed, Time.deltaTime *gravityAcceleration);
        var nextPosition = rigidbody2D.position + Vector2.up*currentGravity*(-1)*Time.deltaTime;
        rigidbody2D.MovePosition(nextPosition);
    }
}
