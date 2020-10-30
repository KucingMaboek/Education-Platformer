using UnityEngine;
using UnityEngine.UI;

public class MenuHome : UIController
{
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private RectTransform settingContainer;
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

            // Setting Init
            GameManager.Instance.setting.SfxVolume = 1f;
            GameManager.Instance.setting.BgmVolume = 1f;
            GameManager.Instance.setting.Vibration = 1;
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