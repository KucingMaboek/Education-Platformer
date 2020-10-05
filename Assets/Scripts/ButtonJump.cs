using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonJump : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public CharacterController characterController;

    public void OnPointerDown(PointerEventData eventData)
    {
        characterController.IsJumping = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        characterController.IsJumping = false;
    }
}