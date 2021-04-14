using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterTriviaScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Dialogue dialogue;
    public Dialogue dialogue2;

    void Start()
    {
        if (playerVariables.PV.triviaScore >= 4)
        {
            FindObjectOfType<DialogueManagerAfterTrivia>().StartDialogue(dialogue);
        }
        else if(playerVariables.PV.triviaScore <= 4 && playerVariables.PV.triviaScore != 0)
        {
            FindObjectOfType<DialogueManagerAfterTrivia>().StartDialogue(dialogue2);
        }

    }
}