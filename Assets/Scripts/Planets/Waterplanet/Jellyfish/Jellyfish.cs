using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float backSpeed = 3f;

    private bool isMovingForward = true;


    public float radius = 50f;
    public Transform waterPlanetTF;


    void Start()
    {
        InvokeRepeating(nameof(ToggleMovementDirection), 0f, 1f);
    }

    void Update()
    {

        // Vector3 directionToCenter = center.position - transform.position;
        Vector2 directionToCenter = waterPlanetTF.position - transform.position;

        if (directionToCenter.magnitude > radius)
        {
            Reflect();
        }
        else
        {
            if (isMovingForward)
            {
                Move(forwardSpeed);
            }
            else
            {
                Move(-backSpeed);
            }

        }
    }

    void Move(float speed)
    {
        transform.Translate(speed * Time.deltaTime * Vector2.up);
    }

    void ToggleMovementDirection()
    {
        isMovingForward = !isMovingForward;
    }

    void Reflect()
    {
        Vector2 reflection = Vector2.Reflect(transform.up, waterPlanetTF.position - transform.position);

        transform.up = reflection;

        transform.Translate(forwardSpeed * 10f * Time.deltaTime * Vector2.up);
        isMovingForward = true;
    }

}
