using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (speed == 0) speed = 4;
    }

    private void Update()
    {
        float movex = Input.GetAxisRaw("Horizontal");
        float movey = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector2(movex, movey);

        move.Normalize();

        Vector3 newPosition = rb.transform.position + move * (speed * Time.deltaTime);



        rb.transform.position += move * (speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector3.zero;
    }
}
