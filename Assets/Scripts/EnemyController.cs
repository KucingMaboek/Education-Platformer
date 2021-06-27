using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform groundDetector, wallDetector;
    public GameObject prefabCoin;

    [SerializeField] private float damage = 1;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 0.5f;
    [SerializeField] private LayerMask layerMask;
    private bool movingRight = true;

    private void FixedUpdate()
    {
        //GroundMonster AI Moving
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        //Layermask-ed raycast to Tile
        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetector.position, Vector2.down, distance, layerMask);
        RaycastHit2D wallinfo = Physics2D.Raycast(wallDetector.position, Vector2.right, distance, layerMask);
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
        if (wallinfo.collider == true)
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
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().DealDamage(damage);
        }
    }
}