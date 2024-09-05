using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;  // Asigna el objeto del jugador desde el Inspector
    public Vector3 offset;    // Define la distancia y altura desde la cual la c�mara sigue al jugador

    void LateUpdate()
    {
        // Mant�n la c�mara en la posici�n del jugador m�s el offset
        transform.position = player.position + offset;
    }
}

