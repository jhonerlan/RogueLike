using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosArm : MonoBehaviour
{
    [Header("BosArma References")]
    public BoxCollider armCollider;
    void Start()
    {
        DeactivateCollider();
    }

    public void ActivateCollider()
    {
        armCollider.enabled = true;
    }

    public void DeactivateCollider()
    {
        armCollider.enabled = false;
    }
}
