using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteGravity : MonoBehaviour
{
    public PlanetGravity planetGravity; // see PlanetGravity.cs

    public float minVelocity;
    public float maxVelocity;

    public float minMass;
    public float maxMass;


    void Start()
    {
        transform.GetComponent<Rigidbody2D>().velocity = Random.Range(minVelocity, maxVelocity) * transform.right;
        transform.GetComponent<Rigidbody2D>().mass = Random.Range(minMass, maxMass);

    }

    void FixedUpdate()
    {
        planetGravity.AddGravity(transform);
    }

}
