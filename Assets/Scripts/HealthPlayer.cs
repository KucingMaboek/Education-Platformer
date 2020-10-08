using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public int health;
    public int numOfHeart;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;

    private void Update()
    {
        if(health > numOfHeart)
        {
            health = numOfHeart;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].sprite = emptyHearts;
            }

            if(i < numOfHeart)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

    }

}
