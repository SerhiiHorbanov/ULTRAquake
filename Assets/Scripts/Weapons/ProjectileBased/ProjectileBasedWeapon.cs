using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

namespace Weapons.ProjectileBased
{
    public class ProjectileBasedWeapon : Weapon
    {
        private ProjectileBasedWeaponTypeData projectileBasedTypeData;
        public ProjectileBasedWeapon(ProjectileBasedWeaponTypeData weaponTypeData, GameObject owner, Transform shootFrom) : base(weaponTypeData, owner, shootFrom)
        {
            projectileBasedTypeData = (ProjectileBasedWeaponTypeData)TypeData;
        }

        public override void Shoot(Vector3 eulerAngle)
        {
            GameObject prefab = projectileBasedTypeData.projectilePrefab;
            Vector3 position = ShootFrom.position;
            Quaternion rotation = ShootFrom.transform.rotation;

            GameObject projectileObject = GameObject.Instantiate(prefab, position, rotation);

            Rigidbody rigidBody = projectileObject.GetComponent<Rigidbody>();
            Projectile projectile = projectileObject.GetComponent<Projectile>();

            if (projectile != null)
            {
                projectile.eulerShootDirection = eulerAngle;
                projectile.owner = Owner;
                projectile.damage = projectileBasedTypeData.Damage;
            }

            if (rigidBody == null)
                return;

            if (projectileBasedTypeData.addOwnersVelocity)
            {
                Rigidbody ownerRigidBody = Owner.GetComponent<Rigidbody>();

                if (ownerRigidBody != null)
                    rigidBody.velocity = ownerRigidBody.velocity;
            }

            rigidBody.velocity += projectileBasedTypeData.absoluteForceToAdd;
            rigidBody.velocity += rotation * projectileBasedTypeData.forceToAdd;
        }
    }
}