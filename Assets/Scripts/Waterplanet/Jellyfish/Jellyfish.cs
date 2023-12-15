using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    public float forwardVelocity = 5f;
    public float backVelocity = 3f;
    private bool isMovingForward = true;

    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        InvokeRepeating(nameof(ToggleMovementDirection), 0f, 1f);
    }

    void FixedUpdate()
    {
        if (isMovingForward)
        {
            Move(forwardVelocity);
        }
        else
        {
            Move(-backVelocity);
        }
    }

    void Move(float speed)
    {
        Vector2 movement = transform.up * speed;
        _rigidbody.velocity = movement;
    }

    void ToggleMovementDirection()
    {
        isMovingForward = !isMovingForward;
    }
}
