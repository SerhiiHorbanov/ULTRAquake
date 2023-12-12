using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthAndDamage
{
    public abstract class Health : MonoBehaviour, IDamageable
    {
        public float health { get; set; }

        Action<Damage> OnDamage { get; set; }

        Dictionary<DamageType, float> damageTypeMultipliers { get; set; }

        public void ApplyDamage(Damage damage)
        {
            OnDamage(damage);

            float damageToDeal = damage.damageValue;

            if (damageTypeMultipliers != null)
                if (damageTypeMultipliers.ContainsKey(damage.type))
                    damageToDeal *= damageTypeMultipliers[damage.type];

            health -= damageToDeal;
        }

        public void Heal(float healValue)
        {
            health += healValue;
        }

        public abstract void Death();
    }
}