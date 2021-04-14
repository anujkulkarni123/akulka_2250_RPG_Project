using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    public Animator animator;

    void Update() {
        animator.SetBool("IsOpen", true);
    }
}
