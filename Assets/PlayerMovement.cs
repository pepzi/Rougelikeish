using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4.0f;

    private Rigidbody2D rigidBody2D;
    private Vector2 _velocity;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        _velocity = Vector2.zero;
    }

    private void Update()
    {
        HandleInput();
        UpdateAnimator();
        MovePlayer();
    }

    private void UpdateAnimator()
    {
        if (_velocity.x > 0)
        {
            transform.localScale = new Vector2(1.0f, 1.0f);
        }
        if (_velocity.x < 0)
        {
            transform.localScale = new Vector2(-1.0f, 1.0f);
        }
        if (_velocity.y > 0)
        {

        }
        if (_velocity.y < 0)
        {

        }
    }

    private void MovePlayer()
    {
        rigidBody2D.velocity = _velocity * speed;
    }

    private void HandleInput()
    {
        _velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _velocity.Normalize();
    }
}
