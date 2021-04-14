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
    public bool Jersey1 = false;
    public bool Jersey2 = false;
    public bool DRose = false;
    public bool Level = false;
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

