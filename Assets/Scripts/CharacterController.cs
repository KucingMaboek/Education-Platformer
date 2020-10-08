using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public bool IsMovingRight { get; set; }

    public bool IsMovingLeft { get; set; }
    public bool IsJumping { get; set; }
    // public bool IsGrounded { get; set; }
    private Rigidbody2D _rb;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    
    public Transform isGroundedChecker; 
    public float checkGroundRadius; 
    public LayerMask groundLayer;
    public Collider2D enemyCollider;
    

    // Start is called before the first frame update
    void Start()
    {
        
        _rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Lose();
    }

    private void Move()
    {
        if (IsMovingRight)
        {
            // transform.Translate(Vector3.right*movementSpeed*Time.deltaTime);
            _rb.velocity = new Vector2(movementSpeed, _rb.velocity.y);
            spriteRenderer.flipX = false;
        }
        else if (IsMovingLeft)
        {
            // transform.Translate(Vector3.left*movementSpeed*Time.deltaTime);
            _rb.velocity = new Vector2(-movementSpeed, _rb.velocity.y);
            spriteRenderer.flipX = true;
        }
        else
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
    }

    private void Jump()
    {
        if (IsJumping)
        {
            if (IsGrounded())
            {
                _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            }
        }
    }

    private void Lose()
    {
        if(transform.position.y <= -5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (transform.Find("HealthPlayer").GetComponent<HealthPlayer>().health == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    private bool IsGrounded() {
        return transform.Find("GroundChecker").GetComponent<GroundChecker>().IsGrounded;
        /*
        Collider2D overlapCircle = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer); 
        if (overlapCircle != null) { 
            return true;
        }
        return false;
        */
    }
    
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(isGroundedChecker.position, checkGroundRadius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
           transform.Find("HealthPlayer").GetComponent<HealthPlayer>().health -= 1;
           Physics2D.IgnoreCollision(GetComponent<Collider2D>(), enemyCollider, true);
           StartCoroutine(EnableCollision(3));
        }
    }

    private IEnumerator EnableCollision(float delay)
    {
        yield return new WaitForSeconds(delay);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), enemyCollider, false);
    }
}