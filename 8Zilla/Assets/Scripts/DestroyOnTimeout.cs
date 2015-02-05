using System;
using UnityEngine;
using System.Collections;

public class DestroyOnTimeout : MonoBehaviour
{

    public float timeout = 5f;
    private float currentTimeout = 0f;

    public event EventHandler OnBeforeDestroying;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        currentTimeout += Time.deltaTime;
        if (currentTimeout >= timeout)
        {
            if (OnBeforeDestroying != null) OnBeforeDestroying(gameObject, EventArgs.Empty);
            Destroy(gameObject);
        }
    }
}
