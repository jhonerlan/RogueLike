using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_1 : MonoBehaviour
{
    public GameObject enemyPrefab; // Referencia al prefab del enemigo
    public Transform player; // Referencia al transform del jugador
    public float spawnRadius = 5f; // Distancia a la cual se spawneará el enemigo
    public int enemyCount = 3; // Cantidad de enemigos a spawnear

    private bool hasSpawned = false; // Controla si ya se ha hecho spawn

    void Update()
    {
        // Verifica que la referencia al jugador no sea nula
        if (player == null)
        {
            Debug.LogWarning("Referencia al jugador es nula en EnemySpawner_1");
            return;
        }

        // Verifica la distancia entre el jugador y el spawner
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= spawnRadius && !hasSpawned)
        {
            // Spawnea la cantidad de enemigos especificada
            for (int i = 0; i < enemyCount; i++)
            {
                // Instancia el enemigo en la posición del spawner
                Instantiate(enemyPrefab, transform.position, transform.rotation);
            }

            hasSpawned = true; // Asegura que solo se haga spawn una vez
        }
    }

    // Dibuja el radio en la escena para referencia
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
