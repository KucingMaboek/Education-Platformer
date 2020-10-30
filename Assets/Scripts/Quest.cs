using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class Quest : ScriptableObject
{
    [TextArea] public string description;
    [TextArea] public string[] answer = new string[2];
    public int correctAnswer;
    public bool isAnswered;
    public bool isCorrect;

    public void SelectAnswer(int selectedAnswer)
    {
        if (selectedAnswer == correctAnswer)
        {
            isCorrect = true;
        }
    
        isAnswered = true;
    }
}