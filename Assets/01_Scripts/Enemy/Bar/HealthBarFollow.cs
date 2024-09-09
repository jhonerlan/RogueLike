using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    public Transform player;  // Referencia al objeto jugador
    public Transform healthBarPosition;  // Posici�n sobre la cabeza del jugador

    private RectTransform healthBarUI;

    void Start()
    {
        // Obtener el RectTransform del UI de la barra de vida
        healthBarUI = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (player != null && healthBarPosition != null)  // Verificaci�n de que player y healthBarPosition a�n existen
        {
            // Convertir la posici�n del mundo 3D a una posici�n en la pantalla
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(healthBarPosition.position);

            // Actualizar la posici�n del UI de la barra de vida
            healthBarUI.position = screenPosition;
        }
    }
}
