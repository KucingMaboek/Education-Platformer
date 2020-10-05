using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMoveRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public CharacterController characterController;

    public void OnPointerDown(PointerEventData eventData)
    {
        characterController.IsMovingRight = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        characterController.IsMovingRight = false;
    }
}