using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public GameObject NPC;
    public bool right = true;
    public float speed;

    private void FixedUpdate() //Moves "Phil Jackson" diagonally across the scene
    {
        if (NPC.transform.position.x < 3f && right)
        {
            NPC.transform.position += new Vector3(speed, 0, 0);
        }
        if (NPC.transform.position.x >= 3f)
        {
            right = false;
        }
        if (right == false)
        {
            NPC.transform.position -= new Vector3(speed, 0, 0);
        }
        if (NPC.transform.position.x <= -3f)
        {
            right = true;
        }
    }
}
