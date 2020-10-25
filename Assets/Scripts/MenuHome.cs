using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuHome : UIController
{
    [SerializeField] private Text sfxVolumeText;
    [SerializeField] private Text bgmVolumeText;
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
            
            // Audio Init
            GameManager.Instance.setting.SfxVolume = 1f;
            GameManager.Instance.setting.BgmVolume = 1f;
        }
        
        // UI Init
        sfxSlider.value = GameManager.Instance.setting.SfxVolume;
        sfxVolumeText.text = Convert.ToInt32(GameManager.Instance.setting.SfxVolume * 100f) + "%";
        bgmSlider.value = GameManager.Instance.setting.BgmVolume;
        bgmVolumeText.text = Convert.ToInt32(GameManager.Instance.setting.BgmVolume * 100f) + "%";
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
        sfxVolumeText.text = Convert.ToInt32(GameManager.Instance.setting.SfxVolume * 100f) + "%";
    }
    
    public void SetBgmVolume()
    {
        GameManager.Instance.setting.BgmVolume = bgmSlider.value;
        bgmVolumeText.text = Convert.ToInt32(GameManager.Instance.setting.BgmVolume * 100f) + "%";
    }
}