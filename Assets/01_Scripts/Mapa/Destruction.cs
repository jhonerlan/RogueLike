using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Piso") || other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            Debug.Log("hay un piso");
        }
        else
        {

        Destroy(other.gameObject);
        }
    }
}
