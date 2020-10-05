using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMoveLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public CharacterController characterController;

    public void OnPointerDown(PointerEventData eventData)
    {
        characterController.IsMovingLeft = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        characterController.IsMovingLeft = false;
    }
}