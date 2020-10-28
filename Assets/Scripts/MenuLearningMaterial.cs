using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuLearningMaterial : UIController
{
    [SerializeField] private Material[] materials;
    [SerializeField] private Text pageText;
    [SerializeField] private Button prevButton, nextButton;
    [SerializeField] private Text titleText;
    private int currentPage;
    private void Start()
    {
        RefreshPage(); 
    }

    public void NextPage()
    {
        if (currentPage < materials.Length)
        {
            currentPage++;
        }
        RefreshPage();
    }

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
        }
        RefreshPage();
    }

    private void RefreshPage()
    {
        // Contents & Title
        for (int i = 0; i < materials.Length; i++)
        {
            if (i == currentPage)
            {
                titleText.text = materials[i].title;
                materials[i].content.SetActive(true);
            }
            else
            {
                materials[i].content.SetActive(false);
            }
        }

        // Page Text
        pageText.text = (currentPage + 1) + "/" + (materials.Length);
        
        // Next & Prev Button
        if (materials.Length > 1)
        {
            if (currentPage == 0)
            {
                prevButton.interactable = false;
                nextButton.interactable = true;
            }
            else if (currentPage == materials.Length-1)
            {
                prevButton.interactable = true;
                nextButton.interactable = false;
            }
            else
            {
                prevButton.interactable = true;
                nextButton.interactable = true;
            }
        }
        else
        {
            prevButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(false);
        }
    }

    [Serializable]
    public class Material
    {
        public string title;
        public GameObject content;
    }
}