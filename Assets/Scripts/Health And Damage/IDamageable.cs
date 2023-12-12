using System;
using System.Collections.Generic;
using UnityEngine;

namespace HealthAndDamage
{
    public interface IDamageable
    {
        abstract void ApplyDamage(Damage damage);
    }
}