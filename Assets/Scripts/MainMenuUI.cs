using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_InputField IpAddress;

    [SerializeField]
    private string NextLevel;
    UnityTransport transport;

    public void Start()
    {
        transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
        IpAddress.text = transport.ConnectionData.Address;
    }

    public void Host()
    {
        NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.SceneManager.LoadScene(NextLevel, LoadSceneMode.Single);
    }

    public void Client()
    {
        var ip = IpAddress.text;
        transport.ConnectionData.Address = ip;
        NetworkManager.Singleton.StartClient();
    }
}
