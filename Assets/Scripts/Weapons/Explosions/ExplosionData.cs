using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons.Explosions
{
    [CreateAssetMenu]
    public class ExplosionData : ScriptableObject
    {
        [SerializeField] float explosionRadius;
        [SerializeField] float explosionTime;
        [SerializeField] ExplosionRadiusDamageMultiplier[] explosionRadiusDamageMultipliers;

        public float ExplosionRadius => explosionRadius;
        public float ExplosionTime => explosionTime;
        public ExplosionRadiusDamageMultiplier[] ExplosionRadiusDamageMultipliers => explosionRadiusDamageMultipliers;
    }
}