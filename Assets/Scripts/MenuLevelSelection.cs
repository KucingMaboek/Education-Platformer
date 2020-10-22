using System;
using UnityEngine;

public class MenuLevelSelection : UIController
{
    private int chapter;
    public RectTransform stageContainer;
    public GameObject backgroundPanel;

    public void SelectChapter(int chapter)
    {
        this.chapter = chapter;
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
        String loadLevel = "Chapter_" + chapter + "Stage" + stage;
        SceneLoader(loadLevel);
    }
}