using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patada : MonoBehaviour
{
    [Header("Pierna References")]
    public BoxCollider pieCollider;
    void Start()
    {
        DeactivatePieCollider();
    }

    public void ActivatePieCollider()
    {
        pieCollider.enabled = true;
    }

    public void DeactivatePieCollider()
    {
        pieCollider.enabled = false;
    }
}
