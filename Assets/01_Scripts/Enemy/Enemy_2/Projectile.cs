using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;  // Velocidad del proyectil
    public float damageAmount = 10f;  // Daño que hará el proyectil

    void Update()
    {
        // Mover el proyectil hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el proyectil impacta al jugador
        if (other.CompareTag("Player"))
        {
            Debug.Log("Impacto con el jugador");

            // Obtener el componente HealthBar del jugador
            HealthBar playerHealth = other.GetComponent<HealthBar>();
            if (playerHealth != null)
            {
                Debug.Log("Aplicando daño al jugador");
                // Aplicar daño al jugador
                playerHealth.TakeDamage(damageAmount);
                // Actualizar la barra de vida
                playerHealth.UpdateHealthBar();
            }

            // Destruir el proyectil inmediatamente después del impacto
            Destroy(gameObject);
        }
        else
        {
            // Destruir el proyectil si golpea algo que no es el jugador
            Destroy(gameObject, 2f);  // Destruye el proyectil después de 2 segundos si no golpea al jugador
        }
    }
}