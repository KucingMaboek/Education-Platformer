using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool IsGrounded;

    private void OnTriggerStay2D(Collider2D collider)
    {
        IsGrounded = collider != null;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsGrounded = false;
    }
}