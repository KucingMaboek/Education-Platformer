using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonJump : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayerController playerController;

    public void OnPointerDown(PointerEventData eventData)
    {
        playerController.IsJumping = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        playerController.IsJumping = false;
    }
}