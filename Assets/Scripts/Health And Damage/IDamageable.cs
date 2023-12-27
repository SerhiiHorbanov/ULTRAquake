using System;
using System.Collections.Generic;
using UnityEngine;

namespace HealthAndDamage
{
    public interface IDamageable
    {
        public abstract void ApplyDamage(Damage damage);
    }
}