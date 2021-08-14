using UnityEngine;
using UnityEngine.UI;

public class QuestWindow : UIController
{
    public GameObject QuestWindows, QuestContainer, WrongAnswer, RightAnswer, FeedbackWindow, CompleteWindow, BGPanelNonInter, ButtonFeedback, ButtonSoal, TextFeedback, TextSoal, WindowAnimasi;
    public GameObject[] nextFeedback;
    private int counter = 0;
    private bool answer = true;
    private bool showAnimasi = true;
    private bool showSoal = true;
    public MenuGame menuGame;
    public string TextUI;

    public void ButtonCloseQuestWindow()
    {
        RightAnswer.SetActive(false);
        WrongAnswer.SetActive(false);
        if (answer)
        {
            FeedbackWindow.SetActive(false);
            QuestWindows.SetActive(false);
            if (menuGame.questionLeft <= 0)
            {
                StageComplete();
            }
            else
            {
                menuGame.Unpause();
            }
        }
        else
        {            
            FeedbackWindow.SetActive(true);
            var VideoPlayer = WindowAnimasi.GetComponentInChildren<UnityEngine.Video.VideoPlayer>();
            VideoPlayer.Play();
            answer = true;
        }
    }

    public void ButtonRightAnswer()
    {
        QuestContainer.SetActive(false);
        RightAnswer.SetActive(true);
        answer = false;
        GameManager.Instance.PlaySfx("button_right_answer");
        --menuGame.questionLeft;
        ++menuGame.currentStar;
        menuGame.StarCounter.GetComponent<Text>().text = menuGame.currentStar.ToString();
    }

    public void ButtonWrongAnswer()
    {
        QuestContainer.SetActive(false);
        WrongAnswer.SetActive(true);
        GameManager.Instance.PlaySfx("button_wrong_answer");
        answer = false;
        --menuGame.questionLeft;
    }

    public void StageComplete()
    {
        CompleteWindow.SetActive(true);
        BGPanelNonInter.SetActive(true);
        GameManager.Instance.data.SetStageStatus(menuGame.nextChapter, menuGame.nextStage, 1);
        GameManager.Instance.data.SetChapterStatus(menuGame.nextChapter, 1);
        if (GameManager.Instance.data.GetStageQuestStatus(menuGame.currentChapter, menuGame.currentStage) < menuGame.currentStar)
        {
            GameManager.Instance.data.SetStageQuestStatus(menuGame.currentChapter, menuGame.currentStage, menuGame.currentStar);
        }
    }

    public void ButtonNextFeedback()
    {
        if (counter != nextFeedback.Length - 1)
        {
            nextFeedback[counter].SetActive(false);
            ++counter;
            nextFeedback[counter].SetActive(true);
        }
        
    }

    public void ButtonPrevFeedback()
    {
        if (counter != 0)
        {
            nextFeedback[counter].SetActive(false);
            --counter;
            nextFeedback[counter].SetActive(true);
        }

    }

    public void ButtonLihatSoal()
    {
        if (showSoal)
        {
            TextFeedback.SetActive(false);
            WindowAnimasi.SetActive(false);
            ButtonSoal.SetActive(false);
            TextSoal.SetActive(true);
            ButtonFeedback.SetActive(true);
            showSoal = false;
        }
        else
        {
            WindowAnimasi.SetActive(true);
            TextFeedback.SetActive(true);
            var VideoPlayer = WindowAnimasi.GetComponentInChildren<UnityEngine.Video.VideoPlayer>();
            VideoPlayer.Play();
            ButtonSoal.SetActive(true);
            ButtonFeedback.SetActive(false);
            TextSoal.SetActive(false);
            showSoal = true;
        }
    }
}
