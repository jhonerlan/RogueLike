using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 3f;  // Velocidad de movimiento del mago
    public float range = 5f;  // Rango en el que el mago puede moverse

    private Vector3 targetPosition;

    void Start()
    {
        SetNewRandomTarget();
    }

    void Update()
    {
        MoveTowardsTarget();
    }

    void SetNewRandomTarget()
    {
        // Generar una nueva posici�n aleatoria dentro del rango definido
        float randomX = Random.Range(-range, range);
        float randomZ = Random.Range(-range, range);

        // Establecer la nueva posici�n objetivo basada en la posici�n inicial del mago
        targetPosition = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
    }

    void MoveTowardsTarget()
    {
        // Mover al mago hacia la posici�n objetivo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Si el mago ha alcanzado la posici�n objetivo, genera un nuevo objetivo
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetNewRandomTarget();
        }
    }
}