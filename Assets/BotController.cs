using System.Collections;
using Unity.Netcode;
using UnityEngine;

public class BotController : NetworkBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;

    [SerializeField]
    private float thinkSpeed = 1;
    private GameObject ClosestEnemy;
    private GameObject ClosestPlayer;

    public override void OnNetworkSpawn()
    {
        if (!IsServer)
            return;
        StartCoroutine(GetPlayerAndEnemy());
        base.OnNetworkSpawn();
    }

    IEnumerator GetPlayerAndEnemy()
    {
        yield return new WaitForSeconds(thinkSpeed);
        ClosestEnemy = CommonLogic.FindClosestObject("Enemy", transform.position);
        ClosestPlayer = null;
        yield return new WaitForSeconds(thinkSpeed);
        ClosestPlayer = CommonLogic.FindClosestObject("Player", transform.position);
        ClosestEnemy = null;
        StartCoroutine(GetPlayerAndEnemy());
    }

    private void Update()
    {
        if (!IsServer)
            return;
        if (ClosestEnemy != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, ClosestEnemy.transform.position, -moveSpeed * Time.deltaTime);
        }
        else if (ClosestPlayer != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, ClosestPlayer.transform.position, moveSpeed * Time.deltaTime);
        }
    }
}
