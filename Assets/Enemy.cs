using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;

public class Enemy : NetworkBehaviour
{
    [SerializeField]
    private float Speed = 2;

    private PlayerController Player;

    public override void OnNetworkSpawn()
    {
        StartCoroutine(FindTarget());
        base.OnNetworkSpawn();
    }

    IEnumerator FindTarget()
    {
        Player = GameObject.FindGameObjectsWithTag("Player")
            .OrderBy(p => Vector3.Distance(p.transform.position, transform.position))
            .First()
            .GetComponent<PlayerController>();

        yield return new WaitForSeconds(4);
        StartCoroutine(FindTarget());
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsServer)
            return;

        var direction = Player.transform.position - transform.position;

        transform.position += direction.normalized * Speed * Time.deltaTime;

    }
}
