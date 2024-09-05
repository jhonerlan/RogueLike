using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Trol Stats")]
    public float health = 100f;
    public float damage = 10f;
    public float detectionRange = 10f;
    public float attackRange = 2f;
    public float idleTime = 4f;
    public float walkTime = 10f;
    public float speed = 1f;
    public float runSpeed = 3f;
    private float stateTimer;
    private Vector3 randomDirection;
    public float attackCooldown = 2f; // Tiempo entre ataques
    private float attackTimer;
    private bool active;

    [Header("Trol References")]
    private Rigidbody rb;
    private Animator animator;
    private Transform player;
    public LayerMask obstacleLayer;

    private enum State { Idle, Walking, Run, Attack, Death }
    private State currentState;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rb.freezeRotation = true;
        currentState = State.Idle;
        active = false;
        stateTimer = idleTime;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.Idle:
                IdleState();
                break;
            case State.Walking:
                WalkingState();
                break;
            case State.Run:
                RunState();
                break;
            case State.Attack:
                AttackState();
                attackTimer -= Time.deltaTime;
                if (attackTimer <= 0)
                {
                    if (Vector3.Distance(transform.position, player.position) > attackRange)
                    {
                        currentState = State.Run;
                        animator.SetTrigger("Run");
                        animator.SetInteger("AttackType", 0);
                        return;
                    }
                    else if (Random.Range(1, 3) == 1)
                    {
                        AttackState();
                        animator.SetInteger("AttackType", 1); // Ejecuta el ataque 1
                    }
                    else
                    {
                        AttackState();
                        animator.SetInteger("AttackType", 2); // Ejecuta el ataque 2
                    }
                    attackTimer = attackCooldown;  // Resetea el temporizador de ataque
                }
                break;
            case State.Death:
                DeathState();
                break;
        }

        if (health <= 0 && currentState != State.Death)
        {
            currentState = State.Death;
            animator.SetTrigger("Death");
        }
    }

    void IdleState()
    {
        if (active)
        {
            stateTimer -= Time.deltaTime;

            if (stateTimer <= 0)
            {
                currentState = State.Walking;
                stateTimer = walkTime;
                randomDirection = GetRandomDirection();
                animator.SetTrigger("Walk");
            }
        }
        else if (Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            currentState = State.Run;
            animator.SetTrigger("Run");
            active = true;
            return;
        }
    }

    Vector3 GetRandomDirection()
    {
        Vector3 randomDir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        return randomDir.normalized;
    }

    void WalkingState()
    {
        if (Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            currentState = State.Run;
            animator.SetTrigger("Run");
            return;
        }

        stateTimer -= Time.deltaTime;

        // Rota hacia la dirección en la que se está moviendo
        if (randomDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(randomDirection);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, Time.deltaTime * speed);
        }

        rb.MovePosition(rb.position + randomDirection * speed * Time.deltaTime);

        RaycastHit hit;
        if (Physics.Raycast(rb.position, rb.transform.forward, out hit, 1f, obstacleLayer))
        {
            randomDirection = GetRandomDirection();
        }

        if (stateTimer <= 0)
        {
            stateTimer = idleTime;
            currentState = State.Idle;
            animator.SetTrigger("Idle");
            randomDirection = GetRandomDirection();
        }
    }

    void RunState()
    {
        if (Vector3.Distance(rb.position, player.position) > detectionRange)
        {
            currentState = State.Walking;
            animator.SetTrigger("Walk");
            return;
        }

        if (Vector3.Distance(rb.position, player.position) <= attackRange)
        {
            currentState = State.Attack;
            animator.SetInteger("AttackType", 1);
            return;
        }

        Vector3 direction = (player.position - rb.position).normalized;

        // Rota hacia la dirección del jugador
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, Time.deltaTime * runSpeed);
        }

        rb.MovePosition(rb.position + direction * runSpeed * Time.deltaTime);

        RaycastHit hit;
        if (Physics.Raycast(rb.position, rb.transform.forward, out hit, 1f, obstacleLayer))
        {
            direction = GetRandomDirection();
            rb.MovePosition(rb.position + direction * runSpeed * Time.deltaTime);
        }
    }

    void AttackState()
    {
        // Rota hacia el jugador durante el ataque
        Vector3 direction = (player.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
        }
    }

    void DeathState()
    {
        animator.SetTrigger("Death");
        StartCoroutine(WaitAndDestroy(5f));
    }

    private IEnumerator WaitAndDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        if (health <= 0f)
        {
            currentState = State.Death;
        }
        else
        {
            health -= damage;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("HarmaPlayer"))
        //{
        //    //collision.gameObject.GetComponent<Player>().TakeDamage(damage);
        //}
    }
}
