using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyPrefab;

    [SerializeField]
    private float DistanceFromPlayer = 7;

    [SerializeField]
    private float SpawnDelay = 0.5f;

    public void StartSpawning()
    {
        Debug.Log("started spawning");
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(SpawnDelay);
        var players = GameObject.FindGameObjectsWithTag("Player").ToList();
        var angle = Random.Range(0, 360);

        var spawnedObj = Instantiate(EnemyPrefab, transform);
        Vector3 positionDiff = GetEnemyPositionOutOfSight(players, angle);
        spawnedObj.transform.position = positionDiff;

        spawnedObj.GetComponent<NetworkObject>().Spawn(true);
        Debug.Log("spawned enemy");
        StartCoroutine(SpawnEnemies());
    }

    private Vector3 GetEnemyPositionOutOfSight(List<GameObject> players, float angle)
    {
        var player = players[Random.Range(0, players.Count)];

        players.Remove(player);

        var positionDiff = new Vector3(
            DistanceFromPlayer * Mathf.Cos(angle),
            DistanceFromPlayer * Mathf.Sin(angle));

        var newPosition = player.transform.position + positionDiff;

        if (players.Any(p => Vector3.Distance(p.transform.position, newPosition) < DistanceFromPlayer))
        {
            return GetEnemyPositionOutOfSight(players, angle);
        }

        return newPosition;
    }
}
