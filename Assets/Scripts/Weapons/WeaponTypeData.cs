using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Weapons
{
    [CreateAssetMenu()]
    public class WeaponTypeData : ScriptableObject
    {
        public string type;

        public int maxAmmo;

        public bool isAmmoInfinite;

        public GameObject weaponVisualsPrefab;
    }
}