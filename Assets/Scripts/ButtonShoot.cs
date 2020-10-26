using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonShoot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayerController playerController;

    public void OnPointerDown(PointerEventData eventData)
    {
        playerController.IsShooting = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        playerController.IsShooting = false;
    }
}