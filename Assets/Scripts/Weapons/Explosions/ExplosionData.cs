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
        [SerializeField] float explosionForce;
        [SerializeField] float explosionStartingOpacity;
        [SerializeField] float explosionEndingOpacity;
        [SerializeField] ExplosionRadiusDamageMultiplier[] explosionRadiusDamageMultipliers;

        public float ExplosionRadius => explosionRadius;
        public float ExplosionTime => explosionTime;
        public float ExplosionForce => explosionForce;
        public float ExplosionStartingOpacity => explosionStartingOpacity;
        public float ExplosionEndingOpacity => explosionEndingOpacity;
        public ExplosionRadiusDamageMultiplier[] ExplosionRadiusDamageMultipliers => explosionRadiusDamageMultipliers;
    }
}