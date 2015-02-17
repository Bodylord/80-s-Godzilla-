using UnityEngine;
using System.Collections;

public class CapableCatchFire : MonoBehaviour {

	public bool isOnFire = false;
	public ParticleSystem fireParticleSystem;
    public Detonator explosion;
    public float fireOffsetPosition;
    
    public float explodeAfter;
    private float timeOnFire = 0f;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


        if (isOnFire) { 
            timeOnFire += Time.deltaTime;
            if (explodeAfter != 0 && timeOnFire > explodeAfter && explosion != null)
            {
                explodeAfter = 0;
                Explode();
            }
        }

	}

	public void startFire(){

        if (!isOnFire)
        {

            isOnFire = true;
            Vector3 newPosition = transform.position;
            newPosition.y += fireOffsetPosition;
            ParticleSystem psFire = (ParticleSystem) Instantiate(fireParticleSystem, newPosition, Quaternion.identity);
            psFire.enableEmission = true;

            psFire.transform.parent = transform;
        }


	}

    void OnCollisionEnter(Collision col)
    {
        print("Colided with: "+col.gameObject.name);
    }

    private void Explode()
    {


        Detonator exp = (Detonator) Instantiate(explosion, transform.position, Quaternion.identity);
        exp.active = true;

        Destroy(gameObject, 0.1f);
        }


    }



