using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Boss : MonoBehaviour
{
    private Room_Template template;
    private bool bossSpawned = false; // Bandera para rastrear si el jefe ya ha sido generado

    void Start()
    {
        template = GameObject.FindGameObjectWithTag("Rooms").GetComponent<Room_Template>();
        Invoke("SpawnGoblin", 1f); // Ajusta el tiempo según sea necesario
    }

    void SpawnGoblin()
    {
        if (!bossSpawned) // Solo genera el jefe si no ha sido generado aún
        {
            if (template.bossSpawnPoints != null && template.bossSpawnPoints.Length > 0)
            {
                // Selecciona un punto de spawn al azar para el jefe
                Transform randomSpawnPoint = template.bossSpawnPoints[Random.Range(0, template.bossSpawnPoints.Length)].transform;
                Instantiate(template.bossPrefab, randomSpawnPoint.position + new Vector3(0, 15, 0), Quaternion.identity);


                bossSpawned = true; // Marca que el jefe ha sido generado
            }
            else
            {
                Debug.LogError("No hay puntos de spawn asignados en bossSpawnPoints o la lista está vacía.");
            }
        }
    }
}
