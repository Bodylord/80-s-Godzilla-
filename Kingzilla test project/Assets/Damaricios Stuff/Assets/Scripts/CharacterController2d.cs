using UnityEngine;
using System.Collections;

public class CharacterController2d : MonoBehaviour
{

		enum Side
		{
				left,
				right,
				none
		}
		;
		// settings
		public float jumpforce = 250f;
		public float latteralspeed = 5f;
		private Side side = Side.left;
		public float jumpDeleay = 0.2f;
		public AudioSource jumpSound;
		public AudioSource punchSound;
		public AudioSource fireSound;
		public Animator animator;
		public ParticleSystem psHellFire;

		// state
		bool airborne = true;
		bool walking = false;

		void Start ()
		{
				psHellFire.enableEmission = false;
		}

		float jumpTime = 0;
		// Update is called once per frame
		void Update ()
		{

				Side currentSide = Side.none; 
				if (Input.GetKey (KeyCode.LeftArrow) || Input.GetAxis ("Horizontal") < 0) {
						rigidbody2D.velocity = new Vector2 (-latteralspeed, rigidbody2D.velocity.y);
						walking = true;
						currentSide = Side.left;
						
						psHellFire.transform.rotation = Quaternion.Euler (20, -90, 0); 

				}
             
				if (Input.GetKey (KeyCode.RightArrow) || Input.GetAxis ("Horizontal") > 0) {
						rigidbody2D.velocity = new Vector2 (latteralspeed, rigidbody2D.velocity.y);
						walking = true;
						currentSide = Side.right;
						psHellFire.transform.rotation = Quaternion.Euler (20, 90, 0); 
				}


				if (currentSide != Side.none && currentSide != side) {
						side = currentSide;
						turnSides ();
				}
				for (int i = 0; i < 20; i++) {
						if (Input.GetKeyDown ("joystick button " + i)) {
								Debug.Log ("Button " + i + " was pressed!");
						}
				}

				if (!airborne && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown ("joystick button 0"))) {
						jumpTime += Time.fixedDeltaTime;
						rigidbody2D.AddForce (new Vector2 (0, jumpforce));
                        if (!jumpSound.isPlaying)
						    jumpSound.Play ();
						airborne = true;
				}
				if (!airborne) {

						animator.SetBool ("walking", (Input.GetKey (KeyCode.LeftArrow) 
								|| Input.GetAxis ("Horizontal") != 0 
								|| Input.GetKey (KeyCode.RightArrow)) 
								&& rigidbody2D.velocity.x != 0 
								&& rigidbody2D.velocity.y == 0); 
				}
				animator.SetBool ("airborne", airborne);	
				
				if (Input.GetKey (KeyCode.P) || Input.GetKeyDown ("joystick button 1")) {
					
						animator.SetBool ("punch", true);
                        if (!jumpSound.isPlaying)
						    jumpSound.Play ();

				} else {

						animator.SetBool ("punch", false);

				}
				if (Input.GetKey (KeyCode.O) || Input.GetKeyDown ("joystick button 2")) {
			
						animator.SetBool ("tailPunch", true);
                        if (!jumpSound.isPlaying)
						    jumpSound.Play ();
			
				} else {
			
						animator.SetBool ("tailPunch", false);

				}

				if ((Input.GetKey (KeyCode.I) || Input.GetKeyDown ("joystick button 3")) && !psHellFire.enableEmission) {
			
						psHellFire.enableEmission = true;
                        if (!fireSound.isPlaying)
						    fireSound.Play ();
						
				} else
				if ((Input.GetKeyUp (KeyCode.I) || Input.GetKeyUp ("joystick button 3")) && psHellFire.enableEmission) {
			
						psHellFire.enableEmission = false;
						fireSound.Stop ();
			
				}

	
		}

		void OnCollisionEnter2D (Collision2D collision)
		{
				foreach (ContactPoint2D p in collision.contacts) {
						if (p.normal.y > 0.5f) {
								airborne = false;
						}
				}
		}

		private void turnSides ()
		{
				Vector3 theScale = transform.localScale;
				theScale.x *= -1f;
				transform.localScale = theScale;
		}

}
