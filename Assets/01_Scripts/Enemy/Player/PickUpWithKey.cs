using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWithKey : MonoBehaviour
{
    public GameObject sword;  // La espada en la escena
    public Transform handAnchor;  // El punto donde la espada se anclará en la esfera

    private bool isNearSword = false;  // Variable para saber si estamos cerca de la espada

    private void Update()
    {
        // Si estamos cerca de la espada y se presiona la tecla P
        if (isNearSword && Input.GetKeyDown(KeyCode.P))
        {
            PickUpSword();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == sword)
        {
            Debug.Log("Cerca de la espada");
            isNearSword = true;  // Estamos cerca de la espada
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == sword)
        {
            Debug.Log("Lejos de la espada");
            isNearSword = false;  // Nos alejamos de la espada
        }
    }

    private void PickUpSword()
    {
        Debug.Log("Espada recogida");

        // Desactivar la física de la espada (si tiene un Rigidbody)
        Rigidbody rb = sword.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        // Mover la espada al HandAnchor y hacerla hija de la esfera
        sword.transform.position = handAnchor.position;
        sword.transform.rotation = handAnchor.rotation;
        sword.transform.SetParent(handAnchor);

        // Opcional: Desactivar colisiones futuras con la espada
        Collider swordCollider = sword.GetComponent<Collider>();
        if (swordCollider != null)
        {
            swordCollider.enabled = false;
        }

        isNearSword = false;  // Ya no estamos cerca de la espada porque la hemos recogido
    }
}