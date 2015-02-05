using System;
using UnityEngine;
using System.Collections;

public class DumbCollider : MonoBehaviour
{

    public GameObject collidingWith { get; set; }
    public event EventHandler TriggerEnter;
    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        collidingWith = other.gameObject;
        if (TriggerEnter != null) TriggerEnter(gameObject, EventArgs.Empty);
    }

}
