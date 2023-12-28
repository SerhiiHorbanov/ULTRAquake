using Unity.Netcode;

public class DestroyIfNotOwner : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
            Destroy(gameObject);
    }
}
