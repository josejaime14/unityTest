using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioClip correctSound;
    [SerializeField] private AudioClip incorrectSound;
    [SerializeField] private Color correctColor;
    [SerializeField] private Color incorrectColor;
    [SerializeField][Range (0,5)] private float waitTime = 0.0f;

    [Header("Componentes de la interfaz")]
    [SerializeField] private AreasDB areasDB;
    [SerializeField] private MenuUI menuUI;
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private GameObject scoreUI;
    [SerializeField] private TableResults tableResults;
    

    private QuizDB quizDB;
    private AudioSource audioSource;
    

    private int score;
    private int count;
    private Question questionTemp;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        score = 0;
        count = 0;

        SelectionArea();
    }

    private void SelectionArea()
    {
        for(int i = 0; i<areasDB.areasList.Count; i++)
        {
            menuUI.Create(areasDB.areasList[i], i, GiveArea);
        }
    }

    private void GiveArea(AreaOptionButton areaOption)
    {
        quizDB = areaOption.AreaOption.database;
        
        menuUI.gameObject.SetActive(false);
        quizUI.gameObject.SetActive(true);

        NextQuestion();
    }

    private void NextQuestion()
    {
        questionTemp = quizDB.GetQuestionRandom();
        quizUI.Create(questionTemp, GiveAnswer);
    }

    private void GiveAnswer(OptionButton optionButton)
    {
        StartCoroutine(GiveAnswerRotine(optionButton));
    }

    private void GameOver()
    {
        StopAllCoroutines();

        quizUI.gameObject.SetActive(false);
        scoreUI.SetActive(true);
        tableResults.CreateTable(score);
    }

    public void RestGame()
    {
        SceneManager.LoadScene(0);
    }

    private IEnumerator GiveAnswerRotine(OptionButton optionButton)
    {
        if (audioSource.isPlaying)
            audioSource.Stop();

        audioSource.clip = optionButton.Option.isCorrect ? correctSound : incorrectSound;
        audioSource.Play();

        optionButton.SetColor(optionButton.Option.isCorrect ? correctColor : incorrectColor);

        yield return new WaitForSeconds(waitTime);

        if (optionButton.Option.isCorrect)
        {
            score += 20;
            tableResults.resultValues.Add(count, new ResultValue(questionTemp.text, 20));
        }
        else 
        {
            tableResults.resultValues.Add(count, new ResultValue(questionTemp.text, 0));
        }

        count++;
        try
        {
            NextQuestion();
        }
        catch { }
        

    }
}
