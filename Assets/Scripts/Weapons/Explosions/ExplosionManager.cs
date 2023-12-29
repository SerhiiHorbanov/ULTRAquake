using HealthAndDamage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons.Explosions;

public class ExplosionManager : MonoBehaviour
{
    public static ExplosionManager Instance;
    
    public GameObject explosionPrefab;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void CreateExplosion(Vector3 position, Damage damage, ExplosionData explosionData)
    {
        GameObject explosionObject = Instantiate(explosionPrefab, position, new Quaternion());
        Explosion explosionComponent = explosionObject.GetComponent<Explosion>();

        explosionComponent.SetData(explosionData, damage);
    }
}
