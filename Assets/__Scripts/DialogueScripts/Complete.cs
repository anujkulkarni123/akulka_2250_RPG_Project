using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Complete : MonoBehaviour
{
    public Dialogue dialogue;
    void Start()
    {
        FindObjectOfType<DialogueManagerComplete>().StartDialogue(dialogue);
    }

}
