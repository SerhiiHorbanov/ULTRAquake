using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HealthAndDamage
{
    public class DestroyableObject : MonoBehaviour, IDamageable
    {
        [SerializeField] private UnityEvent<Damage> OnDamage;

        [Tooltip("types of damage that can destroy that object. if empty, damage of any type will destroy the object")]
        [SerializeField] private List<DamageType> destroyingTypes = new List<DamageType>();

        public void ApplyDamage(Damage damage)
        {
            OnDamage.Invoke(damage);

            if (destroyingTypes == null)
            {
                Destroy(gameObject);
                return;
            }


            if (destroyingTypes.Contains(damage.type) || destroyingTypes.Count == 0)
                Destroy(gameObject);
        }
    }
}