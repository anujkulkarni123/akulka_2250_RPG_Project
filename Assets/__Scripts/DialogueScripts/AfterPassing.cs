using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterPassing : MonoBehaviour
{
    // Start is called before the first frame update
    public Dialogue dialogue;
    public Dialogue dialogue2;

    void Start()
    {
        if (playerVariables.PV.passingScore >= 6)
        {
            FindObjectOfType<DialogueManagerAfterPassing>().StartDialogue(dialogue);
        }
        else if (playerVariables.PV.passingScore <= 6 && playerVariables.PV.passingScore != 0)
        {
            FindObjectOfType<DialogueManagerAfterPassing>().StartDialogue(dialogue2);
        }

    }
}
