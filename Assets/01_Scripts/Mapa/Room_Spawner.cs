using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Spawner : MonoBehaviour
{
    public int openSide;
    public int nivel;

    private Room_Template template;

    private int rand;
    private bool spawned = false;
    void Start()
    {
        template = GameObject.FindGameObjectWithTag("Rooms").GetComponent<Room_Template>();
        //Instantiate(template.piso, transform.position, Quaternion.identity);
        Invoke("Spawn", 0.2f);
    }

    // Update is called once per frame
    void Spawn()
    {
        nivel = template.nivel;
        Debug.Log("mapa oscuro" + nivel);
        if (nivel == 0)
        {
            if (spawned == false)
            {
                if (openSide == 2)
                {
                    rand = Random.Range(0, template.Room_Up.Length);
                    Instantiate(template.Room_Up[rand], transform.position, template.Room_Up[rand].transform.rotation);
                }
                else if (openSide == 1)
                {
                    rand = Random.Range(0, template.Room_Down.Length);
                    Instantiate(template.Room_Down[rand], transform.position, template.Room_Down[rand].transform.rotation);
                }
                else if (openSide == 4)
                {
                    rand = Random.Range(0, template.Room_Right.Length);
                    Instantiate(template.Room_Right[rand], transform.position, template.Room_Right[rand].transform.rotation);
                }
                else if (openSide == 3)
                {
                    rand = Random.Range(0, template.Room_Left.Length);
                    Instantiate(template.Room_Left[rand], transform.position, template.Room_Left[rand].transform.rotation);
                }
                spawned = true;
            }
        }
        // Repeat similar logic for other levels...
        else if (nivel == 1)
        {
            Debug.Log("mapa arena" + nivel);
            if (spawned == false)
            {
                if (openSide == 2)
                {
                    rand = Random.Range(0, template.Room_Up.Length);
                    Instantiate(template.Room_Up_arena[rand], transform.position, template.Room_Up_arena[rand].transform.rotation);
                }
                else if (openSide == 1)
                {
                    rand = Random.Range(0, template.Room_Down.Length);
                    Instantiate(template.Room_Down_arena[rand], transform.position, template.Room_Down_arena[rand].transform.rotation);
                }
                else if (openSide == 4)
                {
                    rand = Random.Range(0, template.Room_Right.Length);
                    Instantiate(template.Room_Right_arena[rand], transform.position, template.Room_Right_arena[rand].transform.rotation);
                }
                else if (openSide == 3)
                {
                    rand = Random.Range(0, template.Room_Left.Length);
                    Instantiate(template.Room_Left_arena[rand], transform.position, template.Room_Left_arena[rand].transform.rotation);
                }
                spawned = true;
            }
        }
        else if (nivel == 2)
        {
            Debug.Log("mapa cuadro" + nivel);
            if (spawned == false)
            {
                if (openSide == 2)
                {
                    rand = Random.Range(0, template.Room_Up.Length);
                    Instantiate(template.Room_Up_cuadro[rand], transform.position, template.Room_Up_cuadro[rand].transform.rotation);
                }
                else if (openSide == 1)
                {
                    rand = Random.Range(0, template.Room_Down.Length);
                    Instantiate(template.Room_Down_cuadro[rand], transform.position, template.Room_Down_cuadro[rand].transform.rotation);
                }
                else if (openSide == 4)
                {
                    rand = Random.Range(0, template.Room_Right.Length);
                    Instantiate(template.Room_Right_cuadro[rand], transform.position, template.Room_Right_cuadro[rand].transform.rotation);
                }
                else if (openSide == 3)
                {
                    rand = Random.Range(0, template.Room_Left.Length);
                    Instantiate(template.Room_Left_cuadro[rand], transform.position, template.Room_Left_cuadro[rand].transform.rotation);
                }
                spawned = true;
            }
        }
        else if (nivel == 3)
        {
            Debug.Log("mapa pasto" + nivel);
            if (spawned == false)
            {
                if (openSide == 2)
                {
                    rand = Random.Range(0, template.Room_Up.Length);
                    Instantiate(template.Room_Up_pasto[rand], transform.position, template.Room_Up_pasto[rand].transform.rotation);
                }
                else if (openSide == 1)
                {
                    rand = Random.Range(0, template.Room_Down.Length);
                    Instantiate(template.Room_Down_pasto[rand], transform.position, template.Room_Down_pasto[rand].transform.rotation);
                }
                else if (openSide == 4)
                {
                    rand = Random.Range(0, template.Room_Right.Length);
                    Instantiate(template.Room_Right_pasto[rand], transform.position, template.Room_Right_pasto[rand].transform.rotation);
                }
                else if (openSide == 3)
                {
                    rand = Random.Range(0, template.Room_Left.Length);
                    Instantiate(template.Room_Left_pasto[rand], transform.position, template.Room_Left_pasto[rand].transform.rotation);
                }
                spawned = true;
            }
        }
        else if (nivel == 4)
        {
            Debug.Log("mapa tierra" + nivel);
            if (spawned == false)
            {
                if (openSide == 2)
                {
                    rand = Random.Range(0, template.Room_Up.Length);
                    Instantiate(template.Room_Up_tierra[rand], transform.position, template.Room_Up_tierra[rand].transform.rotation);
                }
                else if (openSide == 1)
                {
                    rand = Random.Range(0, template.Room_Down.Length);
                    Instantiate(template.Room_Down_tierra[rand], transform.position, template.Room_Down_tierra[rand].transform.rotation);
                }
                else if (openSide == 4)
                {
                    rand = Random.Range(0, template.Room_Right.Length);
                    Instantiate(template.Room_Right_tierra[rand], transform.position, template.Room_Right_tierra[rand].transform.rotation);
                }
                else if (openSide == 3)
                {
                    rand = Random.Range(0, template.Room_Left.Length);
                    Instantiate(template.Room_Left_tierra[rand], transform.position, template.Room_Left_tierra[rand].transform.rotation);
                }
                spawned = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            spawned = true;
            Destroy(gameObject);
        }
    }
}
