using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string NewScene { get; set; }

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
}