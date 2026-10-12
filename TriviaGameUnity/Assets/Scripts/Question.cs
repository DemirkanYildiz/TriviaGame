using System;

[System.Serializable]
public class Question
{
    public string category;
    public string question;
    public string[] choices;
    public string answer;
}

[System.Serializable]
public class QuestionData
{
    public Question[] questions;
}
