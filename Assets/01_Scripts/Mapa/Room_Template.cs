using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Template : MonoBehaviour
{
    public GameObject[] Room_Down;
    public GameObject[] Room_Up;
    public GameObject[] Room_Left;
    public GameObject[] Room_Right;

    public GameObject[] Room_Down_arena;
    public GameObject[] Room_Up_arena;
    public GameObject[] Room_Left_arena;
    public GameObject[] Room_Right_arena;

    public GameObject[] Room_Down_cuadro;
    public GameObject[] Room_Up_cuadro;
    public GameObject[] Room_Left_cuadro;
    public GameObject[] Room_Right_cuadro;

    public GameObject[] Room_Down_pasto;
    public GameObject[] Room_Up_pasto;
    public GameObject[] Room_Left_pasto;
    public GameObject[] Room_Right_pasto;

    public GameObject[] Room_Down_tierra;
    public GameObject[] Room_Up_tierra;
    public GameObject[] Room_Left_tierra;
    public GameObject[] Room_Right_tierra;

    public GameObject[] Pisos;
    public GameObject[] Room_central;
    public int nivel;

    public Material[] materials_piso;
    public Material[] materials_pared;

    public GameObject closedRoom;
    public GameObject piso;

    public List<GameObject> roomList = new List<GameObject>(); // Inicializamos la lista


    public GameObject magoPrefab;
    public GameObject enemy1Prefab;
    // Variables para el jefe
    public GameObject[] bossSpawnPoints; // Puntos de aparici�n del jefe
    public GameObject bossPrefab; // Prefab del jefe

    public GameObject boss;
    public GameObject[] enemigos;

    // Variables para control de spawn
    public float spawnDelay = 3f;  // Tiempo de espera antes de spawnear los enemigos
    public int totalRoomsExpected; // N�mero total de habitaciones esperadas

    private void Start()
    {
        nivel = Random.Range(0, Room_central.Length);
        Instantiate(Room_central[nivel], transform.position, transform.rotation);
        Invoke("CheckIfMapIsComplete", spawnDelay); // Verificamos despu�s de un tiempo si el mapa est� completo
    }

    // Verificamos si el mapa est� completo para iniciar el spawn de enemigos
    void CheckIfMapIsComplete()
    {
        if (roomList.Count >= totalRoomsExpected)
        {
            Debug.Log("Mapa completo. Spawneando enemigos...");
            spawn_enemies();
        }
        else
        {
            Invoke("CheckIfMapIsComplete", 1f);  // Volvemos a intentar despu�s de 1 segundo
        }
    }

    // M�todo para spawnear enemigos
    void spawn_enemies()
    {
        if (roomList.Count > 1)
        {
            // Spawneamos al jefe en la �ltima habitaci�n
            if (bossPrefab != null)
                Instantiate(bossPrefab, roomList[roomList.Count - 1].transform.position, Quaternion.identity);

            // Encontrar una habitaci�n que no sea la �ltima para spawnean Enemy_1 y Mago
            int specialRoomIndex = Random.Range(0, roomList.Count - 1);  // Aseg�rate de no seleccionar la �ltima habitaci�n

            // Spawneamos Enemy_1 y Mago en la misma habitaci�n seleccionada
            Instantiate(magoPrefab, roomList[specialRoomIndex].transform.position, Quaternion.identity);
            Instantiate(enemy1Prefab, roomList[specialRoomIndex].transform.position + new Vector3(1, 0, 0), Quaternion.identity); // Ligeramente desplazado para evitar superposici�n

            // Spawneamos otros enemigos en habitaciones aleatorias excepto en la especial y la del jefe
            for (int i = 0; i < enemigos.Length; i++)
            {
                int randomIndex;
                do
                {
                    randomIndex = Random.Range(0, roomList.Count - 1);
                } while (randomIndex == specialRoomIndex || randomIndex == roomList.Count - 1); // Evita la habitaci�n del jefe y la habitaci�n especial

                Instantiate(enemigos[i], roomList[randomIndex].transform.position, Quaternion.identity);
            }
        }
    }
}