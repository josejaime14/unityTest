using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableResults : MonoBehaviour
{
    [SerializeField] private Text totalScore = null;
    [SerializeField] private List<ResultRow> results = null;
    
    public Dictionary<int, ResultValue> resultValues = new Dictionary<int, ResultValue>();

    public void CreateTable(int score)
    {
        totalScore.text = score + " pts";

        foreach(KeyValuePair<int,ResultValue> item in resultValues)
        {
            results[item.Key].Create(item.Value.Question, item.Value.Score);
        }
    }
    
}
