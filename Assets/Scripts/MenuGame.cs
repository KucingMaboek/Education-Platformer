using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuGame : UIController
{
    [SerializeField] public GameObject SFXButton, MusicButton, SFXButtonDis, MusicButtonDis, PauseWindow, StarCounter, HelpWIndow, TutorialWindow;
    public RectTransform leaveWindow;
    public int nextChapter;
    public int nextStage;

    [HideInInspector] public int currentChapter;
    [HideInInspector] public int currentStage;

    public GameObject BGPanel;
    private bool SFX = true;
    private bool Music = true;
    public int questionLeft = 2;
    public int currentStar = 0;

    private bool pausePC = false;
    private bool helpPC = false;

    public void Start()
    {
        //print("P" + PlayerPrefs.GetInt("Tutorial"));
        //if (PlayerPrefs.GetInt("Tutorial") != 1)
        //{
        //    TutorialWindow.SetActive(true);
        //}
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

        if (nextStage == 1)
        {
            currentChapter = nextChapter - 1;
            currentStage = 5;
        }
        else
        {
            currentChapter = nextChapter;
            currentStage = nextStage - 1;
        }
        if (currentChapter == 1)
        {
            GameManager.Instance.PlayBgm("rainy_theme");
        }
        else if (currentChapter == 2)
        {
            GameManager.Instance.PlayBgm("summer_theme");
        }
    }

    public void Update()
    {
        CheckPausePC();
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

    public void ButtonRestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ButtonPause()
    {
        Time.timeScale = 0f;
        //PauseWindow.SetActive(true);
        BGPanel.SetActive(true);
        StartCoroutine(AnimationWideOut((PauseWindow.GetComponent<RectTransform>()), 0.15f));
    }

    public void CheckPausePC()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.PlaySfx("button_pop");
            if (pausePC == false)
            {
                Time.timeScale = 0f;
                PauseWindow.SetActive(true);
                BGPanel.SetActive(true);
                pausePC = true;
            }
            else
            {
                Time.timeScale = 1f;
                PauseWindow.SetActive(false);
                BGPanel.SetActive(false);
                pausePC = false;
                helpPC = false;
                HelpWIndow.SetActive(false);
            }
        }
        
    }

    public void ButtonPauseClose()
    {
        pausePC = false;
        Time.timeScale = 1f;
        //PauseWindow.SetActive(false);
        StartCoroutine(AnimationWideIn((PauseWindow.GetComponent<RectTransform>()), 0.15f));
        BGPanel.SetActive(false);
        helpPC = false;
        HelpWIndow.SetActive(false);
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void NextStage()
    {
        string sceneName = "Chapter_" + nextChapter + "_Stage_" + nextStage;
        GameManager.Instance.NewScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    public void ButtonHelp()
    {
        GameManager.Instance.PlaySfx("button_pop");
        if (helpPC)
        {
            helpPC = false;
            HelpWIndow.SetActive(false);
        }
        else
        {
            helpPC = true;
            HelpWIndow.SetActive(true);
        }
    }

    public void CloseTutorial()
    {
        TutorialWindow.SetActive(false);
        PlayerPrefs.SetInt("Tutorial", 1);
    }

    public void CloseConfirmLeave()
    {
        //BGPanel.SetActive(false);
        StartCoroutine(AnimationWideIn(leaveWindow, 0.15f));
    }

    public void OpenConfirmWindow()
    {
        //BGPanel.SetActive(true);
        StartCoroutine(AnimationWideOut(leaveWindow, 0.15f));
    }
}
