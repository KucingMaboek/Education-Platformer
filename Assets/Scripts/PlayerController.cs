using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;
    public GameObject bulletPrefab, bulletPrefabLeft, PauseWindow, BGPanelLose;
    private Animator _anim;
    private Renderer _render;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;

    [SerializeField] private float coin = 0;
    [SerializeField] private float maxHealth = 3;
    [SerializeField] private float currentHealth;
    [SerializeField] private float invulnerableTime = 1.5f;
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
        _anim = GetComponent<Animator>();
        _render = GetComponent<Renderer>();
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
        if (IsMovingRight || Input.GetKey(KeyCode.RightArrow))
        {
            _rb.velocity = new Vector2(movementSpeed, _rb.velocity.y);
            _spriteRenderer.flipX = false;
            _anim.SetBool("IsWalking", true);
        }
        else if (IsMovingLeft || Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.velocity = new Vector2(-movementSpeed, _rb.velocity.y);
            _spriteRenderer.flipX = true;
            _anim.SetBool("IsWalking", true);
        }
        else
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            _anim.SetBool("IsWalking", false);
        }
    }

    private void Jump()
    {
        if ((Input.GetKey(KeyCode.UpArrow) || IsJumping) && IsGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            GameManager.Instance.PlaySfx("button_jump");
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
        updateHealth();
    }

    public void Shoot()
    {
        if (Input.GetKey(KeyCode.Space) || IsShooting)
        {
            if (ShootCooldown <= 0)
            {
                
                if (_spriteRenderer.flipX == true)
                {
                    GameObject projectile = Instantiate(bulletPrefabLeft) as GameObject;
                    //projectile.transform.position = transform.position;
                    projectile.transform.position = _render.bounds.center;
                    ShootCooldown = ShootTime;
                }
                else if (_spriteRenderer.flipX == false)
                {
                    GameObject projectile = Instantiate(bulletPrefab) as GameObject;
                    //projectile.transform.position = transform.position;
                    projectile.transform.position = _render.bounds.center;
                    ShootCooldown = ShootTime;                
                }
                GameManager.Instance.PlaySfx("button_shot");
            }            
        }        
    }

    private void updateHealth()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].sprite = emptyHearts;
            }

            if (i < currentHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }


    private void OnDeath()
    {
        Time.timeScale = 0f;
        BGPanelLose.SetActive(true);
        PauseWindow.SetActive(true);
    }

    //Pickup Coin
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Deadzone")
        {
            OnDeath();
        }
    }
}