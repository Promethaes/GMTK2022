using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDoerDiscreteTrigger : DamageDoer
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        DoDamage(other.gameObject);
    }
}
