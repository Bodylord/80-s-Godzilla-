using UnityEngine;
using System.Collections;

public class SpawnPeopleRandomly : MonoBehaviour
{
    public GameObject toSpawn;
    //public int maxNumberOfPeopleInScene = 30;
    public float maxIntervalToSpawn = 0.8f;
    public float minIntervalToSpawn = 0.2f;
    public float extraDistanceFromX = 0;

    private float rightXOffCamera;

    private bool _spawning = false;

    // Use this for initialization
    private void Start()
    {
        if(toSpawn == null) Debug.LogError("Missing ObjectToSpawn");
        Vector3 worldVector;
        
        do
        {
            rightXOffCamera += 0.1f;
            worldVector = Camera.main.WorldToViewportPoint(new Vector3(rightXOffCamera + Camera.main.transform.position.x, Camera.main.transform.position.y,
                Camera.main.transform.position.z));
        } while (worldVector.x <= 1 && worldVector.x >= 0);
        rightXOffCamera += 0.1f * rightXOffCamera + extraDistanceFromX;
        StartCoroutine(WaitForNextSpawn());
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_spawning)
        {
            _spawning = true;
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        Vector3 spawnPosition = new Vector3(Camera.main.transform.position.x + rightXOffCamera, transform.position.y);
        Instantiate(toSpawn, spawnPosition, Quaternion.identity);
        StartCoroutine(WaitForNextSpawn());
    }

    private IEnumerator WaitForNextSpawn()
    {
        _spawning = true;
        var toWait = Random.Range(minIntervalToSpawn, maxIntervalToSpawn);
        yield return new WaitForSeconds(toWait);
        _spawning = false;
    }
}
