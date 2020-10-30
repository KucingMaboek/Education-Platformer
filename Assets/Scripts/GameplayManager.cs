using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    // Quest
    [SerializeField] private QuestObject[] questObjects;

    // Player
    [SerializeField] private GameObject player;

    private PlayerController playerController;

    // Player Weapon
    [SerializeField] private bool isWeaponActive;
    [SerializeField] private GameObject playerWeapon;

    // Gameplay UI
    [SerializeField] private MenuGameplay menuGameplay;

    // Scene level
    private int currentChapter;
    private int currentStage;

    private void Awake()
    {
        if (isWeaponActive)
        {
            playerWeapon.SetActive(true);
        }

        for (int i = 0; i < questObjects.Length; i++)
        {
            questObjects[i].GameplayUI = menuGameplay;
        }

        // Extract Chapter and Stage level from scene name
        currentChapter = Convert.ToInt32(SceneManager.GetActiveScene().name.Split('_')[1]);
        currentStage = Convert.ToInt32(SceneManager.GetActiveScene().name.Split('_')[3]);

        // 
        playerController = player.GetComponent<PlayerController>();

        // Define what is next stage
        if (currentStage == 5)
        {
            menuGameplay.NextSceneName = "Chapter_" + (currentChapter + 1) + "_Stage_" + (currentStage + 1);
        }
        else
        {
            menuGameplay.NextSceneName = "Chapter_" + currentChapter + "_Stage_" + (currentStage + 1);
        }
    }

    private void Update()
    {
        Time.timeScale = menuGameplay.IsPaused ? 0f : 1f;
    }

    // Check Active Quest Object
    private void CheckActiveQuestObjects()
    {
        int activeQuest = 0;
        for (int i = 0; i < questObjects.Length; i++)
        {
            if (questObjects[i].IsActive)
            {
                activeQuest++;
            }
        }

        if (activeQuest == 0)
        {
            GameOver(false);
        }
    }        
    
    public void GameOver(bool isWin)
    {
        if (isWin)
        {
            if (currentStage == 5)
            {
                if (currentChapter < 3)
                {
                    GameManager.Instance.data.SetChapterStatus(currentChapter + 1, 1);
                    GameManager.Instance.data.SetStageStatus(currentChapter + 1, 1, 1);
                }
            }
            else
            {
                GameManager.Instance.data.SetStageStatus(currentChapter, currentStage + 1, 1);
            }
        }

        menuGameplay.IsGameOver = true;
    }
}