using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQuestShow : MonoBehaviour
{
    public GameObject QuestWindow;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            QuestWindow.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
