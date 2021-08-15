using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMoveLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayerController playerController;

    public void OnPointerDown(PointerEventData eventData)
    {
        playerController.IsMovingLeft = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        playerController.IsMovingLeft = false;
    }
}