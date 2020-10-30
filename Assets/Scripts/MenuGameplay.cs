using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGameplay : UIController
{
    [SerializeField] private RectTransform pauseContainer;
    [SerializeField] private RectTransform gameOverContainer;

    [SerializeField] private RectTransform settingContainer;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider bgmSlider;

    [SerializeField] private GameObject backgroundPanel;

    [SerializeField] private Quest[] quests;
    [SerializeField] private RectTransform questSelectionContainer;
    [SerializeField] private RectTransform questContainer;

    [SerializeField] private Text questDescriptionText;
    [SerializeField] private GameObject[] questAnswerButton;

    
    public bool IsPaused { get; set; }
    public bool IsGameOver { get; set; }
    public string NextSceneName { get; set; }

    private void Start()
    {
        sfxSlider.value = GameManager.Instance.setting.SfxVolume;
        bgmSlider.value = GameManager.Instance.setting.BgmVolume;
    }

    private void Update()
    {
        if (IsGameOver)
        {
            ShowGameOverDialogue();
            IsGameOver = false;
        }
    }

    public void PauseGame()
    {
        backgroundPanel.SetActive(true);
        IsPaused = true;
        StartCoroutine(AnimationSnapOut(pauseContainer, 0.15f));
    }

    public void ResumeGame()
    {
        StartCoroutine(AnimationSnapIn(pauseContainer, 0.15f));
        IsPaused = false;
        backgroundPanel.SetActive(false);
    }

    public void RestartGame()
    {
        IsPaused = false;
        SceneLoader(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        IsPaused = false;
        SceneLoader("HomeScene");
    }

    public void ShowGameOverDialogue()
    {
        backgroundPanel.SetActive(true);
        StartCoroutine(AnimationSnapOut(gameOverContainer, 0.15f));
    }

    public void NextStage()
    {
        IsPaused = false;
        SceneLoader(NextSceneName);
    }

    public void ShowQuestSelection()
    {
        for (int i = 0; i < quests.Length; i++)
        {
            if (quests[i].isAnswered)
            {
                questSelectionContainer.gameObject.transform.GetChild(i).GetComponent<Button>().interactable = false;
            }
        }

        backgroundPanel.SetActive(true);
        IsPaused = true;
        StartCoroutine(AnimationSnapOut(questSelectionContainer, 0.15f));
    }

    public void SelectQuest(int selected)
    {
        StartCoroutine(AnimationSnapIn(questSelectionContainer, 0.15f));
        StartCoroutine(AnimationSnapOut(questContainer, 0.15f));

        questDescriptionText.text = quests[selected].description;
        for (int i = 0; i < quests[selected].answer.Length; i++)
        {
            questAnswerButton[i].transform.GetChild(0).GetComponent<Text>().text = quests[selected].answer[i];
            
            // Add listener here
            questAnswerButton[i].GetComponent<Button>().onClick.AddListener(() => quests[selected].SelectAnswer(i));
            questAnswerButton[i].GetComponent<Button>().onClick.AddListener(() =>
            {
                backgroundPanel.SetActive(false);
                IsPaused = false;
                quests[selected].isAnswered = true;
                StartCoroutine(AnimationSnapIn(questContainer, 0.15f));
            });
        }
    }

    public void OpenSetting()
    {
        backgroundPanel.SetActive(true);
        StartCoroutine(AnimationWideOut(settingContainer, 0.15f));
    }

    public void CloseSetting()
    {
        StartCoroutine(AnimationWideIn(settingContainer, 0.15f));
    }

    public void SetSfxVolume()
    {
        GameManager.Instance.setting.SfxVolume = sfxSlider.value;
    }

    public void SetBgmVolume()
    {
        GameManager.Instance.setting.BgmVolume = bgmSlider.value;
    }

    public void SetVibration()
    {
        if (GameManager.Instance.setting.Vibration == 1)
        {
            GameManager.Instance.setting.Vibration = 0;
        }
        else
        {
            GameManager.Instance.setting.Vibration = 1;
        }
    }
}