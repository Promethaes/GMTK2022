using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDoerContinuousTrigger : DamageDoer
{
    private void OnTriggerStay2D(Collider2D other)
    {
        DoDamage(other.gameObject);
    }
}
