using HealthAndDamage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons.Explosions;

namespace Weapons.ProjectileBased.Projectiles
{
    public class Grenade : MonoBehaviour
    {
        [SerializeField] private Projectile projectileComponent;
        [SerializeField] private ExplosionData explosionData;

        private void Explode()
        {
            ExplosionManager.Instance.CreateExplosion(transform.position, projectileComponent.damage, explosionData);
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