using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultRow : MonoBehaviour
{
    [SerializeField] private Text questionText;
    [SerializeField] private Text scoreText;

    public void Create(string question, int score)
    {
        questionText.text = question;
        scoreText.text = score + " pts";
    }
}
