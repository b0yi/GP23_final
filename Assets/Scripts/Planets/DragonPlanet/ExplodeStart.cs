using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeStart : MonoBehaviour
{
    // Start is called before the first frame update
    public Explodable explodable;
    void Start()
    {
        explodable.explode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
