using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gym2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Dialogue dialogue;
    public Dialogue dialogue2;

    void Start()
    {
        if (playerVariables.PV.shootingScore <= 8 && playerVariables.PV.passingScore >= 6)
        {
            FindObjectOfType<DialogueManagerGym2After>().StartDialogue(dialogue2);
        }
        else if (playerVariables.PV.shootingScore <= 8 && playerVariables.PV.shootingScore != 0)
        {
            FindObjectOfType<DialogueManagerGym2After>().StartDialogue(dialogue);
        }


    }
}