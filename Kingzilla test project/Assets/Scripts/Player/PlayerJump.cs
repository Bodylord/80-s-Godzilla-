using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour
{

    public string jumpTrigger = "jumpingTrigger";
    public float jumpforce = 250f;
    public float jumpDeleay = 0.2f;
    private bool airborne = true;
    private float jumpTime = 0;
    private PlayerController playerController;
    private Animator animator;
    // Use this for initialization
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        for (int i = 0; i < 20; i++)
        {
            if (Input.GetKeyDown("joystick button " + i))
            {
                Debug.Log("Button " + i + " was pressed!");
            }
        }

        if (!airborne && (playerController.Jump || Input.GetKeyDown("joystick button 16")))
        {
            jumpTime += Time.fixedDeltaTime;
            animator.SetTrigger(jumpTrigger); 
            rigidbody2D.AddForce(new Vector2(0, jumpforce));
            airborne = true;
        }


        //animator.SetBool("grounded", !airborne);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D p in collision.contacts)
        {
            if (p.normal.y > 0.5f)
            {
                airborne = false;
            }
        }
    }

}
