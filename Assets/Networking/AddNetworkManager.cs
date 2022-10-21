using Unity.Netcode;
using UnityEngine;

public class AddNetworkManager : NetworkBehaviour
{
    [SerializeField]
    private NetworkManager NetworkManagerPrefab;
    void Start()
    {
        if (GameObject.FindObjectOfType<NetworkManager>() != null)
            return;
        var prefab = Instantiate(NetworkManagerPrefab);

        prefab.StartHost();
    }
}