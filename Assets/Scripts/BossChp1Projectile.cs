using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChp1Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 8.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    BossChp1 _bossChp1;

    // public GameObject explosion;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x > screenBounds.x)
        {
            //Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().DealDamage(_bossChp1.damage);
            Destroy(this.gameObject);
        }
        //testing purpose but why is this didn't work? projectile doesnt destroyed when collide with enemy
        else if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }


}
