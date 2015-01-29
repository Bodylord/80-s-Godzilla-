using UnityEngine;
using System.Collections;

public class SmashBar : MonoBehaviour
{

		public float speed = 5f;
		public float smeshPosition = 5f;
		bool inverted = false;
		public bool opositeDirection = false;
		float countTime = 0f;
		float initialYPosition;
		// Use this for initialization
		void Start ()
		{
				initialYPosition = transform.position.y;
		}

		// Update is called once per frame
		void Update ()
		{
	

				Vector2 currentPosition = transform.position;

			
				if (!opositeDirection) { 
						if (!inverted && currentPosition.y < (initialYPosition + smeshPosition)) {
								currentPosition.y += Time.deltaTime * speed;
						} else {
								inverted = true;
						}
						
						if (inverted && currentPosition.y >= initialYPosition) {
								currentPosition.y -= Time.deltaTime * speed;
						} else {
								inverted = false;		
						}
				} else {
						if (!inverted && currentPosition.y > (initialYPosition - smeshPosition)) {
								currentPosition.y -= Time.deltaTime * speed;
						} else {
								inverted = true;
						}
			
						if (inverted && currentPosition.y <= initialYPosition) {
								currentPosition.y += Time.deltaTime * speed;
						} else {
								inverted = false;		
						}
				}
				transform.position = currentPosition;
		}
}
