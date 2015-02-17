using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject tankReference;
    public float tankReleaseInterval;
    private float lastTimeTankReleased = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (lastTimeTankReleased >= tankReleaseInterval){

            lastTimeTankReleased = 0;
            GameObject tankGameObject = (GameObject) Instantiate(tankReference, transform.position, Quaternion.AngleAxis(90,new Vector3(0,1,0)));
            tankGameObject.GetComponent<Tank>().speed = -2;

        }

        lastTimeTankReleased += Time.deltaTime;
	
	}
}
