using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player") {
            PlanetGravity pg = transform.parent.GetComponent<PlanetGravity>();
            other.GetComponent<PlayerGravity>().planetGravity = pg;
            other.GetComponent<PlayerController>().planet = transform.parent.gameObject;
        }
    }
}
