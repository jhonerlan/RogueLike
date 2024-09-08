using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public GameObject[] puertas; // Array de puertas a activar/desactivar
    private bool jugadorEnArea = false; // Indica si el jugador est� en el �rea
    private int enemigosEnArea = 0; // Cuenta los enemigos en el �rea

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hay un jugador");
            jugadorEnArea = true;
            ActualizarPuertas();
        }
        else if (other.CompareTag("Enemy")) // Ajusta el tag seg�n sea necesario
        {
            enemigosEnArea++;
            Debug.Log(enemigosEnArea);
            ActualizarPuertas();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnArea = false;
            ActualizarPuertas();
        }
        else if (other.CompareTag("Enemigo")) // Ajusta el tag seg�n sea necesario
        {
            enemigosEnArea--;
            ActualizarPuertas();
        }
    }

    private void ActualizarPuertas()
    {
        // Activa las puertas si el jugador est� en el �rea y hay enemigos presentes
        bool activarPuertas = jugadorEnArea && enemigosEnArea > 0;

        foreach (GameObject puerta in puertas)
        {
            if (puerta != null)
            {
                puerta.SetActive(activarPuertas);
            }
        }
    }
}
