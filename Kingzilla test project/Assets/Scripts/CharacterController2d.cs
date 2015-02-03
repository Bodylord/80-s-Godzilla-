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
		private Animator animator;
		private Side side = Side.left;
		public float jumpDeleay = 0.2f;
		public AudioSource sheepSound;

		// state
		bool airborne = true;
		bool walking = false;

		void Start ()
		{
				animator = GetComponent<Animator> ();
				sheepSound = GetComponent<AudioSource> ();
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
				}

				if (Input.GetKey (KeyCode.RightArrow) || Input.GetAxis ("Horizontal") > 0) {
						rigidbody2D.velocity = new Vector2 (latteralspeed, rigidbody2D.velocity.y);
						walking = true;
						currentSide = Side.right;
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

				if (!airborne && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown ("joystick button 16"))) {
						jumpTime += Time.fixedDeltaTime;
						rigidbody2D.AddForce (new Vector2 (0, jumpforce));
						sheepSound.Play ();
						airborne = true;
				}
				if (!airborne) {
						animator.SetBool ("walking", (Input.GetKey (KeyCode.LeftArrow) 
								|| Input.GetAxis ("Horizontal") != 0 
								|| Input.GetKey (KeyCode.RightArrow)) 
								&& rigidbody2D.velocity.x != 0 
								&& rigidbody2D.velocity.y == 0);
				}
				animator.SetBool ("grounded", !airborne);	
				//animator.SetBool ("grounded", !airborne);
/*				
				if (jumpTime > 0) {
						jumpTime += Time.fixedDeltaTime;
						if (jumpTime > jumpDeleay) {
								rigidbody2D.AddForce (new Vector2 (0, jumpforce));
								jumpTime = 0;
						}
				}
*/	
	
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
