using UnityEngine;
using System.Collections;

public class TurnWeel : MonoBehaviour
{

		public int degreesPerSecond = 180;
		void Start ()
		{
				//mTrans = transform;
				rigidbody2D.isKinematic = true;
		}

		void Update ()
		{
				transform.Rotate (0, 0, degreesPerSecond * Time.deltaTime);
		
		}
}
