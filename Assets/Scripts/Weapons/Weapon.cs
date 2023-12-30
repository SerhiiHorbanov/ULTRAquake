using HealthAndDamage;
using System;
using UnityEngine;
using UnityEngine.Events;
using Weapons.Ammo;

namespace Weapons
{
    [Serializable]
    public class Weapon
    {
        [SerializeField] private WeaponTypeData typeData;
        [SerializeField] private GameObject owner;
        [SerializeField] private Transform shootFrom;

        public UnityEvent AltAttack;
        
        public WeaponTypeData TypeData
            => typeData;
        public GameObject Owner
            => owner;
        public Transform ShootFrom
            => shootFrom;


        const float raycastMaxDistance = 100;

        public Weapon(WeaponTypeData weaponTypeData, GameObject owner, Transform shootFrom)
        {
            this.typeData = weaponTypeData;
            this.owner = owner;
            this.shootFrom = shootFrom;
        }

        public bool TryAttack(AmmoManager ammoManager)
        {
            bool ableToAttack = ammoManager.GetAmmo(typeData.AmmoType) >= typeData.AmmoPerShot;
            ableToAttack |= typeData.IsAmmoInfinite;


            if (ableToAttack)
            {
                Vector3 eulerAngle = shootFrom.eulerAngles;

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
            Vector3 raycastOrigin = shootFrom.position;

            RaycastHit hit;

            if (!Physics.Raycast(raycastOrigin, raycastDirection, out hit, raycastMaxDistance))
                return;

            IDamageable damageable = hit.collider.GetComponent<IDamageable>();
            if (damageable != null)
                damageable.ApplyDamage(typeData.Damage);
        }
    }
}
