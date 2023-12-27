using System.Collections;
using System.Collections.Generic;
using Unity.Multiplayer.Samples.Utilities.ClientAuthority;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;
using UnityEngine.Networking;

public class AddNetworkComponentsIfMultiplayer : MonoBehaviour
{
    [Header("sync position")]
    [SerializeField] bool syncPosX;
    [SerializeField] bool syncPosY;
    [SerializeField] bool syncPosZ;
    [Header("sync rotation")]
    [SerializeField] bool syncRotX;
    [SerializeField] bool syncRotY;
    [SerializeField] bool syncRotZ;
    [Header("sync scale")]
    [SerializeField] bool syncScaleX;
    [SerializeField] bool syncScaleY;
    [SerializeField] bool syncScaleZ;

    private void Start()
    {
        if (NetworkManager.Singleton == null)
        {
            NetworkObject existingNetworkObject = GetComponent<NetworkObject>();
            if (existingNetworkObject != null)
                Destroy(existingNetworkObject);
        }

        gameObject.AddComponent<NetworkObject>();
        gameObject.AddComponent<ClientNetworkTransform>();
        NetworkObject networkObject = GetComponent<NetworkObject>();
        ClientNetworkTransform networkTransform = GetComponent<ClientNetworkTransform>();

        networkObject.Spawn();
        SetSyncing(networkTransform);

        if (GetComponent<Rigidbody>() != null)
            gameObject.AddComponent<NetworkRigidbody>();

        Destroy(this);
    }

    private void SetSyncing(ClientNetworkTransform netTransforn)
    {
        netTransforn.SyncPositionX = syncPosX;
        netTransforn.SyncPositionY = syncPosY;
        netTransforn.SyncPositionZ = syncPosZ;
        netTransforn.SyncRotAngleX = syncRotX;
        netTransforn.SyncRotAngleY = syncRotY;
        netTransforn.SyncRotAngleZ = syncRotZ;
        netTransforn.SyncScaleX = syncScaleX;
        netTransforn.SyncScaleY = syncScaleY;
        netTransforn.SyncScaleZ = syncScaleZ;
    }
}
