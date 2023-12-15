using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class AmmoManager : MonoBehaviour
{
    [SerializeField] SerializableDictionary<AmmoTypes, int> ammo;
    [SerializeField] SerializableDictionary<AmmoTypes, int> maxAmmo;

    public void AddAmmo(AmmoTypes type, int amount)
    {
        int clampedAmmoAmount = Mathf.Clamp(amount, 0, GetMaxAmmo(type));

        if (ammo == null)
            ammo = new SerializableDictionary<AmmoTypes, int>() { { type, clampedAmmoAmount } };

        else if (ammo.ContainsKey(type))
        {
            ammo[type] += amount;
            ammo[type] = Mathf.Clamp(ammo[type], 0, GetMaxAmmo(type));
        }

        else
            ammo.Add(type, clampedAmmoAmount);
    }

    public bool UseAmmo(AmmoTypes type, int amount)
    {
        int maxAmmo = GetMaxAmmo(type);
        if (maxAmmo < amount)
            return false;

        int clampedAmmoAmount = Mathf.Clamp(amount, 0, maxAmmo);

        if (ammo == null)
            ammo = new SerializableDictionary<AmmoTypes, int>() { { type, clampedAmmoAmount } };

        if (!ammo.ContainsKey(type))
            ammo.Add(type, clampedAmmoAmount);
        else
            ammo[type] = Mathf.Clamp(ammo[type] + amount, 0, maxAmmo);

        return true;
    }

    public int GetAmmo(AmmoTypes type)
    {
        if (ammo == null)
            ammo = new SerializableDictionary<AmmoTypes, int>() { { type, 0 } };

        else if (ammo.ContainsKey(type))
            return ammo[type];

        else
            ammo = new SerializableDictionary<AmmoTypes, int>() { { type, 0 } };

        return 0;
    }

    public int GetMaxAmmo(AmmoTypes type)
    {
        if (maxAmmo == null)
            return 0;

        if (maxAmmo.ContainsKey(type))
            return maxAmmo[type];

        return 0;
    }
}
