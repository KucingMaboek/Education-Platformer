using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public IEnumerator AnimationSnapOut(RectTransform container, float duration)
    {
        container.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0);
        container.DOScale(new Vector3(1f, 1f, 1f), duration).SetUpdate(true);
        container.DOAnchorPosY(0f, duration).SetUpdate(true);
    }
    
    public IEnumerator AnimationSnapIn(RectTransform container, float duration)
    {
        container.DOScale(new Vector3(0.7f, 0.7f, 0.7f), duration).SetUpdate(true);
        container.DOAnchorPosY(-200, duration).SetUpdate(true);
        yield return new WaitForSecondsRealtime(duration);
        container.gameObject.SetActive(false);
    }
    
    public void SceneLoader(string sceneName)
    {
        GameManager.Instance.NewScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }
}
