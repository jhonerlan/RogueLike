using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAttack : MonoBehaviour
{
    public Transform player;  // Referencia al jugador
    public GameObject proyectilPrefab;  // Prefab del proyectil que el mago disparará
    public Transform firePoint;  // Punto desde donde se disparará el proyectil
    public float detectionRange = 1f;  // Distancia a la que el mago detecta al jugador
    public float attackCooldown = 2f;  // Tiempo entre ataques

    private float lastAttackTime;

    void Update()
    {
        // Verificar que player y firePoint no sean nulos
        if (player == null || firePoint == null)
        {
            Debug.LogWarning("Referencia perdida en MageAttack: player o firePoint es null");
            return;
        }

        // Calcular la distancia al jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si el jugador está dentro del rango de detección y se puede atacar
        if (distanceToPlayer <= detectionRange && Time.time >= lastAttackTime + attackCooldown)
        {
            AttackPlayer();
            lastAttackTime = Time.time;  // Actualizar el tiempo del último ataque
        }
    }

    void AttackPlayer()
    {
        Debug.Log("Mago dispara un proyectil!");

        // Verificar que firePoint no sea nulo
        if (firePoint == null)
        {
            Debug.LogWarning("firePoint es null, no se puede disparar el proyectil");
            return;
        }

        // Crear y disparar el proyectil hacia el jugador
        GameObject proyectil = Instantiate(proyectilPrefab, firePoint.position, firePoint.rotation);
        Vector3 direction = (player.position - firePoint.position).normalized;
        proyectil.transform.forward = direction;

        // Añadir velocidad al proyectil en dirección al jugador
        Rigidbody proyectilRigidbody = proyectil.GetComponent<Rigidbody>();
        if (proyectilRigidbody != null)
        {
            proyectilRigidbody.velocity = direction * 10f; // Ajusta la velocidad según sea necesario
        }
        else
        {
            Debug.LogWarning("El proyectil no tiene un Rigidbody");
        }
    }
}
