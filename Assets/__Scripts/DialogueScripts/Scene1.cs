using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1 : MonoBehaviour
{
    public Dialogue dialogue;
    // Start is called before the first frame update
    void Start()
    {
       FindObjectOfType<DialogueManagerScene>().StartDialogue(dialogue);
        
       
    }

}
