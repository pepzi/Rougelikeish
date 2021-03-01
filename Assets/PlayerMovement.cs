using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4.0f;

    private Rigidbody2D _rigidBody2D;
    private Animator _animator;
    private Vector2 _velocity;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
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
        if (_velocity == Vector2.zero)
        {
            _animator.SetBool("isWalking", false);
            return;
        }
        else
        {
            _animator.SetBool("isWalking", true);
            _animator.SetFloat("movex", _velocity.x);
            _animator.SetFloat("movey", _velocity.y);
        }
    }

    private void MovePlayer()
    {
        _rigidBody2D.velocity = _velocity * speed;
    }

    private void HandleInput()
    {
        _velocity = Vector2.zero;
        _velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _velocity.Normalize();
    }
}
