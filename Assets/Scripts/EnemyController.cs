﻿using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform groundDetector;

    [SerializeField] private float damage = 1;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 1f;
    private bool movingRight = true;

     private void FixedUpdate()
    {
        //GroundMonster AI Moving
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetector.position, Vector2.down, distance);
        if (groundinfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }


    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log("Hit " + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().DealDamage(damage);
        }
    }
}