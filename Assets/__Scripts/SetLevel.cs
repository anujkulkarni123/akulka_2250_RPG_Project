using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLevel : MonoBehaviour
{
    public void Start()
    {
        playerVariables.PV.shootingScore = 0;
        playerVariables.PV.triviaScore = 0;
        playerVariables.PV.Level = true;
    }
}
