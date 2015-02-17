using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

    public float punchInterval;
    private float lastTimePunch;
    public Animator animator;
    public CharacterController2d player;
    public float distance2punch;

	// Use this for initialization
	void Start () {
	
	}


	
	// Update is called once per frame
	void Update () {

        float distance = Mathf.Abs((player.gameObject.transform.position - gameObject.transform.position).x);

        if (lastTimePunch > punchInterval && distance <= distance2punch)
        {

            lastTimePunch = 0f;

            animator.SetBool("punch", true);
              
            print("Punch ...");
        }
        else
        {
            animator.SetBool("punch", false);
        }
        lastTimePunch += Time.deltaTime;
	}
}
