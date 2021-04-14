using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerVariables: MonoBehaviour
{
    public static playerVariables PV;

    public int triviaScore;
    public int shootingScore;
    public int passingScore;
    public int experiencePoints;
    public float playerSpeed = 4;

    private void Awake()
    {
       if(PV == null)
        {
            DontDestroyOnLoad(gameObject);
            PV = this;
        }
            
       else if(PV != this)
        {
            Destroy(gameObject);
        }
    }

}

