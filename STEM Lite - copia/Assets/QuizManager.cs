using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GoPanel;

    public Text QuestionTxt;
    public Text ScoreTxt;
    public Text[] FinalScore;

    int totalQuestions = 0;
    public int score;
    public int[] InvidualScore;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            totalQuestions = QnA.Count;
            GoPanel.SetActive(false);
            generateQuestion();
        }
    }

    public void retry()
    {
        SceneManager.LoadScene(0);
    }
    public void gotoscene(int i)
    {
        SceneManager.LoadScene(i);
    }

    void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/ " + totalQuestions *20;
        for (int i = 0; i < 5; i++)
        {
            FinalScore[i].text = InvidualScore[i].ToString();
        }
    }

    public int index = 0;


    public void correct()
    {
        score += 1* 20;
        InvidualScore[index] = 20;
        index++;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
       
    }

    public void wrong()
    {
        InvidualScore[index] = 0;
        index++;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
        
    }


    void SetAnswers()
    {
        for (int i = 0; i <options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
           
            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
             Debug.Log("Out of Questions");
            GameOver();
        }

    }
}
