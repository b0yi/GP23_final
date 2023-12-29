using UnityEngine;

public class PlayerGravity_end : MonoBehaviour
{
    public PlanetGravity planetGravity; // see PlanetGravity.cs




    void Update()
    {
    }

    void FixedUpdate()
    {
        planetGravity.AddGravity(transform);
    }
}