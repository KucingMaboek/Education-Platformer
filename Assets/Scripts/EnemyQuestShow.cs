using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQuestShow : UIController
{
    public GameObject QuestWindow;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            //StartCoroutine(AnimationWideOut((QuestWindow.GetComponent<RectTransform>()), 0.15f));
            QuestWindow.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
