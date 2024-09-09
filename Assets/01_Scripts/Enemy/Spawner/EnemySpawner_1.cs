using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_1 : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo
    public Transform player; // Referencia al jugador
    public float spawnRadius = 5f; // Radio de spawn
    public int baseEnemyCount = 5; // Cantidad base de enemigos a spawnear
    public int additionalEnemiesPerRoom = 1; // Incremento de enemigos por habitación

    private bool hasSpawned = false;

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= spawnRadius && !hasSpawned)
        {
            int enemyCount = baseEnemyCount + additionalEnemiesPerRoom; // Ajustar el número de enemigos
            for (int i = 0; i < enemyCount; i++)
            {
                Instantiate(enemyPrefab, transform.position, transform.rotation);
            }
            hasSpawned = true;
        }
    }
}
