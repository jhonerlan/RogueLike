using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    public float maxComboDelay = 1.0f; // Tiempo máximo entre inputs
    public float attackRange = 2f; // Rango de ataque
    public float lightAttackDamage = 10f; // Daño del ataque ligero
    public float heavyAttackDamage = 20f; // Daño del ataque pesado
    public float finisherAttackDamage = 50f; // Daño del ataque final crítico
    private float lastInputTime = 0f;
    private int comboStep = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastInputTime > maxComboDelay)
        {
            ResetCombo();
        }

        if (Input.GetKeyDown(KeyCode.J)) // Primer ataque básico
        {
            if (comboStep == 0)
            {
                LightAttack1();
                comboStep = 1;
                lastInputTime = Time.time;
            }
            else if (comboStep == 1)
            {
                LightAttack2();
                comboStep = 2;
                lastInputTime = Time.time;
            }
        }
        else if (Input.GetKeyDown(KeyCode.K)) // Segundo ataque básico o ataque pesado
        {
            if (comboStep == 2)
            {
                HeavyAttack();
                comboStep = 3;
                lastInputTime = Time.time;
            }
            else if (comboStep == 1)
            {
                LightAttack2();
                comboStep = 2;
                lastInputTime = Time.time;
            }
        }
        else if (Input.GetKeyDown(KeyCode.L)) // Ataque final crítico
        {
            if (comboStep == 3)
            {
                FinisherAttack();
                ResetCombo();
            }
        }
    }

    void LightAttack1()
    {
        // Lógica para el primer ataque ligero
        Debug.Log("Primer Ataque Ligero");
        DealDamage(lightAttackDamage);
    }

    void LightAttack2()
    {
        // Lógica para el segundo ataque ligero
        Debug.Log("Segundo Ataque Ligero");
        DealDamage(lightAttackDamage);
    }

    void HeavyAttack()
    {
        // Lógica para el ataque pesado
        Debug.Log("Ataque Pesado");
        DealDamage(heavyAttackDamage);
    }

    void FinisherAttack()
    {
        // Lógica para el ataque final crítico
        Debug.Log("Ataque Final Crítico");
        DealDamage(finisherAttackDamage);
    }

    void DealDamage(float damage)
    {
        // Detectar enemigos en el rango de ataque y aplicar daño
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy_1"))
            {
                Enemy enemy = hitCollider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
        }
    }

    void ResetCombo()
    {
        comboStep = 0;
    }
}
