using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons.Ammo;

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
                index = weapons.Count + index;

            currentWeaponIndex = index % weapons.Count;
            currentWeapon = weapons[currentWeaponIndex];
        }

        public void Attack()
        {
            if (currentWeapon != null)
                currentWeapon.TryAttack(transform.rotation.eulerAngles, ammo);
        }

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

            Weapon weaponToAdd;

                weaponToAdd = new Weapon(typeData, gameObject, offset);

            weapons.Add(weaponToAdd);
        }

        public void AddWeapon(WeaponTypeData typeData)
            => AddWeapon(typeData, Vector3.zero);

        public void NextWeapon(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started)
                return;

            ChooseWeapon(currentWeaponIndex + 1);
        }

        public void PrevWeapon(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started)
                return;
            ChooseWeapon(currentWeaponIndex - 1);
        }
    }
}