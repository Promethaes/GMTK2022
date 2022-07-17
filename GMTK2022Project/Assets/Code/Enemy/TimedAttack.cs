using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimedAttack : MonoBehaviour
{
    [SerializeField] UnityEvent attackEvent;
    [SerializeField] Weapon weapon;
    [SerializeField] Transform weaponHitbox;

    [SerializeField] float attackDistance = 5.0f;

    static Transform _playerTransform = null;

    float _attackTime = 0.0f;
    private void Awake()
    {
        if (!_playerTransform)
            _playerTransform = FindObjectOfType<PlayerMovement>().transform;
        _attackTime = weapon.GetComponent<Weapon>().GetFinishedAttackCooldown() * 2.0f;
    }

    void Start()
    {
        IEnumerator Timer()
        {
            while (true)
            {
                if (!WithinRange())
                {
                    yield return null;
                    continue;
                }
                yield return new WaitForSeconds(_attackTime);
                var direction = (_playerTransform.position - transform.position).normalized;
                weaponHitbox.transform.localPosition = new Vector3(0.0f,0.0f,0.0f) + direction*1.3f;
                attackEvent.Invoke();
            }
        }
        StartCoroutine(Timer());
    }

    bool WithinRange()
    {
        var dir = (_playerTransform.position - transform.position);
        var dist = dir.magnitude;
        dir = dir.normalized;
        //replace true with raycast
        
        return dist <= attackDistance;
    }
}
