using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class DamageDoer : MonoBehaviour
{
    public float damage = 1.0f;
    public UnityEvent OnDidDamage;
    public UnityEvent OnFailedDidDamage;
    public bool canDoDamage = true;
    public LayerMask collisionlayer;
    //would be nice if i could have an enum that i add to at runtime
    [SerializeField] protected string typeToLookFor = "Health";

    public virtual void DoDamage(GameObject other)
    {
        var l = 1 << collisionlayer.value;
        var otherL = other.layer;
        var onGoodLayer = (1 << other.layer & collisionlayer) > 0;
        if (!canDoDamage || !onGoodLayer)
        {
            OnFailedDidDamage.Invoke();
            return;
        }
        var resourcePool = other.GetComponent<ResourcePool>();
        if (!resourcePool)
        {
            OnFailedDidDamage.Invoke();
            return;
        }

        var hp = resourcePool.GetResource(System.Type.GetType(typeToLookFor));
        if (!hp)
        {
            OnFailedDidDamage.Invoke();
            return;
        }

        if (hp.TakeDamage(damage))
            OnDidDamage.Invoke();
    }
}