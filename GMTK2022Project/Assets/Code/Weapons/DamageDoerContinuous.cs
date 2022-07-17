using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDoerContinuous : DamageDoer
{
    private void OnCollsionStay2D(Collision2D other)
    {
        DoDamage(other.gameObject);
    }
}
