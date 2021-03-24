using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    [SerializeField]
    private Text textQuestion;
    [SerializeField]
    private List<OptionButton> buttonsList;

    public void Create(Question question, Action<OptionButton> callback)
    {
        textQuestion.text = question.text;
        for(int i = 0; i<buttonsList.Count; i++)
        {
            buttonsList[i].Create(question.options[i], callback);
        }
    }
}
