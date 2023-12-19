using HealthAndDamage;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [NonSerialized] public Vector3 eulerShootDirection;
    [NonSerialized] public GameObject owner;
    [NonSerialized] public Damage damage;
    public int timeBeforeDestroy;

    private void Awake()
    {
        Destroy(gameObject, timeBeforeDestroy);
    }
}
