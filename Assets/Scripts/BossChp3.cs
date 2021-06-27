using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChp3 : MonoBehaviour
{
    [SerializeField] private float damage = 1;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distanceTime = 3f;
    [SerializeField] private float distanceCooldown;

    private bool moveLeft = true;
    private SpriteRenderer _spriteRend;

    private void Start()
    {
        _spriteRend = GetComponent<SpriteRenderer>();
        distanceCooldown = distanceTime;
    }

    private void Update()
    {
        if (distanceCooldown > 0)
        {
            distanceCooldown -= Time.deltaTime;
        }

        //On-off Switch Direction + Sprite Flip
        if (distanceCooldown <= 0 && moveLeft)
        {
            moveLeft = false;
            distanceCooldown = distanceTime;
            _spriteRend.flipX = false;
        }
        else if (distanceCooldown <= 0 && moveLeft == false)
        {
            moveLeft = true;
            distanceCooldown = distanceTime;
            _spriteRend.flipX = true;
        }
    }

    private void FixedUpdate()
    {

        if (moveLeft == false)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().DealDamage(damage);
        }
    }
}
