using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetColours : MonoBehaviour
{
     
    public GameObject T1;
    public GameObject T2;
    public GameObject T3;

    public Material[] materials;

    public Renderer rend1;
    public Renderer rend2;
    public Renderer rend3;

    public void Start()
    {
        rend1 = T1.GetComponent<Renderer>();
        rend2 = T2.GetComponent<Renderer>();
        rend3 = T3.GetComponent<Renderer>();

        rend1.enabled = true;
        rend2.enabled = true;
        rend3.enabled = true;

        rend1.sharedMaterial = materials[0];
        rend2.sharedMaterial = materials[0];
        rend3.sharedMaterial = materials[0];
    }

    public void Update()
    {
        int targetNum = Random.Range(0, 3);

        if(targetNum == 0)
        {
            
        }
    }


}
