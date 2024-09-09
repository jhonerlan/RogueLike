using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float detectionRadius = 10f;  // Radio de detección del jugador
    public float attackRadius = 10f;  // Radio en el que el enemigo ataca al jugador
    public float attackCooldown = 1.0f;  // Tiempo entre ataques
    public float damageAmount = 10f;  // Cantidad de daño que el enemigo inflige
    public float health = 100f;  // Salud del enemigo
    private float lastAttackTime;

    private Transform playerTransform;
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Agent on NavMesh: {navMeshAgent.isOnNavMesh}, Position: {transform.position}, Player Position: {playerTransform.position}, Distance: {Vector3.Distance(transform.position, playerTransform.position)}");
        if (playerTransform != null && navMeshAgent.isOnNavMesh)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer <= detectionRadius)
            {
                navMeshAgent.SetDestination(playerTransform.position);

                if (distanceToPlayer <= attackRadius)
                {
                    // Solo detener el agente si está sobre el NavMesh y está activo
                    if (navMeshAgent.isActiveAndEnabled)
                    {
                        navMeshAgent.isStopped = true;
                        if (Time.time > lastAttackTime + attackCooldown)
                        {
                            AttackPlayer();
                            lastAttackTime = Time.time;
                        }
                    }
                }
                else
                {
                    navMeshAgent.isStopped = false;
                }
            }
        }
        else
        {
            // Verificar si el agente está en el NavMesh
            if (!navMeshAgent.isOnNavMesh)
            {
                Debug.LogError("NavMeshAgent not on NavMesh!");
            }
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Daño recibido: " + damage + ". Salud restante: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("El enemigo ha muerto");
        Destroy(gameObject);  // Destruye el enemigo
    }

    private void AttackPlayer()
    {
        // Verifica si el jugador está dentro del área de ataque y aplica daño
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                HealthBar healthBar = hitCollider.GetComponent<HealthBar>();
                if (healthBar != null)
                {
                    healthBar.vidaActual = Mathf.Max(healthBar.vidaActual - damageAmount, 0);  // Disminuye la vida sin bajar de 0
                    healthBar.UpdateHealthBar();
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja el área de detección y ataque en la escena
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
