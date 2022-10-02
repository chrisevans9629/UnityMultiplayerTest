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
    private EnemySpawner spawner;

    void Start()
    {
        hostBtn.onClick.AddListener(() =>
        {
            Debug.Log("host started");
            NetworkManager.Singleton.StartHost();
            spawner.StartSpawning();
        });

        clientBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
