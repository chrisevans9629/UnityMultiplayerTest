using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
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
    void Start()
    {
        hostBtn.onClick.AddListener(() =>
        {
            Debug.Log("host started");
            NetworkManager.Singleton.StartHost();

            var spawners = GameObject.FindObjectsOfType<EnemySpawner>();
            foreach (var spawner in spawners)
            {
                spawner.StartSpawning();
            }
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
