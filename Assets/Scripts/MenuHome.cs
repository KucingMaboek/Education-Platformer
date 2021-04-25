using UnityEngine;
using UnityEngine.UI;

public class MenuHome : UIController
{
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private RectTransform settingContainer;
    [SerializeField] private RectTransform creditContainer;
    [SerializeField] private GameObject backgroundPanel;

    private void Start()
    {
        InitiateGame();
    }

    private void InitiateGame()
    {
        int chapterStatus = GameManager.Instance.data.GetChapterStatus(1);
        if (chapterStatus == 0)
        {
            // level Init
            GameManager.Instance.data.SetChapterStatus(1, 1);
            GameManager.Instance.data.SetStageStatus(1, 1, 1);

            // Audio Init
            GameManager.Instance.setting.SfxVolume = 1f;
            GameManager.Instance.setting.BgmVolume = 1f;
        }

        // UI Init
        sfxSlider.value = GameManager.Instance.setting.SfxVolume;
        bgmSlider.value = GameManager.Instance.setting.BgmVolume;
    }

    public void OpenSetting()
    {
        backgroundPanel.SetActive(true);
        StartCoroutine(AnimationWideOut(settingContainer, 0.15f));
    }

    public void CloseSetting()
    {
        backgroundPanel.SetActive(false);
        StartCoroutine(AnimationWideIn(settingContainer, 0.15f));
    }

    public void OpenCredit()
    {
        backgroundPanel.SetActive(true);
        StartCoroutine(AnimationWideOut(creditContainer, 0.15f));
    }

    public void CloseCredit()
    {
        backgroundPanel.SetActive(false);
        StartCoroutine(AnimationWideIn(creditContainer, 0.15f));
    }

    public void SetSfxVolume()
    {
        GameManager.Instance.setting.SfxVolume *= -1;
    }

    public void SetBgmVolume()
    {
        GameManager.Instance.setting.BgmVolume *= -1;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}