using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float damage = 1;


    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log("Hit " + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().DealDamage(damage);
        }
    }
}