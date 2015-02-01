using System;
using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class OneTouchDeath : MonoBehaviour
{

    public GameObject DeathBlood;
    public event EventHandler OnDeathStart;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private bool _protectionWhenActivated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_protectionWhenActivated)
        {
            _protectionWhenActivated = true;
            CheckDeath(other.gameObject);
            _protectionWhenActivated = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (!_protectionWhenActivated)
        {
            _protectionWhenActivated = true;
            CheckDeath(coll.gameObject);
            _protectionWhenActivated = false;
        }
    }

    private void CheckDeath(GameObject other)
    {
        var killer = other.GetComponent<OneTouchKiller>();
        if (killer != null)
        {
            if (OnDeathStart != null) OnDeathStart(gameObject, EventArgs.Empty);
            collider2D.enabled = false;
            Destroy(rigidbody2D);
            StartCoroutine(BlowUpAndDie());
        }
    }

    private IEnumerator BlowUpAndDie()
    {
        if (DeathBlood != null)
        {
            var blood = (GameObject) Instantiate(DeathBlood, transform.position, Quaternion.identity);
            while (blood != null)
            {
                yield return new WaitForEndOfFrame();
            }
        }
        Destroy(gameObject);
    }
}
