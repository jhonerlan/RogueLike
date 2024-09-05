using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public float healAmount = 30f;  // Cantidad de vida que se restaura el power-up

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  
        {
            HealthBar healthBar = other.GetComponent<HealthBar>();
            if (healthBar != null)
            {
                healthBar.IncreaseHealth(healAmount);  // Incrementa la vida en la cantidad especificada
            }
            Destroy(gameObject);  // Destruye el power-up después de recogerlo
        }
    }
}