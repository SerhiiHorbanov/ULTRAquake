using HealthAndDamage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEngine;

namespace Weapons.Explosions
{
    [Serializable]
    public struct ExplosionRadiusDamageMultiplier
    {
        public float radius;
        public float damageMultiplier;

        public ExplosionRadiusDamageMultiplier(float radius, float damageMultiplier)
        {
            this.radius = radius;
            this.damageMultiplier = damageMultiplier;
        }
    }
}