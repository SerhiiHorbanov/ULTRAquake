using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

namespace Weapons.ProjectileBased
{
    [CreateAssetMenu()]
    public class ProjectileBasedWeaponTypeData : WeaponTypeData
    {
        public GameObject projectilePrefab;
    }
}