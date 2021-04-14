using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Toronto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Delay", 3);
    }

    void Delay()
    {
        SceneManager.LoadScene("Scene1");
    }


}
