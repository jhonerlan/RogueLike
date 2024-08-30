using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Spawner : MonoBehaviour
{
    public int openSide;

    private Room_Template template;
    private int rand;
    private bool spawned = false;
    void Start()
    {
        template = GameObject.FindGameObjectWithTag("Rooms").GetComponent<Room_Template>();
        Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    void Spawn()
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
