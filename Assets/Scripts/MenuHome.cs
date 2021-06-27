using UnityEngine;
using UnityEngine.UI;

public class MenuHome : UIController
{
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private RectTransform settingContainer;
    [SerializeField] private RectTransform creditContainer;
    [SerializeField] private GameObject backgroundPanel, SFXButton, MusicButton, SFXButtonDis, MusicButtonDis;

    private bool SFX = true;
    private bool Music = true;

    private void Start()
    {
        GameManager.Instance.PlayBgm("menu_theme");
        InitiateGame();
        /*for (int i = 0; i < 20; i++)
        {
            Debug.Log(GameManager.Instance.data.GetChapterStatus(i));
        }*/
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
        if (GameManager.Instance.setting.BgmVolume == 0)
        {
            MusicButton.SetActive(false);
            MusicButtonDis.SetActive(true);
            Music = false;
        }

        if (GameManager.Instance.setting.SfxVolume == 0)
        {
            SFXButton.SetActive(false);
            SFXButtonDis.SetActive(true);
            SFX = false;
        }
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
        if (GameManager.Instance.setting.SfxVolume == 0)
        {
            GameManager.Instance.setting.SfxVolume = 1;
        }
        else
        {
            GameManager.Instance.setting.SfxVolume = 0;
        }
    }

    public void SetBgmVolume()
    {
        if (GameManager.Instance.setting.BgmVolume == 0)
        {
            GameManager.Instance.setting.BgmVolume = 1;
        }
        else
        {
            GameManager.Instance.setting.BgmVolume = 0;
        }
    }

    public void SwapSFXButton()
    {
        if (SFX)
        {
            SFXButton.SetActive(false);
            SFXButtonDis.SetActive(true);
            SFX = false;
        }
        else
        {
            SFXButton.SetActive(true);
            SFXButtonDis.SetActive(false);
            SFX = true;
        }
    }

    public void SwapMusicButton()
    {
        if (Music)
        {
            MusicButton.SetActive(false);
            MusicButtonDis.SetActive(true);
            Music = false;
        }
        else
        {
            MusicButton.SetActive(true);
            MusicButtonDis.SetActive(false);
            Music = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        //ResetData();
        //Debug.Log("Quit");
    }

    public void ResetData()
    {
        GameManager.Instance.data.SetChapterStatus(1, 0);
        GameManager.Instance.data.SetChapterStatus(2, 0);
        for (int i = 1; i < 6; i++)
        {
            GameManager.Instance.data.SetStageStatus(1, i, 0);
            GameManager.Instance.data.SetStageQuestStatus(1, i, 0);
        }
        for (int i = 1; i < 6; i++)
        {
            GameManager.Instance.data.SetStageStatus(2, i, 0);
            GameManager.Instance.data.SetStageQuestStatus(2, i, 0);
        }
    }
}