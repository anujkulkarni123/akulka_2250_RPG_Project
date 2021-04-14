using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    public Dialogue dialogue;

    void Start()
    {
       FindObjectOfType<DialogueManager2>().StartDialogue(dialogue);  
        
    }

}
