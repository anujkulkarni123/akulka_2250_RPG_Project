using UnityEngine;
using System.Collections;
using TMPro;

public class Basket : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int _score;
    

    private void Start()
    {
        _score = 0;

        SetScoreText();
    }

    public int Score { get { return _score;} }

    void OnTriggerEnter() //if ball hits basket collider
    {
        _score = _score + 1;
        playerVariables.PV.shootingScore++;
        SetScoreText();
    }
    void SetScoreText() //Sets the score text
    {
        scoreText.text = "Score: " + _score.ToString();
    }
}
