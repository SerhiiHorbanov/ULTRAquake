using HealthAndDamage;
using System;
using UnityEngine;

namespace Weapons
{
    [Serializable]
    public class Weapon
    {
        [SerializeField] private WeaponTypeData weaponTypeData;
        [SerializeField] private GameObject owner;
        [SerializeField] private Vector3 offset;

        const float raycastMaxDistance = 100;

        public Weapon(WeaponTypeData weaponTypeData, GameObject owner)
        {
            this.weaponTypeData = weaponTypeData;
            this.owner = owner;
        }

        public bool TryAttack(Vector3 eulerAngle, AmmoManager ammoManager)
        {
            bool ableToAttack = ammoManager.GetAmmo(weaponTypeData.AmmoType) >= weaponTypeData.AmmoPerShot;
            ableToAttack |= weaponTypeData.IsAmmoInfinite;

            if (ableToAttack)
            {
                Attack(eulerAngle);

                if (!weaponTypeData.IsAmmoInfinite)
                    ammoManager.TryUseAmmo(weaponTypeData.AmmoType, weaponTypeData.AmmoPerShot);
            }

            return ableToAttack;
        }

        private void Attack(Vector3 eulerAngle)
        {
            for (int i = 0; i < weaponTypeData.ShotsPerAttack; i++)
            {
                float scatterX = UnityEngine.Random.Range(-weaponTypeData.Scatter, weaponTypeData.Scatter);
                float scatterY = UnityEngine.Random.Range(-weaponTypeData.Scatter, weaponTypeData.Scatter);

                Vector3 scatteredEulerAngle = eulerAngle + new Vector3(scatterX, scatterY, 0);
                
                foreach (Vector2 patternShot in weaponTypeData.Pattern)
                {
                    Vector3 shootEulerAngle = scatteredEulerAngle + (Vector3)patternShot;
                    Shoot(shootEulerAngle);
                }
            }
        }

        public virtual void Shoot(Vector3 eulerAngle)
        {
            Vector3 raycastDirection = Quaternion.Euler(eulerAngle) * Vector3.forward;
            Vector3 raycastOrigin = owner.transform.position + offset;

            RaycastHit hit;

            if (!Physics.Raycast(raycastOrigin, raycastDirection, out hit, raycastMaxDistance))
                return;

            IDamageable damageable = hit.collider.GetComponent<IDamageable>();
            if (damageable != null)
                damageable.ApplyDamage(weaponTypeData.Damage);
        }
    }
}
