using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMCatPlanet : MonoBehaviour
{
    public BGMmanager bGMmanager;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            bGMmanager.EnterCatPlanet();
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            bGMmanager.ExitCatPlanet();
        }
    }
}
