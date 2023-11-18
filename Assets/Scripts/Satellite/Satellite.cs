using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Satellite : MonoBehaviour
{
    public GameObject planet;
    private PlanetGravity _planetGravity; // see PlanetGravity.cs

    public float innerRadius;
    public float outerRadius;

    [DisplayOnly] public float radius;
    [DisplayOnly] public float velocity;

    void Start()
    {
        _planetGravity = planet.GetComponent<PlanetGravity>();
        radius = UnityEngine.Random.Range(innerRadius, outerRadius);
        float angle = UnityEngine.Random.Range(0f, 2f * Mathf.PI);
        velocity = Mathf.Sqrt(radius * _planetGravity.gravity);
        Vector3 planetPosition = planet.transform.position;
        Vector3 position = planetPosition + new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0f);
        transform.position = position; // 位置

        // --- 初速度 ---
        Vector2 gravityDirection = ((Vector2)(planetPosition - position)).normalized; // 指向球心
        GetComponent<Rigidbody2D>().velocity = Vector2.Perpendicular(gravityDirection * velocity);
    }

    void FixedUpdate()
    {
        _planetGravity.AddGravity(transform);
    }

}
