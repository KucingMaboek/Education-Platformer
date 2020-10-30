using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChp1 : MonoBehaviour
{
    [SerializeField] public float damage = 1;
    [SerializeField] private float ShootTime = 0.5f;
    [SerializeField] private float ShootCooldown;
    [SerializeField] public float projectileDistance = 2f;


    public GameObject bulletPrefabLeft;
    private Renderer _render;

    public bool IsShooting { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //testing purpose, main purpose is run BossShoot() when player is around boss
        if (Input.GetKeyDown("a"))
        {
            Debug.Log("From Script BossChp1");
            BossShoot();
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

    private void BossShoot()
    {
        GameObject projectile = Instantiate(bulletPrefabLeft) as GameObject;
        //projectile.transform.position = transform.position;
        projectile.transform.position = _render.bounds.center;
        ShootCooldown = ShootTime;
    }
}
