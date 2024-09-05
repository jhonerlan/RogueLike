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

    public List<GameObject> roomList;

    // Variables para el jefe
    public GameObject[] bossSpawnPoints; // Puntos de aparición del jefe
    public GameObject bossPrefab; // Prefab del jefe

    public GameObject boss;
    public GameObject[] enemigos;

    private void Start()
    {
        nivel = Random.Range(0, Room_central.Length);

        Instantiate(Room_central[nivel], transform.position, transform.rotation);
        Invoke("spawn_enemies", 3f);
    }

    void spawn_enemies()
    {
        Instantiate(boss, roomList[roomList.Count - 1].transform.position, Quaternion.identity);
        if (roomList.Count > 1)
        {
            List<int> usedIndices = new List<int>();

            for (int i = 0; i < enemigos.Length; i++)
            {
                int randomIndex;
                do
                {
                    randomIndex = Random.Range(0, roomList.Count - 1);
                } while (usedIndices.Contains(randomIndex));
                usedIndices.Add(randomIndex);
                Instantiate(enemigos[i], roomList[randomIndex].transform.position, Quaternion.identity);
            }
        }
    }
}
