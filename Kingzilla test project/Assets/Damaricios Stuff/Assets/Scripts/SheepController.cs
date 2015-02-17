using UnityEngine;
using System.Collections;

public class SheepController : MonoBehaviour
{

		public float LeftForce = -80f;
		public float VerticalForce = 100f;
		public float RightForce = 80f;
		protected Animator animator;
		private bool grounded = false;
		private bool walking = true;
		public float xVelocity = 0.1f;


		// Use this for initialization
		void Start ()
		{
	
				animator = GetComponent<Animator> ();
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				float xDistance = 0f;
				walking = false;

				if (Input.GetKey (KeyCode.LeftArrow)) {
						xDistance -= 200f;
						walking = true;
				} else
				if (Input.GetKey (KeyCode.RightArrow)) {
						xDistance += 200;
						walking = true;
				} 

				if (walking != animator.GetBool ("walking")) {
						animator.SetBool ("walking", walking);		
				}
				
				if (xDistance != 0 && rigidbody2D.velocity.x == 0) {
			rigidbody2D.AddForce(new Vector2(xDistance,0));
						float newPosition = Mathf.SmoothDamp (transform.position.x, transform.position.x + xDistance, ref xVelocity, 0.3f);
						transform.position = new Vector3 (newPosition, transform.position.y, transform.position.z);


					
				}
		}

		void OnCollisionEnter2D (Collision2D collision)
		{
				foreach (ContactPoint2D p in collision.contacts) {
						grounded = true;
				}
		}
}
