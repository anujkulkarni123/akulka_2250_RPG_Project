using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerVariables: MonoBehaviour
{
    public static playerVariables PV;

    public int triviaScore;
    public int shootingScore;
    public int passingScore;
    public float Speed;
    public int experiencePoints;

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

