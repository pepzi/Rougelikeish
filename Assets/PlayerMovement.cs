using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4.0f;
    private Rigidbody2D rigidBody2D;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float movex = Input.GetAxisRaw("Horizontal");
        float movey = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector2(movex, movey);
        move.Normalize();


        rigidBody2D.velocity = move* speed;
//        rigidBody2D.transform.position += move * (speed * Time.deltaTime);
    }
}
