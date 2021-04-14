using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    void Update()
    {

        // Get current position
        Vector3 pos = transform.position;

        // Horizontal contraint
        if (pos.x > 3) pos.x = 3;
        if (pos.x < -5) pos.x = -5;

        // vertical contraint
        if (pos.z < -9) pos.z = -9;
        if (pos.z > -6) pos.z = -6;

        // Update position
        transform.position = pos;
    }
}
