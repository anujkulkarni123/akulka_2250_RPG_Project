using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private List<QuizData> quizData;
    [SerializeField] private float timeLimit = 30f;


    private List<Question> questions;
    private Question selectedQuestion;
    private static int scoreCount = 0;
    private float currentTime;
    private int lifeRemaining = 3;
    private Shoot shoot;


    private GameStatus gameStatus = GameStatus.Next;

    public GameStatus GameStatus { get { return gameStatus; } }

    public static int ScoreCount{ get { return scoreCount; } }

    

    void Awake()    {
        shoot = GameObject.FindObjectOfType<Shoot>();
    }

    public void StartGame(int index) //Starts the game
    {
        playerVariables.PV.triviaScore = 0;
        scoreCount = 0;
        currentTime = timeLimit;
        lifeRemaining = 3;
        questions = new List<Question>();
        for(int i = 0; i < quizData[index].questions.Count; i++)
        {
            questions.Add(quizData[index].questions[i]);
        }

        SelectQuestion();
        gameStatus = GameStatus.Playing;
    }

    public void setTimeLimit(float time) //Sets what the time limit is gonna be
    {
        timeLimit = time;
    }

    void SelectQuestion() //Selects a random question then removes it so the player cant get it again
    {
        int val = UnityEngine.Random.Range(0, questions.Count);
        selectedQuestion = questions[val];

        quizUI.SetQuestion(selectedQuestion);

        questions.RemoveAt(val);
    }

    public void Update()
    {
        if(gameStatus == GameStatus.Playing)
        {
            currentTime -= Time.deltaTime;
            setTimer(currentTime);
        }
    }

    public void setTimer(float value) //Sets the timer value
    {
        TimeSpan time = TimeSpan.FromSeconds(value);
        quizUI.TimerText.text = "Time:" + time.ToString("mm':'ss");

        if(currentTime <= 0)
        {
            gameStatus = GameStatus.Next;
            quizUI.GameOverPanel.SetActive(true);
        }
    }

    public bool Answer(string answered)
    {
        bool correctAnswer = false;

        if(answered == selectedQuestion.correctAnswer) //Checking if the answer is correct
        {
            correctAnswer = true;
            scoreCount += 1;
            playerVariables.PV.triviaScore++;  //Adding a point to the trivia static variable
            playerVariables.PV.experiencePoints++; //Adding a point to the total points variable
            quizUI.ScoreText.text = "Score:" + scoreCount;
        }

        else
        {
            lifeRemaining--; //removes a life
            quizUI.ReduceLife(lifeRemaining);

            if(lifeRemaining <= 0) //checks if player has any lifes left
            {
                gameStatus = GameStatus.Next;
                quizUI.GameOverPanel.SetActive(true);
            }
        }

        if(gameStatus == GameStatus.Playing) //Checks if the game is still going on
        {
            if(questions.Count > 0)
            {
                Invoke("SelectQuestion", 0.4f);
            }
            else
            {
                gameStatus = GameStatus.Next;
                quizUI.GameOverPanel.SetActive(true);
            }
        }

        return correctAnswer;
    }
    
}

[System.Serializable]
public class Question //Everything you need for a question
{
    public string questionInfo;
    public List<string> options;
    public string correctAnswer;
    public Sprite questionImage;
    public QuestionType questionType;
}

[System.Serializable]
public enum QuestionType //The two question types
{
    TEXT, IMAGE
}

[System.Serializable] 
public enum GameStatus //Game status
{
    Next, Playing
}
