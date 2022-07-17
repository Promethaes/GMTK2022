using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDoerDiscrete : DamageDoer
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        DoDamage(other.gameObject);
    }
}
