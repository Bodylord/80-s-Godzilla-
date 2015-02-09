using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class RandomMovement : MonoBehaviour
{
    public float maxSpeed = 4f;
    public float minSpeed = 0.5f;
    public float maxTimeInterval = 1f;
    public float minTimeInverval = 0.2f;
    public float maxWalkingTimeInverval = 0.5f;
    public float minWalkingTimeInterval = 0.1f;


    // Use this for initialization
    private void Start()
    {
        var oneTouchDeath = GetComponent<TouchCounterDeath>();
        if (oneTouchDeath != null)
        {
            oneTouchDeath.OnDeathStart += OnDeathStartEvent;
        }
        _timerRunning = true;
        StartCoroutine(StartTimer());
    }

    private void OnDeathStartEvent(object sender, EventArgs eventArgs)
    {
        if (_routineRunning != null)
        {
            StopCoroutine(_routineRunning);
        }
        //This will ensure that we dont start routines
        _timerRunning = true;
        _walking = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_timerRunning && !_walking)
        {
            _routineRunning = StartWalking();
            StartCoroutine(_routineRunning);
        }

    }

    private bool _timerRunning = false;

    private IEnumerator _routineRunning;
    private IEnumerator StartTimer()
    {
        _timerRunning = true;
        float timeToWait = Random.Range(minTimeInverval, maxTimeInterval);
        yield return new WaitForSeconds(timeToWait);
        _timerRunning = false;
    }

    private bool _walking = false;

    private IEnumerator StartWalking()
    {
        _walking = true;

        float walkingTime = Random.Range(minWalkingTimeInterval, maxWalkingTimeInverval);
        float walkingDirection = Mathf.Sign(Random.Range(-1, 1));
        if (walkingDirection == 0) walkingDirection = Mathf.Sign(Random.Range(-1, 1));
        if (walkingDirection == 0) walkingDirection = 1;
        float timeSpent = 0f;
        float speed = Random.Range(minSpeed, maxSpeed);
        float yPosition = transform.position.y;
        while (timeSpent < walkingTime)
        {
            var newXPosition = transform.position.x + walkingDirection*speed*Time.deltaTime;
            var newPosition = new Vector2(newXPosition, yPosition);
            rigidbody2D.MovePosition(newPosition);
            timeSpent += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        _timerRunning = true;
        _walking = false;
        _routineRunning = StartTimer();
        StartCoroutine(_routineRunning);
    }

}
