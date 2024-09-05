using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    public Transform player;  // Referencia al objeto jugador
    public Transform healthBarPosition;  // Posición sobre la cabeza del jugador

    private RectTransform healthBarUI;

    void Start()
    {
        // Obtener el RectTransform del UI de la barra de vida
        healthBarUI = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (player != null && healthBarPosition != null)  // Verificación de que player y healthBarPosition aún existen
        {
            // Convertir la posición del mundo 3D a una posición en la pantalla
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(healthBarPosition.position);

            // Actualizar la posición del UI de la barra de vida
            healthBarUI.position = screenPosition;
        }
    }
}
