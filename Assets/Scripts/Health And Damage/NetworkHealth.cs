using HealthAndDamage;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class NetworkHealth : NetworkBehaviour
{
    private Health health;
    private NetworkVariable<float> syncHealth = new NetworkVariable<float>(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

    public override void OnNetworkSpawn()
    {
        health = GetComponent<Health>();

        health.OnAfterApplyingDamage.AddListener(SetSyncHealth);
        syncHealth.OnValueChanged += SetHealth;
    }

    void SetSyncHealth(Damage damage)
    {
        if (IsServer) 
            syncHealth.Value = health.health;
    }
    void SetHealth(float prevHealth, float newHealth)
    {
        //health.health = prevHealth;
        //health.ApplyDamage(new Damage(newHealth - prevHealth, DamageType.none));
    }
}
