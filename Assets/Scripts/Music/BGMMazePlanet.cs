using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMMazePlanet : MonoBehaviour
{
    public BGMmanager bGMmanager;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            bGMmanager.EnterMazePlanet();
        }
    }
    // void OnTriggerExit2D(Collider2D other) {
    //     if (other.CompareTag("Player")) {
    //         bGMmanager.ExitMazePlanet();
    //     }
    // }
}
