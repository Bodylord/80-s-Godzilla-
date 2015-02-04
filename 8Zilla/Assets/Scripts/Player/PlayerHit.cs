using UnityEngine;
using System.Collections;

public class PlayerHit : MonoBehaviour
{
    private PlayerController playerController;

    private Animator animator;

    // Use this for initialization
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerController.Hit)
        {
            StartCoroutine(StartHit());
        }
    }

    private IEnumerator StartHit()
    {
        


        yield return null;
    }

}
