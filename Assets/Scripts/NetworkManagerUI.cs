using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField]
    private Button hostBtn;
    [SerializeField]
    private Button clientBtn;
    [SerializeField]
    private Button botBtn;

    [SerializeField]
    private GameObject BotPrefab;

    [SerializeField]
    private UnityEngine.UI.InputField IpAddress;

    void Start()
    {
        var trans = NetworkManager.Singleton.transform.GetComponent<UnityTransport>();
        IpAddress.text = trans.ConnectionData.Address;
        botBtn.enabled = false;
        hostBtn.onClick.AddListener(() =>
        {
            Debug.Log("host started");
            trans.ConnectionData.Address = IpAddress.text;
            NetworkManager.Singleton.StartHost();

            var spawners = GameObject.FindObjectsOfType<EnemySpawner>();
            foreach (var spawner in spawners)
            {
                spawner.StartSpawning();
            }
            botBtn.enabled = true;
        });

        clientBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });

        botBtn.onClick.AddListener(() =>
        {
            var bot = Instantiate(BotPrefab);
            bot.GetComponent<NetworkObject>().Spawn(true);
        });
    }
}
