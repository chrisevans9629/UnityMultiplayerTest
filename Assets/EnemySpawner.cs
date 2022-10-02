using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Enemy EnemyPrefab;

    public void StartSpawning()
    {
        Debug.Log("started spawning");
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(2);
        var spawnedObj = Instantiate(EnemyPrefab);
        spawnedObj.GetComponent<NetworkObject>().Spawn(true);
        Debug.Log("spawned enemy");
        StartCoroutine(SpawnEnemies());
    }
}
