using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image barraDeVida;  // Asigna esto en el Inspector
    public float vidaActual;
    public float vidaMaxima = 100f;

    private void Start()
    {
        vidaActual = vidaMaxima * 0.4f;  // Iniciar la vida al 40% del máximo
        UpdateHealthBar();  // Actualizar la barra de vida al inicio
    }

    public void UpdateHealthBar()
    {
        if (barraDeVida != null)  // Verifica que barraDeVida esté asignada
        {
            barraDeVida.fillAmount = vidaActual / vidaMaxima;

            // Si la vida es 0, destruir el objeto
            if (vidaActual <= 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.LogError("barraDeVida no está asignada en el Inspector.");
        }
    }

    public void IncreaseHealth(float amount)
    {
        vidaActual = Mathf.Min(vidaActual + amount, vidaMaxima);
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        vidaActual -= damage;
        if (vidaActual <= 0)
        {
            gameObject.SetActive(false);  // Desactiva el objeto
            Destroy(gameObject, 2f);  // Destruye el objeto después de 2 segundos
        }
        UpdateHealthBar();
    }


}
