using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerPunch : MonoBehaviour
{
    public GameObject boxcolliderToControl;
    private PlayerController playerController;
    private DumbCollider dumbColliderToControl;
    private Animator animator;
    
    public float step1DelayToEnableCollider = 1f;
    public float step2timeToEnableCollider = 5f;
    public float step3DelayToFinishPunching = 1f;
    public int damagePerHit = 5;

   
    


    private bool _isPunching = false;
    // Use this for initialization
    private void Start()
    {
        if (boxcolliderToControl == null) Debug.LogError("Boxcollider is null, cannot punch");
        playerController = GetComponent<PlayerController>();
        dumbColliderToControl = boxcolliderToControl.GetComponent<DumbCollider>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerController.Hit && !_isPunching)
        {
            _isPunching = true;
            punchingCoroutine = StartPunching();
            StartCoroutine(punchingCoroutine);
        }
    }

    private IEnumerator StartPunching()
    {
        var currentTime = 0f;
        Debug.Log("StartAnimation");
        while (currentTime < step1DelayToEnableCollider)
        {
            currentTime += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        currentTime = 0f;
        Debug.Log("PunchActive");
        dumbColliderToControl.TriggerEnter += dumbColliderToControl_TriggerEnter;
        while (currentTime < step2timeToEnableCollider)
        {
            currentTime += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        dumbColliderToControl.TriggerEnter -= dumbColliderToControl_TriggerEnter;
        Debug.Log("LayingDown");
        currentTime = 0f;
        while (currentTime < step3DelayToFinishPunching)
        {
            currentTime += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        _isPunching = false;
        Debug.Log("PunchEnded");
    }


    private List<string> objectsCollided = new List<string>();
    void dumbColliderToControl_TriggerEnter(object sender, System.EventArgs e)
    {
        var damagable = dumbColliderToControl.collidingWith.GetComponent(typeof(IDamagable)) as IDamagable;
        if (damagable != null)
        {
            damagable.DoDamage(damagePerHit);
        }
    }

    private IEnumerator punchingCoroutine;
}
