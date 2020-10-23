using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public string NewScene { get; set; }
    public Data data = new Data();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public class Data
    {
        public int GetChapterStatus(int chapter)
        {
            return PlayerPrefs.GetInt("Chapter_" + chapter);
        }

        public void SetChapterStatus(int chapter, int status)
        {
            PlayerPrefs.SetInt("Chapter_" + chapter, status);
        }

        public int GetStageStatus(int chapter, int stage)
        {
            return PlayerPrefs.GetInt("Chapter_" + chapter + "_Stage_" + stage);
        }

        public void SetStageStatus(int chapter, int stage, int status)
        {
            PlayerPrefs.SetInt("Chapter_" + chapter + "_Stage_" + stage, status);
        }
    }
}