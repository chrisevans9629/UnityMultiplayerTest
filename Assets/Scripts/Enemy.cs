using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;

public class Enemy : NetworkBehaviour
{
    [SerializeField]
    private GameObject ItemDropPrefab;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!IsServer)
            return;
        if (collision.transform.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            var item = Instantiate(ItemDropPrefab);
            item.transform.position = transform.position;
            item.GetComponent<NetworkObject>().Spawn(true);
        }
    }
}
