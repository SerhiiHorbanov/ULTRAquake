using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Weapons;

public class AmmoManager : MonoBehaviour
{
    [SerializeField] AmmoTypes[] ammoKeysArray;
    [SerializeField] int[] ammoValuesArray;

    [SerializeField] AmmoTypes[] maxAmmoKeysArray;
    [SerializeField] int[] maxAmmoValuesArray;

    public Dictionary<AmmoTypes, int> ammo;
    public Dictionary<AmmoTypes, int> maxAmmo;

    private void Awake()
    {
        for (int i = 0; i < ammoKeysArray.Length; i++)
            ammo.Add(ammoKeysArray[i], ammoValuesArray[i]);

        for (int i = 0; i < maxAmmoKeysArray.Length; i++)
            maxAmmo.Add(maxAmmoKeysArray[i], maxAmmoValuesArray[i]);
    }

    public void AddAmmo(AmmoTypes type, int amount)
    {
        int clampedAmmoAmount = Mathf.Clamp(amount, 0, GetMaxAmmo(type));

        if (ammo == null)
        {
            ammo = new SerializableDictionary<AmmoTypes, int>() { { type, clampedAmmoAmount } };
            return;
        }

        else if (ammo.ContainsKey(type))
        {
            ammo[type] += amount;
            ammo[type] = Mathf.Clamp(ammo[type], 0, GetMaxAmmo(type));
        }

        else
            ammo.Add(type, clampedAmmoAmount);
    }

    public bool TryUseAmmo(AmmoTypes type, int amount)
    {
        bool isEnoughAmmo = GetAmmo(type) >= amount;

        if (isEnoughAmmo)
            ammo[type] -= amount;

        return isEnoughAmmo;
    }

    public int GetAmmo(AmmoTypes type)
    {
        if (ammo == null)
            ammo = new SerializableDictionary<AmmoTypes, int>() { { type, 0 } };

        else if (ammo.ContainsKey(type))
            return ammo[type];

        else
            ammo.Add(type, 0);

        return 0;
    }

    public int GetMaxAmmo(AmmoTypes type)
    {
        if (maxAmmo == null)
            maxAmmo = new SerializableDictionary<AmmoTypes, int>() { { type, 0 } };

        else if (maxAmmo.ContainsKey(type))
            return maxAmmo[type];

        else
            maxAmmo.Add(type, 0);

        return 0;
    }

    public void SetMaxAmmo(AmmoTypes type, int amount)
    {
        if (maxAmmo == null)
            maxAmmo = new SerializableDictionary<AmmoTypes, int>() { { type, amount } };

        else if (maxAmmo.ContainsKey(type))
            maxAmmo[type] = amount;

        else
            maxAmmo.Add(type, amount);
    }
}
