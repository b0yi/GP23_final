using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFrontDetector : MonoBehaviour
{
    public GameObject rockenemy;
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
        if (other.name == "Maze Planet")
        {
            rockenemy.GetComponent<RockEnemy>().Stop = false;
        }
        
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Maze Planet")
        {
            rockenemy.GetComponent<RockEnemy>().Stop = true;
        }
        
    }
}
