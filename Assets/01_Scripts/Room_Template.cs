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

    public GameObject[] Room_central;
    public int nivel;

    public GameObject closedRoom;

    public List<GameObject> roomList;
    private void Start()
    {
        nivel = Random.Range(0, Room_central.Length);

        Instantiate(Room_central[nivel], transform.position, transform.rotation);
    }
}
