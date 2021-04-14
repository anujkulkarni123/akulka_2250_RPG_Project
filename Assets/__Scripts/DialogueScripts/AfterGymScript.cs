using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterGymScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Dialogue dialogue;
    public Dialogue dialogue2;

    void Start()
    {
        if (playerVariables.PV.shootingScore <= 6 && playerVariables.PV.triviaScore >= 6)
        { 
            FindObjectOfType<DialogueManagerAfter>().StartDialogue(dialogue2);   
        }
        else if(playerVariables.PV.shootingScore <= 6 && playerVariables.PV.shootingScore != 0)
        {
            FindObjectOfType<DialogueManagerAfter>().StartDialogue(dialogue);
        }
          

    }
}
