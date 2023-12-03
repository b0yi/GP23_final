using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienItemCollect : MonoBehaviour
{
    public AudioSource detectoraudio;
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
            //print("Player in.");
            detectoraudio.Play();
            
        }
    }
}
