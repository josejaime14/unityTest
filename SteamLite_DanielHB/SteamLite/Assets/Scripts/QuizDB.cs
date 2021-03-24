using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuizDB : MonoBehaviour
{
    [SerializeField]
    private List<Question> questionsList;

    [SerializeField]
    private List<Question> questionsBackup;

    private bool isStart = true;

    private void Awake()
    {
        RestoreBackup();
    }

    public Question GetQuestionRandom(bool remove = true)
    {
        if (isStart)
        {
            RestoreBackup();
            isStart = false;
        }
            

        if (questionsBackup.Count == 0)
        {
            RestoreBackup();
            GameObject.Find("GameManager").gameObject.SendMessage("GameOver");
            return null;
        }

        int index = Random.Range(0, questionsBackup.Count);
        if (!remove)
            return questionsBackup[index];
        Question questionTemp = questionsBackup[index];
        questionsBackup.RemoveAt(index);
        
        return questionTemp;
    }

    private void RestoreBackup()
    {
        questionsBackup = questionsList.ToList();
    }
}
