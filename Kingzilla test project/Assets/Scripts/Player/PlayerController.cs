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

    public bool TailHit
    {
        get { return Input.GetKeyDown(KeyCode.A); }
    }

    public bool Hit
    {
        get { return Input.GetKeyDown(KeyCode.S); }
    }

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }
}
