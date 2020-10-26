using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;
    public GameObject bulletPrefab;
    public GameObject bulletPrefabLeft;

    [SerializeField] private float coin = 0;
    [SerializeField] private float maxHealth = 3;
    [SerializeField] private float currentHealth;
    [SerializeField] private float invulnerableTime = 0.5f;
    [SerializeField] private float invulnerableCooldown;
    [SerializeField] private float ShootTime = 0.5f;
    [SerializeField] private float ShootCooldown;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded;
    public bool IsMovingRight { get; set; }

    public bool IsMovingLeft { get; set; }
    public bool IsJumping { get; set; }

    public bool IsShooting { get; set; }

    public bool IsGrounded
    {
        get => isGrounded;
        set => isGrounded = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Shoot();
        if (invulnerableCooldown > 0)
        {
            invulnerableCooldown -= Time.deltaTime;
        }
        if (ShootCooldown > 0)
        {
            ShootCooldown -= Time.deltaTime;
        }
    }

    private void Move()
    {
        if (IsMovingRight)
        {
            _rb.velocity = new Vector2(movementSpeed, _rb.velocity.y);
            _spriteRenderer.flipX = false;
        }
        else if (IsMovingLeft)
        {
            _rb.velocity = new Vector2(-movementSpeed, _rb.velocity.y);
            _spriteRenderer.flipX = true;
        }
        else
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
    }

    private void Jump()
    {
        if (IsJumping && IsGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        }
    }
    public void DealDamage(float damage)
    {
        if (invulnerableCooldown <= 0)
        {
            // Reduce health by damage
            currentHealth -= damage;
            // If current health is 0, death
            if (currentHealth <= 0)
            {
                OnDeath();
            }
            // Reset invulnerable cooldown
            invulnerableCooldown = invulnerableTime;
        }
    }

    public void Shoot()
    {
        if (IsShooting)
        {
            if (ShootCooldown <= 0)
            {
                if (_spriteRenderer.flipX == true)
                {
                    GameObject projectile = Instantiate(bulletPrefabLeft) as GameObject;
                    projectile.transform.position = transform.position;
                    ShootCooldown = ShootTime;
                }
                else if (_spriteRenderer.flipX == false)
                {
                    GameObject projectile = Instantiate(bulletPrefab) as GameObject;
                    projectile.transform.position = transform.position;
                    ShootCooldown = ShootTime;                
                }
            }            
        }        
    }

    private void OnDeath()
    {
        // Not implemented yet
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin")){
            Destroy(other.gameObject);
            coin += 1;
        }
    }
}