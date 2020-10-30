using UnityEngine;

public class QuestObject : MonoBehaviour
{
    private Collider2D trigger;
    public bool IsActive { get; set; }
    public MenuGameplay GameplayUI { get; set; }

    private void Start()
    {
        trigger = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameplayUI.ShowQuestSelection();
        trigger.enabled = IsActive = false;
    }
}