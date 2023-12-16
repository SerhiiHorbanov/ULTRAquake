using HealthAndDamage;
using System;
using UnityEngine;

namespace Weapons
{
    [Serializable]
    public class Weapon
    {
        [SerializeField] private WeaponTypeData typeData;
        [SerializeField] private GameObject owner;
        [SerializeField] private Vector3 offset;

        public WeaponTypeData TypeData
            => typeData;

        const float raycastMaxDistance = 100;

        public Weapon(WeaponTypeData weaponTypeData, GameObject owner)
        {
            this.typeData = weaponTypeData;
            this.owner = owner;
        }

        public bool TryAttack(Vector3 eulerAngle, AmmoManager ammoManager)
        {
            bool ableToAttack = ammoManager.GetAmmo(typeData.AmmoType) >= typeData.AmmoPerShot;
            ableToAttack |= typeData.IsAmmoInfinite;

            if (ableToAttack)
            {
                Attack(eulerAngle);

                if (!typeData.IsAmmoInfinite)
                    ammoManager.TryUseAmmo(typeData.AmmoType, typeData.AmmoPerShot);
            }

            return ableToAttack;
        }

        private void Attack(Vector3 eulerAngle)
        {
            for (int i = 0; i < typeData.ShotsPerAttack; i++)
            {
                float scatterX = UnityEngine.Random.Range(-typeData.Scatter, typeData.Scatter);
                float scatterY = UnityEngine.Random.Range(-typeData.Scatter, typeData.Scatter);

                Vector3 scatteredEulerAngle = eulerAngle + new Vector3(scatterX, scatterY, 0);
                
                foreach (Vector2 patternShot in typeData.Pattern)
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
                damageable.ApplyDamage(typeData.Damage);
        }
    }
}
