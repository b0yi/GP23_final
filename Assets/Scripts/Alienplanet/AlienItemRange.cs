using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienItemRange : MonoBehaviour
{
    public AudioSource detectoraudio;
    // Start is called before the first frame update
    void Start()
    {
        detectoraudio=GetComponent<AudioSource>();
        //detectoraudio.Play();
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

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player") {
            //print("Player in.");
            detectoraudio.Stop();
            
        }
    }
}
