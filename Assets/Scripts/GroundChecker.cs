using Cinemachine;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GetComponentInParent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (!other.CompareTag("Player"))
        // {
            _playerController.IsGrounded = true;
        // }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // if (!collision.CompareTag("Player"))
        // {
            _playerController.IsGrounded = false;
        // }
    }
}