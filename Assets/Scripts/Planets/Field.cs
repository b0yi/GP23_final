using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            PlanetGravity pg = transform.parent.GetComponent<PlanetGravity>();
            other.GetComponent<PlayerGravity>().planetGravity = pg;
            other.GetComponent<PlayerController>().planet = transform.parent.gameObject;
        }
    }
}
