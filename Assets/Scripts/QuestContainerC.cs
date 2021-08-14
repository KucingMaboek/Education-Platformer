using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestContainerC : MonoBehaviour
{
    public GameObject[] QuestPages;
    [SerializeField] private int counter = 0;

    public void ButtonNextQuest()
    {
        if (counter != QuestPages.Length - 1)
        {
            QuestPages[counter].SetActive(false);
            ++counter;
            QuestPages[counter].SetActive(true);
        }

    }

    public void ButtonPrevQuest()
    {
        if (counter != 0)
        {
            QuestPages[counter].SetActive(false);
            --counter;
            QuestPages[counter].SetActive(true);
        }

    }
}
