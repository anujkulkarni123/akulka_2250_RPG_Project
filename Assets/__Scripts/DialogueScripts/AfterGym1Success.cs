using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterGym1Success : MonoBehaviour
{
    
    public Dialogue dialogue;
    
    void Start()
    {
        
        FindObjectOfType<DialogueManagerAfterSuccess>().StartDialogue(dialogue);
        
       
          
    }
}
