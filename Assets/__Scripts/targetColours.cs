using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class targetColours : MonoBehaviour
{
     
    public GameObject T1; //Left target
    public GameObject T2; //Centre target
    public GameObject T3; //Right target
    public GameObject ball; //reference to the ball prefab, set in editor
    private GameObject ballClone; //Copy of the ball 
    public Vector3 startPosition; //Balls start position
    private Vector3 throwLeft = new Vector3(-40, 15, 40); //Ball thrown to left target
    private Vector3 throwCentre = new Vector3(0, 15, 40); //Ball thrown to centre target
    private Vector3 throwRight = new Vector3(40, 15, 40); //Ball thrown to right target
    private bool thrown = false; //prevents there from being two balls in play

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI passText;

    public Material[] materials; //Array of materials used for changing colours

    Renderer rend1; //Left target renderer
    Renderer rend2; //Middle target renderer
    Renderer rend3; //right target renderer

    private float nextActionTime = 2f; //How long before it starts
    public float period; //How fast the colours change
    public int finish = 10; //Ends the game after 10
    int[] targetNum = { 0, 1, 2, 1, 2, 0, 2, 0, 1, 2, 0 }; //Order the targets will change colours
    public int score = 0;

    public void Start()
    {
        playerVariables.PV.passingScore = 0;
        finish = 10;
        score = 0;
        Physics.gravity = new Vector3(0, -20, 0);

        rend1 = T1.GetComponent<Renderer>();
        rend2 = T2.GetComponent<Renderer>();
        rend3 = T3.GetComponent<Renderer>();

        rend1.enabled = true;
        rend2.enabled = true;
        rend3.enabled = true;

        rend1.sharedMaterial = materials[0];
        rend2.sharedMaterial = materials[0];
        rend3.sharedMaterial = materials[0];

        SetScoreText();
        PassText();
    }

    public void Update()
    {
        if (Time.timeSinceLevelLoad > nextActionTime)
        {
            nextActionTime += period;

            if (targetNum[finish] == 0 && finish > 0)
            {
                rend1.sharedMaterial = materials[1];
                Invoke("Reset", 1);
            }


            if (targetNum[finish] == 1 && finish > 0)
            {
                rend2.sharedMaterial = materials[1];
                Invoke("Reset", 1);
            }


            if (targetNum[finish] == 2 && finish > 0)
            {
                rend3.sharedMaterial = materials[1];
                Invoke("Reset", 1);
            }

            if(finish == 1)
            {
                Invoke("endGame", 2);
            }

        }  
    }

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) && !thrown) //Shoots the ball
        {
            ballClone = Instantiate(ball, startPosition, transform.rotation) as GameObject;
            ballClone.GetComponent<Rigidbody>().AddForce(throwLeft, ForceMode.Impulse);
            thrown = true;

            if (targetNum[finish] == 0)
            {
                Invoke("Delay", 1);
            }
        }
        if (Input.GetKey(KeyCode.S) && !thrown) //Shoots the ball
        {
            ballClone = Instantiate(ball, startPosition, transform.rotation) as GameObject;
            ballClone.GetComponent<Rigidbody>().AddForce(throwCentre, ForceMode.Impulse);
            thrown = true;

            if (targetNum[finish] == 1)
            {
                Invoke("Delay", 1);
            }
        }
        if (Input.GetKey(KeyCode.D) && !thrown) //Shoots the ball
        {
            ballClone = Instantiate(ball, startPosition, transform.rotation) as GameObject;
            ballClone.GetComponent<Rigidbody>().AddForce(throwRight, ForceMode.Impulse);
            thrown = true;

            if (targetNum[finish] == 2)
            {
                Invoke("Delay", 1);
            }
        }
        if (ballClone != null && ballClone.transform.position.y < .7) //Removes the ball when it hits the floor
        {
            Destroy(ballClone);
            thrown = false; 
        }
    }

    public void Reset()
    {
        rend1.sharedMaterial = materials[0];
        rend2.sharedMaterial = materials[0];
        rend3.sharedMaterial = materials[0];
        finish = finish - 1;
        PassText();
    }

    void Delay()
    {
        score++;
        playerVariables.PV.passingScore++;
        SetScoreText();
    }
    void SetScoreText() //Sets the score text
    {
        scoreText.text = "Score: " + score.ToString();
    }
    void PassText() //Display number of available balls
    {
        passText.text = "Passes: " + finish.ToString();
    }

    public void endGame()
    {
        SceneManager.LoadScene("Scene4");
    }
}
