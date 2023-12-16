using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField] private List<Weapon> weapons;
        [SerializeField] private AmmoManager ammo;
        private Weapon currentWeapon;
        private int currentWeaponIndex;

        public void ChooseWeapon(string name)
            => ChooseWeapon(IndexOfWeaponWithName(name));

        public void ChooseWeapon(int index)
        {
            if (index < 0)
                index = weapons.Count - index;

            currentWeaponIndex = weapons.Count % index;
            currentWeapon = weapons[currentWeaponIndex];
        }

        public void Attack()
            => currentWeapon.TryAttack(transform.rotation.eulerAngles, ammo);

        public int IndexOfWeaponWithName(string name)
        {
            for (int i = 0; i < weapons.Count; i++)
                if (weapons[i].TypeData.WeaponName == name)
                    return i;
            return 0;
        }

        public bool ContainsWeaponWithName(string name)
        {
            for (int i = 0; i < weapons.Count; i++)
                if (weapons[i].TypeData.WeaponName == name)
                    return true;
            return false;
        }

        public void AddWeapon(WeaponTypeData typeData, Vector3 offset)
        {
            string name = typeData.name;

            for (int i = 0; i < weapons.Count; i++)
            {
                Weapon weapon = weapons[i];
                if (weapon.TypeData.WeaponName == name)
                {
                    ammo.AddAmmo(weapon.TypeData.AmmoType, weapon.TypeData.StartingAmmo);
                    return;
                }
            }

            weapons.Add(new Weapon(typeData, gameObject));
        }

        public void AddWeapon(WeaponTypeData typeData)
            => AddWeapon(typeData, Vector3.zero);
    }
}