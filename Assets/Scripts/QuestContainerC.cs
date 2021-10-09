using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestContainerC : MonoBehaviour
{
    public GameObject[] QuestPages;
    public Button prevButton, nextButton;
    [SerializeField] private int counter = 0;

    private void Start()
    {
        if (counter == 0)
        {
            prevButton.interactable = false;
        }
    }

    public void ButtonNextQuest()
    {
        if (counter != QuestPages.Length - 1)
        {
            prevButton.interactable = true;
            QuestPages[counter].SetActive(false);
            ++counter;
            QuestPages[counter].SetActive(true);
        }
        if (counter == QuestPages.Length - 1)
        {
            nextButton.interactable = false;
        }

    }

    public void ButtonPrevQuest()
    {
        if (counter != 0)
        {
            nextButton.interactable = true;
            QuestPages[counter].SetActive(false);
            --counter;
            QuestPages[counter].SetActive(true);
        }
        if (counter == 0)
        {
            prevButton.interactable = false;
        }

    }
}
