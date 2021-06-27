using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float speed = 8.0f;
    [SerializeField] private float life = 0.6f;

    private Rigidbody2D rb;
    private Vector2 screenBounds;

    // public GameObject explosion;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (life > 0)
        {
            life -= Time.deltaTime;
        }
        if (life < 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //GameObject e = Instantiate(explosion) as GameObject;
            //e.transform.position = transform.position;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.tag == "Tile")
        {
            Destroy(this.gameObject);
        }
    }
}