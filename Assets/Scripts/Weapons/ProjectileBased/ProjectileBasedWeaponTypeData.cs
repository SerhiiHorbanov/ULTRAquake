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
        public bool addOwnersVelocity;
        public Vector3 absoluteForceToAdd;
        public Vector3 forceToAdd;
    }
}