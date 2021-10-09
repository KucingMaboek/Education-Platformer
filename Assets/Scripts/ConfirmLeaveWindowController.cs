using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmLeaveWindowController : UIController
{
    private RectTransform _thisRectTrans;
//    public GameObject bgPanel;

    private void Awake()
    {
        _thisRectTrans = GetComponent<RectTransform>();
    }

    public void CloseConfirmLeave()
    {
        //bgPanel.SetActive(false);
        StartCoroutine(AnimationWideIn(_thisRectTrans, 0.15f));
    }

    public void ConfirmQuit()
    {
        Application.Quit();
    }

    public void OpenConfirmWindow()
    {
        //bgPanel
        StartCoroutine(AnimationWideOut(_thisRectTrans, 0.15f));
    }
}
