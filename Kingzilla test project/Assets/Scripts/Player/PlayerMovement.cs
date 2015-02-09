using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    private enum Side
    {
        left,
        right,
        none
    };

    // settings
    public string forBooleanWalkingAnimation = "walkingAnimation";
    public float latteralspeed = 5f;
    private Animator animator;
    private Side side = Side.right;
    
    public AudioSource sheepSound;

    // state
    
    private bool _walking = false;

    private bool Walking
    {
        get { return _walking; }
        set
        {
            if (_walking != value)
            {
                _walking = value;
                animator.SetBool(forBooleanWalkingAnimation, value);
            }
        }
    }

    private PlayerController playerController;

    private void Start()
    {
        animator = GetComponent<Animator>();
        sheepSound = GetComponent<AudioSource>();
        playerController = GetComponent<PlayerController>();
    }

    
    // Update is called once per frame
    private void Update()
    {
        Side currentSide = Side.none;
        if (playerController.MovingLeft)
        {
            rigidbody2D.velocity = new Vector2(-latteralspeed, rigidbody2D.velocity.y);
            Walking = true;
            currentSide = Side.left;
        }

        if (playerController.MovingRight)
        {
            rigidbody2D.velocity = new Vector2(latteralspeed, rigidbody2D.velocity.y);
            Walking = true;
            currentSide = Side.right;
        }

        if (!playerController.MovingLeft && !playerController.MovingRight)
        {
            Walking = false;
        }

        if (currentSide != Side.none && currentSide != side)
        {
            side = currentSide;
            turnSides();
        }
        /*
        if (!airborne)
        {
            animator.SetBool("walking", (Input.GetKey(KeyCode.LeftArrow)
                                         || Input.GetAxis("Horizontal") != 0
                                         || Input.GetKey(KeyCode.RightArrow))
                                        && rigidbody2D.velocity.x != 0
                                        && rigidbody2D.velocity.y == 0);
        }*/
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

    

    private void turnSides()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1f;
        transform.localScale = theScale;
    }

}
