using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private QuizManager quizManager; //Gets a quizManager instance
    [SerializeField] private Text questionText, scoreText, timerText; //All the necassary text feilds
    [SerializeField] private List<Image> lifeImageList;
    [SerializeField] private GameObject gameOverPanel, mainMenuPanel, gameMenuPanel, customizeMenuPanel; //all the diffrent game panels
    [SerializeField] private Image questionImage;
    [SerializeField] private List<Button> options, uiButtons; //All the diffrent buttons
    [SerializeField] private Color correct, wrong, regular; //Diffrent colours

    private Question question;
    private bool answered;
    public Text ScoreText { get { return scoreText; } }
    public Text TimerText { get { return timerText; } }
    public GameObject GameOverPanel { get { return gameOverPanel; } }

    private void Awake() //Adding listeners to the buttons
    {
       
        for(int i = 0; i < options.Count; i++) 
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }

        for (int i = 0; i < uiButtons.Count; i++)
        {
            Button localBtn = uiButtons[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }
    }

    public void SetQuestion(Question question) //Sets the current question
    {
        this.question = question;

        switch(question.questionType)
        {
            case QuestionType.TEXT: //Test question
                questionImage.transform.parent.gameObject.SetActive(false);
                break;
            case QuestionType.IMAGE: //Image question type (Jordan picture is an example)
                ImageHolder();
                questionImage.transform.gameObject.SetActive(true);
                questionImage.sprite = question.questionImage;
                break;
        }

        questionText.text = question.questionInfo;
        List<string> answerList = ShuffleList.ShuffleListItems<string>(question.options);

        for(int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<Text>().text = answerList[i];
            options[i].name = answerList[i];
            options[i].image.color = regular;
        }

        answered = false;
    }

    void ImageHolder()
    {
        questionImage.transform.parent.gameObject.SetActive(true);
        questionImage.transform.gameObject.SetActive(false);
    }

    private void OnClick(Button btn) //Should Change the button colour on click
    {
        if(quizManager.GameStatus == GameStatus.Playing)
        {
            if (!answered)
            {
                answered = true;
                bool val = quizManager.Answer(btn.name);

                if (val)
                {
                    btn.image.color = correct;
                }
                else
                {
                    btn.image.color = wrong;
                }
            }
        }

        switch(btn.name) //Button names
        {
            case "Start": //Starts the game
                quizManager.StartGame(0);
                mainMenuPanel.SetActive(false);
                gameMenuPanel.SetActive(true);
                break;
            case "Customize":  //Starts the customization window
                customizeMenuPanel.SetActive(true);
                mainMenuPanel.SetActive(false);
                gameMenuPanel.SetActive(false);
                break;
            case "Start2": //Starts the game from the customization window
                quizManager.StartGame(0);
                mainMenuPanel.SetActive(false);
                customizeMenuPanel.SetActive(false);
                gameMenuPanel.SetActive(true);
                break;
            case "30s":  //gives person 30 seconds on the clock
                quizManager.setTimer(30f);
                quizManager.StartGame(0);
                mainMenuPanel.SetActive(false);
                customizeMenuPanel.SetActive(false);
                gameMenuPanel.SetActive(true);
                gameOverPanel.SetActive(false);
                break;
            case "40s":  //Gives person 40 seconds on the clock
                quizManager.setTimeLimit(40);
                quizManager.StartGame(0);
                mainMenuPanel.SetActive(false);
                customizeMenuPanel.SetActive(false);
                gameMenuPanel.SetActive(true);
                gameOverPanel.SetActive(false);
                break;
            case "50s":  //Gives person 50 seconds on the clock
                quizManager.setTimeLimit(50);
                quizManager.StartGame(0);
                mainMenuPanel.SetActive(false);
                customizeMenuPanel.SetActive(false);
                gameMenuPanel.SetActive(true);
                gameOverPanel.SetActive(false);
                break;
        }
  
    }

    public void RetryButton() //Controls the retry button
    {
        SceneManager.LoadScene("Scene2");
        
    }

    public void ReduceLife(int index) //Changes the life box colour 
    {
        lifeImageList[index].color = wrong;
    }
}
