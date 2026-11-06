using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PongBall : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 8f;
    [SerializeField] private float speedMultiplier = 1.05f; // vitesse à chaque rebond

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetBall();
    }


    public void ResetBall()
    {
        transform.position = Vector3.zero;
        rb.linearVelocity = Vector2.zero; 

        // Direction aléatoire au lancement
        float x = Random.Range(0, 2) == 0 ? -1f : 1f;
        float y = Random.Range(-0.5f, 0.5f);
        Vector2 direction = new Vector2(x, y).normalized;

        rb.AddForce(direction * initialSpeed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Paddle"))
        {
            rb.linearVelocity *= speedMultiplier;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Goal"))
        {
            ResetBall();
        }
    }
}