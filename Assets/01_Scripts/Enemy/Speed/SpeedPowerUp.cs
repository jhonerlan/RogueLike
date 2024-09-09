using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float speedMultiplier = 2f;  // Factor de multiplicación de la velocidad
    public float duration = 5f;  // Duración del power-up en segundos

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))  // Asegúrate de que tu jugador tiene el tag "Player"
        {
            PlayerController playerController = other.GetComponent<PlayerController>();  // Suponiendo que tienes un script PlayerMovement para manejar el movimiento
            if (playerController != null)
            {
                StartCoroutine(ApplySpeedPowerUp(playerController));
            }
            Destroy(gameObject);  // Destruye el power-up después de recogerlo
        }
    }

    private IEnumerator ApplySpeedPowerUp(PlayerController playerController)
    {
        // Doblar la velocidad
        playerController.speed *= speedMultiplier;

        // Esperar la duración del power-up
        yield return new WaitForSeconds(duration);

        // Restaurar la velocidad original
        playerController.speed /= speedMultiplier;
    }
}