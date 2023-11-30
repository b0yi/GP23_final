using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    public GameObject player;
    private PlayerController _playerController;

    void Start()
    {
        _playerController = player.GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && _playerController.fuel != 100f)
        {

            if (_playerController.fuel + 15f < 100f)
            {
                _playerController.fuel += 15f;
            }
            else
            {
                _playerController.fuel = 100f;
            }

            gameObject.SetActive(false);
        }
    }
}
