using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float HorizontalMovement
    {
        get
        {
            return Input.GetAxis("Horizontal");
        }
    }

    public bool Jump
    {
        get { return Input.GetKey(KeyCode.Space); }
    }

    public bool MovingRight 
    {
        get { return Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0; }
    }

    public bool MovingLeft
    {
        get { return Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0; }
    }

    public bool Hit
    {
        get { return Input.GetKeyDown(KeyCode.F); }
    }
}
