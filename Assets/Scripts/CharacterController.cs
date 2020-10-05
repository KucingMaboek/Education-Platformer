using UnityEngine;

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
    
    private bool IsGrounded() { 
        Collider2D overlapCircle = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer); 
        if (overlapCircle != null) { 
            return true;
        }
        return false;
    }
    
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(isGroundedChecker.position, checkGroundRadius);
    }
}