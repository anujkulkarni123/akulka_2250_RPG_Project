using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionsData", menuName = "QuestionsData", order = 1)]

public class QuizData : ScriptableObject
{
    public List<Question> questions;
}

//Created to hold all the questions for the trivia game. Stored in the resources folder.
