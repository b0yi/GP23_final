using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    public PlayerController_new playerController;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && playerController.fuel != 100f)
        {

            if (playerController.fuel + 15f < 100f)
            {
                playerController.fuel += 15f;
            }
            else
            {
                playerController.fuel = 100f;
            }

            gameObject.SetActive(false);
        }
    }
}
