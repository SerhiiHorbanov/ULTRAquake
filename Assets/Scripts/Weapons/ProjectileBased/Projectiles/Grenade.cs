using HealthAndDamage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons.ProjectileBased.Projectiles
{
    public class Grenade : MonoBehaviour
    {
        [SerializeField] private int explosionRadius;
        [SerializeField] private int explosionPower;
        [SerializeField] private Projectile projectileComponent;

        private void Awake()
        {
            
        }

        private void Explode()
        {
            Collider[] affectedByExplosion = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider collider in affectedByExplosion)
            {
                Rigidbody affectedRigidBody = collider.GetComponent<Rigidbody>();
                IDamageable iDamageable = collider.GetComponent<IDamageable>();

                if (affectedRigidBody != null)
                    AddExplosionForce(affectedRigidBody, collider);

                if (iDamageable != null)
                    iDamageable.ApplyDamage(projectileComponent.damage);
            }
        }

        private void AddExplosionForce(Rigidbody rigidbody, Collider collider)
        {
            Vector3 affectedObjectRelativePosition = collider.ClosestPoint(transform.position) - transform.position;
            Vector3 direction = affectedObjectRelativePosition.normalized;

            float forceMagnitude = 1f / (affectedObjectRelativePosition.magnitude + 1);

            rigidbody.AddForce(direction * forceMagnitude);
        }

        private void OnDestroy()
        {
            Explode();
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.GetComponent<Health>() != null)
                Destroy(gameObject);
        }
    }
}