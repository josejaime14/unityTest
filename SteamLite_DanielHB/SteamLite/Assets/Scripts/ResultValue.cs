public class ResultValue
{
    public string Question { set; get; }
    public int Score { set; get; }

    public ResultValue(string question, int score)
    {
        Question = question;
        Score = score;
    }
}
