using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuLevelSelection : UIController
{
    private int chapter;
    [SerializeField] private RectTransform stageContainer;
    [SerializeField] private GameObject backgroundPanel;
    [SerializeField] private GameObject[] chapterButtons;
    [SerializeField] private GameObject[] stageButtons;

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
        }
    }

    public void SelectChapter(int chapter)
    {
        this.chapter = chapter;
        for (int i = 1; i <= stageButtons.Length; i++)
        {
            int stageStatus = GameManager.Instance.data.GetStageStatus(chapter,i);
            if (stageStatus == 0)
            {
                stageButtons[i-1].GetComponent<Button>().interactable = false;
                stageButtons[i-1].transform.GetChild(0).gameObject.SetActive(true);
            }
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