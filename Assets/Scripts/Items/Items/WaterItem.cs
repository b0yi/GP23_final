using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterItem : Item
{
    // Start is called before the first frame update
    void Start()
    {
        CloseItemCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "Player") {
            OpenItemGetCanvas(itemName);
            Destroy(itemCanvas);
            Destroy(gameObject);
        }
    }
}
