using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonForm : MonoBehaviour
{
    public void OpenForm(GameObject nextButton)
    {
        gameObject.SetActive(false);
        nextButton.SetActive(true);
        Application.OpenURL("https://forms.gle/ZS6qvrrzicWd4BAr8");
    }
}
