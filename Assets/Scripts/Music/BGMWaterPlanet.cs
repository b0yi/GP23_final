using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMWaterPlanet : MonoBehaviour
{
    public BGMmanager bGMmanager;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            bGMmanager.EnterWaterPlanet();
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            bGMmanager.ExitWaterPlanet();
        }
    }
}
