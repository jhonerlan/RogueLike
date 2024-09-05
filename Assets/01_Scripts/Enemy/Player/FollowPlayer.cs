using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;  // Asigna el objeto del jugador desde el Inspector
    public Vector3 offset;    // Define la distancia y altura desde la cual la cámara sigue al jugador

    void LateUpdate()
    {
        // Mantén la cámara en la posición del jugador más el offset
        transform.position = player.position + offset;
    }
}

