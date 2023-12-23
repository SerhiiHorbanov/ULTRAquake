using HealthAndDamage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons.ProjectileBased.Projectiles
{
    public class Grenade : MonoBehaviour
    {
        [SerializeField] private float explosionRadius;
        [SerializeField] private float explosionPower;
        [SerializeField] private Projectile projectileComponent;

        private void Explode()
        {
            Collider[] affectedByExplosion = Physics.OverlapSphere(transform.position, explosionRadius);

            foreach (Collider collider in affectedByExplosion)
            {
                Rigidbody affectedRigidBody = collider.GetComponent<Rigidbody>();
                IDamageable damageable = collider.GetComponent<IDamageable>();

                Vector3 closestPoint = collider.ClosestPoint(transform.position);
                Vector3 affectedObjectRelativePosition = closestPoint - transform.position;

                if (affectedRigidBody != null)
                    AddExplosionForce(affectedRigidBody, affectedObjectRelativePosition);

                if (damageable != null)
                    ExplosionDamage(damageable, affectedObjectRelativePosition.magnitude);
            }
        }

        private void ExplosionDamage(IDamageable damageable, float distanceToObject)
        {
            Damage damageToApply = projectileComponent.damage / (distanceToObject + 1);

            damageable.ApplyDamage(damageToApply);
        }

        private void AddExplosionForce(Rigidbody rigidbody, Vector3 affectedObjectRelativePosition)
        {
            Vector3 direction = affectedObjectRelativePosition.normalized;

            float forceMagnitude = explosionPower / (affectedObjectRelativePosition.magnitude + 1);

            rigidbody.velocity += (direction * forceMagnitude);
        }

        private void OnDestroy()
        {
            Explode();
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject == projectileComponent.owner)
                return;

            if (collider.GetComponent<IDamageable>() != null)
                Destroy(gameObject);
        }
    }
}