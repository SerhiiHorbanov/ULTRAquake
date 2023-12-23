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
        public ProjectileBasedWeapon(ProjectileBasedWeaponTypeData weaponTypeData, GameObject owner, Vector3 offset) : base(weaponTypeData, owner, offset)
        {
            projectileBasedTypeData = (ProjectileBasedWeaponTypeData)TypeData;
            //base(weaponTypeData, owner);
        }

        public override void Shoot(Vector3 eulerAngle)
        {
            Debug.Log("projectile shooting");
            Debug.Log(Offset);

            GameObject prefab = projectileBasedTypeData.projectilePrefab;
            Vector3 position = Owner.transform.position + Offset;
            Quaternion rotation = Owner.transform.rotation;

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