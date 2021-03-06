﻿using UnityEngine;

public class FixedProjectile : MonoBehaviour
{
    public Vector3 Velocity;

    private void Awake()
    {
        gameObject.layer = Constants.GunLayer;
    }

    public void SetTarget(Vector2 _velocity)
    {
        Velocity = _velocity;
    }

    void Update()
    {
        if (Velocity == null) return;
        transform.position += Velocity * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet")) return;
        if (other.gameObject.CompareTag("Player"))
        {
            return;
        }
        Destroy(gameObject);
    }
}