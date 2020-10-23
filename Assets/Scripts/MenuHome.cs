using System;

public class MenuHome : UIController
{
    private void Start()
    {
        InitiateGame();
    }

    private void InitiateGame()
    {
        int chapterStatus = GameManager.Instance.data.GetChapterStatus(0);
        if (chapterStatus == 0)
        {
            GameManager.Instance.data.SetChapterStatus(1, 1);
            GameManager.Instance.data.SetStageStatus(1,1,1);
        }
    }
}