using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float size;
    public Vector2 direction;
    
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.localScale = new Vector3(size, size);
        rb.position = Vector2.MoveTowards(transform.position, direction, Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet")) return;
        if (other.gameObject.CompareTag("Player"))
        {
            
        }
        Destroy(gameObject);
    }
}
