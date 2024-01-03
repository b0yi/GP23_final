using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFade : MonoBehaviour
{
    public float lifetime = 2;
    Color fade;
    float timer=0f;
    public float fadespeed=1.02f;
    private bool exitarea=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(exitarea)
        {
            timer += Time.deltaTime;
            if (timer <= lifetime) 
            {
                //Transparency.
                fade = GetComponent<Renderer> ().material.color;
                fade.a = fade.a /fadespeed;
                GetComponent<Renderer>().material.color = fade;
                //kill when faded
                // if(fade.a <=15)
                // {
                //     Destroy (transform.parent.gameObject);
                    
                // }
                
            }
            if (timer > lifetime) 
            {
                Destroy (gameObject,lifetime);
            }
        }

    }

     void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("ObstacleArea"))
        {
            exitarea=true;
        }
    }
}
