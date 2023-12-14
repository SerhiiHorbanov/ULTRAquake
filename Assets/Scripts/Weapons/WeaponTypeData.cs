using HealthAndDamage;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Weapons
{
    [CreateAssetMenu()]
    public class WeaponTypeData : ScriptableObject
    {
        [Tooltip("basically identificator for the weapon. if you pick up 2 weapons with the same name, the new one won't be added to your weapons but you will get the ammo")]
        [SerializeField] private string weaponName;

        [Header("Ammo")]
        [SerializeField] private bool isAmmoInfinite;
        [SerializeField] private int ammoPerShot;

        [Header("Shooting")]
        [SerializeField] private float scatter;//in degrees (Celsius)
        [SerializeField] private int shotsPerAttack;
        [SerializeField] private Vector2[] pattern;//in degrees (Celsius)
        [SerializeField] private Damage damage;

        [SerializeField] private GameObject weaponVisualsPrefab;

        public string WeaponName => weaponName;
        public bool IsAmmoInfinite => isAmmoInfinite;
        public int AmmoPerShot => ammoPerShot;
        public float Scatter => scatter;
        public int ShotsPerAttack => shotsPerAttack;
        public Vector2[] Pattern => pattern;
        public Damage Damage => damage;
        public GameObject WeaponVisualsPrefab => weaponVisualsPrefab;
    }
}