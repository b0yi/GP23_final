using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field_new : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlanetGravity pg = transform.parent.GetComponent<PlanetGravity>();
            other.GetComponent<PlayerGravity_new>().planetGravity = pg;
            other.GetComponent<PlayerController_new>().planet = transform.parent.gameObject;
        }
    }
}
