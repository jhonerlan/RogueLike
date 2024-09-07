using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Spawner : MonoBehaviour
{
    public int nivel;
    public int openSide;

    private Room_Template template;
    private int rand;
    private bool spawned = false;
    void Start()
    {
        template = GameObject.FindGameObjectWithTag("Rooms").GetComponent<Room_Template>();
        Invoke("Spawn", 0.1f);
    }

    
    void Spawn()
    {
        nivel = template.nivel;
        Debug.Log(nivel);

        GameObject room = null;

        if (nivel == 0)
        {
            Debug.Log("mapa oscuro " + nivel);
            if (spawned == false)
            {
                if (openSide == 2)
                {
                    rand = Random.Range(0, template.Room_Up.Length);
                    room = Instantiate(template.Room_Up[rand], transform.position, template.Room_Up[rand].transform.rotation);
                }
                else if (openSide == 1)
                {
                    rand = Random.Range(0, template.Room_Down.Length);
                    room = Instantiate(template.Room_Down[rand], transform.position, template.Room_Down[rand].transform.rotation);
                }
                else if (openSide == 4)
                {
                    rand = Random.Range(0, template.Room_Right.Length);
                    room = Instantiate(template.Room_Right[rand], transform.position, template.Room_Right[rand].transform.rotation);
                }
                else if (openSide == 3)
                {
                    rand = Random.Range(0, template.Room_Left.Length);
                    room = Instantiate(template.Room_Left[rand], transform.position, template.Room_Left[rand].transform.rotation);

                }
                spawned = true;

                if (room != null)
                {
                    // Desactivar puertas en la habitación instanciada
                    Transform contenedorDePuertas = room.transform.Find("Walls");
                    if (contenedorDePuertas != null)
                    {
                        foreach (Transform child in contenedorDePuertas)
                        {
                            if (child.CompareTag("Puerta"))
                            {
                                child.gameObject.SetActive(false);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogWarning("No se encontró el objeto 'Walls' en la habitación instanciada.");
                    }
                }
            }
        }
        else if (nivel == 1)
        {
            Debug.Log("mapa arena " + nivel);
            if (spawned == false)
            {
                if (openSide == 2)
                {
                    rand = Random.Range(0, template.Room_Up.Length);
                    room = Instantiate(template.Room_Up_arena[rand], transform.position, template.Room_Up_arena[rand].transform.rotation);
                }
                else if (openSide == 1)
                {
                    rand = Random.Range(0, template.Room_Down.Length);
                    room = Instantiate(template.Room_Down_arena[rand], transform.position, template.Room_Down_arena[rand].transform.rotation);
                }
                else if (openSide == 4)
                {
                    rand = Random.Range(0, template.Room_Right.Length);
                    room = Instantiate(template.Room_Right_arena[rand], transform.position, template.Room_Right_arena[rand].transform.rotation);
                }
                else if (openSide == 3)
                {
                    rand = Random.Range(0, template.Room_Left.Length);
                    room = Instantiate(template.Room_Left_arena[rand], transform.position, template.Room_Left_arena[rand].transform.rotation);

                }
                spawned = true;

                if (room != null)
                {
                    // Desactivar puertas en la habitación instanciada
                    Transform contenedorDePuertas = room.transform.Find("Walls");
                    if (contenedorDePuertas != null)
                    {
                        foreach (Transform child in contenedorDePuertas)
                        {
                            if (child.CompareTag("Puerta"))
                            {
                                child.gameObject.SetActive(false);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogWarning("No se encontró el objeto 'Walls' en la habitación instanciada.");
                    }
                }
            }
        }
        else if (nivel == 2)
        {
            Debug.Log("mapa cuadro " + nivel);
            if (spawned == false)
            {
                if (openSide == 2)
                {
                    rand = Random.Range(0, template.Room_Up.Length);
                    room = Instantiate(template.Room_Up_cuadro[rand], transform.position, template.Room_Up_cuadro[rand].transform.rotation);
                }
                else if (openSide == 1)
                {
                    rand = Random.Range(0, template.Room_Down.Length);
                    room = Instantiate(template.Room_Down_cuadro[rand], transform.position, template.Room_Down_cuadro[rand].transform.rotation);
                }
                else if (openSide == 4)
                {
                    rand = Random.Range(0, template.Room_Right.Length);
                    room = Instantiate(template.Room_Right_cuadro[rand], transform.position, template.Room_Right_cuadro[rand].transform.rotation);
                }
                else if (openSide == 3)
                {
                    rand = Random.Range(0, template.Room_Left.Length);
                    room = Instantiate(template.Room_Left_cuadro[rand], transform.position, template.Room_Left_cuadro[rand].transform.rotation);

                }
                spawned = true;

                if (room != null)
                {
                    // Desactivar puertas en la habitación instanciada
                    Transform contenedorDePuertas = room.transform.Find("Walls");
                    if (contenedorDePuertas != null)
                    {
                        foreach (Transform child in contenedorDePuertas)
                        {
                            if (child.CompareTag("Puerta"))
                            {
                                child.gameObject.SetActive(false);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogWarning("No se encontró el objeto 'Walls' en la habitación instanciada.");
                    }
                }
            }
        }
        else if (nivel == 3)
        {
            Debug.Log("mapa pasto " + nivel);
            if (spawned == false)
            {
                if (openSide == 2)
                {
                    rand = Random.Range(0, template.Room_Up.Length);
                    room = Instantiate(template.Room_Up_pasto[rand], transform.position, template.Room_Up_pasto[rand].transform.rotation);
                }
                else if (openSide == 1)
                {
                    rand = Random.Range(0, template.Room_Down.Length);
                    room = Instantiate(template.Room_Down_pasto[rand], transform.position, template.Room_Down_pasto[rand].transform.rotation);
                }
                else if (openSide == 4)
                {
                    rand = Random.Range(0, template.Room_Right.Length);
                    room = Instantiate(template.Room_Right_pasto[rand], transform.position, template.Room_Right_pasto[rand].transform.rotation);
                }
                else if (openSide == 3)
                {
                    rand = Random.Range(0, template.Room_Left.Length);
                    room = Instantiate(template.Room_Left_pasto[rand], transform.position, template.Room_Left_pasto[rand].transform.rotation);

                }
                spawned = true;

                if (room != null)
                {
                    // Desactivar puertas en la habitación instanciada
                    Transform contenedorDePuertas = room.transform.Find("Walls");
                    if (contenedorDePuertas != null)
                    {
                        foreach (Transform child in contenedorDePuertas)
                        {
                            if (child.CompareTag("Puerta"))
                            {
                                child.gameObject.SetActive(false);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogWarning("No se encontró el objeto 'Walls' en la habitación instanciada.");
                    }
                }
            }
        }
        else if (nivel == 4)
        {
            Debug.Log("mapa tierra " + nivel);
            if (spawned == false)
            {
                if (openSide == 2)
                {
                    rand = Random.Range(0, template.Room_Up.Length);
                    room = Instantiate(template.Room_Up_tierra[rand], transform.position, template.Room_Up_tierra[rand].transform.rotation);
                }
                else if (openSide == 1)
                {
                    rand = Random.Range(0, template.Room_Down.Length);
                    room = Instantiate(template.Room_Down_tierra[rand], transform.position, template.Room_Down_tierra[rand].transform.rotation);
                }
                else if (openSide == 4)
                {
                    rand = Random.Range(0, template.Room_Right.Length);
                    room = Instantiate(template.Room_Right_tierra[rand], transform.position, template.Room_Right_tierra[rand].transform.rotation);
                }
                else if (openSide == 3)
                {
                    rand = Random.Range(0, template.Room_Left.Length);
                    room = Instantiate(template.Room_Left_tierra[rand], transform.position, template.Room_Left_tierra[rand].transform.rotation);

                }
                spawned = true;

                if (room != null)
                {
                    // Desactivar puertas en la habitación instanciada
                    Transform contenedorDePuertas = room.transform.Find("Walls");
                    if (contenedorDePuertas != null)
                    {
                        foreach (Transform child in contenedorDePuertas)
                        {
                            if (child.CompareTag("Puerta"))
                            {
                                child.gameObject.SetActive(false);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogWarning("No se encontró el objeto 'Walls' en la habitación instanciada.");
                    }
                }
            }
        }
       
    }


    private void OnTriggerEnter(Collider other)
    {
        // Verifica que el componente Room_Spawner esté presente en el objeto "other"
       // Room_Spawner otherSpawner = other.GetComponent<Room_Spawner>();

            if (other.CompareTag("SpawnPoint"))
            {
            //if (otherSpawner.spawned == false && spawned == false)
            //{
            //    Instantiate(template.closedRoom, transform.position, Quaternion.identity);
            //    Destroy(gameObject);
            //}
            //spawned = true;

            Destroy(gameObject);
            }
      
    }

}
