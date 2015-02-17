using UnityEngine;
using System.Collections;

public class FireEmitter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnParticleCollision(GameObject other)
    {
        //Rigidbody body = other.rigidbody;
        print("OnParticleCollision: " + other.name);

            if (other.collider.gameObject.GetComponents<CapableCatchFire>().Length > 0)
            {
                print("**** new hit on capable of fire: " + other.collider.gameObject.name + " : " + other.collider.gameObject.GetComponents<CapableCatchFire>().Length);
                other.collider.gameObject.GetComponents<CapableCatchFire>()[0].startFire();
            }

 
    }

}
