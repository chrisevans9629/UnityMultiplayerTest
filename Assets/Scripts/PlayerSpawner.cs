using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerSpawner : NetworkBehaviour
{
    [SerializeField]
    private GameObject PlayerPrefab;

    public override void OnNetworkSpawn()
    {
        var player = Instantiate(PlayerPrefab);
        player.GetComponent<NetworkObject>().SpawnAsPlayerObject(OwnerClientId);
        base.OnNetworkSpawn();
    }
}
