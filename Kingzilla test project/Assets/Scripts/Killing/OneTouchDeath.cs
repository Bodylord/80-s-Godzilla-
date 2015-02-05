using System;
using UnityEngine;
using System.Collections;

public class OneTouchDeath : MonoBehaviour, IDamagable
{
    public int numberOfPunchToDie = 1;
    private int currentPunchCount = 0;

    public float invencibilityTimeAfterHit = 2f;

    public GameObject DeathBlood;
    public event EventHandler OnDeathStart;

    private SpawnMarker deathParticleSpawnMarker;

    // Use this for initialization
    private void Start()
    {
        deathParticleSpawnMarker = GetComponentInChildren<SpawnMarker>();
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
        if (!_AmIInvencible)
        {
            var killer = other.GetComponent<PlayerController>();
            if (killer != null)
            {
                _AmIInvencible = true;
                DoActualDamage();
            }
        }
    }

    private void DoActualDamage()
    {
        currentPunchCount += 1;
        Debug.Log("Just gotten hit " + currentPunchCount);
        if (currentPunchCount >= numberOfPunchToDie)
        {
            if (OnDeathStart != null) OnDeathStart(gameObject, EventArgs.Empty);
            collider2D.enabled = false;
            Destroy(rigidbody2D);
            StartCoroutine(BlowUpAndDie());
        }
        else
        {
            StartCoroutine(AftershockInvulnerability());
        }
    }

    private bool _AmIInvencible = false;
    private IEnumerator AftershockInvulnerability()
    {
        _AmIInvencible = true;
        float currentTime = 0f;
        while (currentTime < invencibilityTimeAfterHit)
        {
            currentTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        _AmIInvencible = false;
    }

    private IEnumerator BlowUpAndDie()
    {
        if (DeathBlood != null)
        {
            var bloodPosition = deathParticleSpawnMarker == null
                ? transform
                : deathParticleSpawnMarker.MarkedTransform;
            var blood = (GameObject) Instantiate(DeathBlood, bloodPosition.position, bloodPosition.rotation);
            
            while (blood != null)
            {
                yield return new WaitForEndOfFrame();
            }
        }
        Destroy(gameObject);
    }

    public void DoDamage(int damage)
    {
        if (!_AmIInvencible)
        {
            DoActualDamage();
        }
    }

    public event EventHandler BeforeDying
    {
        add { OnDeathStart += value; }
        remove { OnDeathStart -= value; }
    }

    public GameObject gameObject { get { return base.gameObject; } }
}
