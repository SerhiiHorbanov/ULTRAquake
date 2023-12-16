using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HealthAndDamage
{
    public class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] public float health;

        [Tooltip("actions that will be performed when player should die")]
        [SerializeField] private UnityEvent<Damage> OnDeath;

        [Tooltip("actions that will be performed when taking damage")]
        [SerializeField] private UnityEvent<Damage> OnDamage;

        [Tooltip("keys are the damage types, and values are the multipliers. when taking damage the damage will be multiplied by value with the key that matches with the damage type. if it doesn't match with any keys it won't be multiplied by anything")]
        [SerializeField] private Dictionary<DamageType, float> damageTypeMultipliers;

        public void ApplyDamage(Damage damage)
        {
            OnDamage.Invoke(damage);

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
    }
}