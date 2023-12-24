using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerDebugUI : MonoBehaviour
{
    public void Join()
        =>NetworkManager.Singleton.StartClient();
    public void Host()
        => NetworkManager.Singleton.StartHost();
    public void Server()
        => NetworkManager.Singleton.StartServer();
}
