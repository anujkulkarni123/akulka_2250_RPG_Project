using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Delay", 10);
    }

    void Delay()
    {
        SceneManager.LoadScene("Main Menu");
    }


}
