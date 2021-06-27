using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuLevelSelection : UIController
{
    private int chapter;
    [SerializeField] private RectTransform stageContainer;
    [SerializeField] private GameObject backgroundPanel;
    [SerializeField] private GameObject[] chapterButtons;
    [SerializeField] private Button[] stageButtons;
    [SerializeField] private Text[] stageStarTexts;

    private void Start()
    {
        for (int i = 1; i <= chapterButtons.Length; i++)
        {
            int chapterStatus = GameManager.Instance.data.GetChapterStatus(i);
            if (chapterStatus == 0)
            {
                chapterButtons[i-1].GetComponent<Button>().interactable = false;
                chapterButtons[i-1].transform.GetChild(0).gameObject.SetActive(true);
            } 
            else
            {
                chapterButtons[i - 1].GetComponent<Button>().interactable = true;
            }
        }
    }

    public void SelectChapter(int chapter)
    {
        this.chapter = chapter;
        for (int i = 1; i <= stageButtons.Length; i++)
        {
            int stageStatus = GameManager.Instance.data.GetStageStatus(this.chapter, i);
            if (stageStatus == 0)
            {
                stageButtons[i-1].interactable = false;
            }
            else
            {
                stageButtons[i - 1].interactable = true;
                stageButtons[i - 1].transform.GetChild(0).gameObject.SetActive(false);
            }

            int starCount = GameManager.Instance.data.GetStageQuestStatus(this.chapter, i);
            stageStarTexts[i - 1].text = starCount.ToString();
        }
        backgroundPanel.SetActive(true);
        StartCoroutine(AnimationWideOut(stageContainer, 0.15f));
    }

    public void UnselectChapter()
    {
        chapter = 0;
        backgroundPanel.SetActive(false);
        StartCoroutine(AnimationWideIn(stageContainer, 0.15f));
    }

    public void SelectStage(int stage)
    {
        String loadLevel = "Chapter_" + chapter + "_Stage_" + stage;
        SceneLoader(loadLevel);
    }
}