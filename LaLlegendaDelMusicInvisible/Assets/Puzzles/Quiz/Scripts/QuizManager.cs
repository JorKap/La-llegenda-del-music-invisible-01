using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private QuizDataScriptableObject quiz;

    public Queue<Question> questions = new Queue<Question>();

    private Question selectedQuestion;



    public void StartQuiz()
    {
        foreach (Question question in quiz.questions)
        {
            questions.Enqueue(question);
        }

        SelectedQuestion();
    }

    void SelectedQuestion()
    {
        
        if(questions.Count> 0)
        {
            selectedQuestion = questions.Dequeue();
            quizUI.SetQuestion(selectedQuestion);
        }
        
    }

    public bool Answer(string answered)
    {
        bool correctAns = false;
        if(answered == selectedQuestion.correctAns)
        {
            correctAns = true;
        }
        else
        {

        }

        Invoke("SelectedQuestion", 0.6f);

        return correctAns;
    }
}
[System.Serializable]
public class Question
{
    public string questionInfo;
    public QuestionType questionType;
    public Sprite questionImg;
    public AudioClip questionClip;
    public UnityEngine.Video.VideoClip questionVideo;
    public List<string> options;
    public string correctAns;

}

[System.Serializable]
public enum QuestionType
{
    TEXT,
    IMAGE,
    VIDEO,
    AUDIO
}
