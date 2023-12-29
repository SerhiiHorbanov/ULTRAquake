using HealthAndDamage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Weapons.Explosions
{
    public class Explosion : MonoBehaviour
    {
        private ExplosionData explosionData;
        private Damage damage;

        private int framesPassed = 0;

        List<Collider> blownColliders = new List<Collider>();

        private void FixedUpdate()
        {
            if (explosionData == null)
                return;

            float valueOnCurve = EaseOutExpo((float)framesPassed / explosionData.ExplosionTime);
            float scale = valueOnCurve * explosionData.ExplosionRadius;
            transform.localScale = Vector3.one * scale;

            framesPassed++;

            if (framesPassed >= explosionData.ExplosionTime)
                Destroy(gameObject);
        }

        private float EaseOutExpo(float value)
            => (value == 1) ? 1 : 1 - Mathf.Pow(2, -10 * value);

        public void SetData(ExplosionData explosionData, Damage damage)
        {
            this.explosionData = explosionData;
            this.damage = damage;
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (blownColliders.Contains(collider))
                return;

            blownColliders.Add(collider);

            IDamageable damageable = collider.GetComponent<IDamageable>();
            Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

            if (damageable != null)
                TryApplyDamage(collider, damageable);

            if (rigidbody != null)
                TryApplyForce(collider, rigidbody);
        }

        private void TryApplyDamage(Collider collider, IDamageable damageable)
        {
            Vector3 affectedObjectRelativePosition = collider.ClosestPoint(transform.position) - transform.position;
            float distance = affectedObjectRelativePosition.magnitude;

            Damage damageToDeal = damage;

            if (explosionData.ExplosionRadiusDamageMultipliers.Length != 0)
            {
                ExplosionRadiusDamageMultiplier currentMultiplier = new ExplosionRadiusDamageMultiplier(int.MaxValue, 1);

                for (int i = 0; i < explosionData.ExplosionRadiusDamageMultipliers.Length; i++)
                {
                    ExplosionRadiusDamageMultiplier multiplierToCheck = explosionData.ExplosionRadiusDamageMultipliers[i];

                    bool isRadiusSmaller = multiplierToCheck.radius < currentMultiplier.radius;
                    bool isRadiusBiggerThanDistance = multiplierToCheck.radius > distance;

                    if (isRadiusSmaller && isRadiusBiggerThanDistance)
                        currentMultiplier = multiplierToCheck;
                }

                damageToDeal *= currentMultiplier.damageMultiplier;
            }

            Debug.Log(distance);
            Debug.Log(damageToDeal);

            damageable.ApplyDamage(damageToDeal);
        }

        private void TryApplyForce(Collider collider, Rigidbody rigidbody)
        {
            Vector3 affectedObjectRelativePosition = collider.ClosestPoint(transform.position) - transform.position;//ik this line repeats

            float forceMagnitude = explosionData.ExplosionForce / (affectedObjectRelativePosition.magnitude + 1);
            Vector3 forceDirection = affectedObjectRelativePosition.normalized;

            if (forceDirection.sqrMagnitude < 0.01f)
                forceDirection = collider.transform.position - transform.position;

            rigidbody.velocity += forceDirection * forceMagnitude;
        }
    }
}