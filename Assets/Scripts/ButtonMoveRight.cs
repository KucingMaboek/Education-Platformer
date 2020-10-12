using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMoveRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayerController playerController;

    public void OnPointerDown(PointerEventData eventData)
    {
        playerController.IsMovingRight = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        playerController.IsMovingRight = false;
    }
}