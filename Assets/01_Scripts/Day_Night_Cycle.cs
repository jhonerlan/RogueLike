using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_Night_Cycle : MonoBehaviour
{
    public int rotationScale = 20;
    void Update()
    {
        transform.Rotate(rotationScale * Time.deltaTime, 0, 0);
    }
}
