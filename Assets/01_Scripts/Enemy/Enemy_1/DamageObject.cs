using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public float damageAmount = 10f;  // Cantidad de vida que se disminuye en cada actualizaci�n
    public float damageInterval = 1f; // Intervalo de tiempo entre da�os aplicados
    private float lastDamageTime;

    private HashSet<Collider> playersInRange = new HashSet<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Aseg�rate de que tu jugador tiene el tag "Player"
        {
            playersInRange.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playersInRange.Remove(other);
        }
    }

    private void Update()
    {
        if (Time.time >= lastDamageTime + damageInterval)
        {
            foreach (var player in playersInRange)
            {
                if (player != null)  // Verificaci�n de que el Collider a�n existe
                {
                    HealthBar healthBar = player.GetComponent<HealthBar>();
                    if (healthBar != null)
                    {
                        healthBar.vidaActual = Mathf.Max(healthBar.vidaActual - damageAmount, 0);  // Disminuye la vida sin bajar de 0
                        healthBar.UpdateHealthBar();
                    }
                }
            }
            lastDamageTime = Time.time;
        }
    }
}
