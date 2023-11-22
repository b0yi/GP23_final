using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGravity : MonoBehaviour
{
    public PlanetGravity planetGravity; // see PlanetGravity.cs

    private EnemyController _EnemyController;

    void Start()
    {
        _EnemyController = GetComponent<EnemyController>();
    }

    void FixedUpdate()
    {
        if (_EnemyController.stage == "OnPlanet")
            planetGravity.AddGravity(transform);
    }
}
