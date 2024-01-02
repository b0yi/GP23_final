using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
    public Explodable explodable;
    public PlayerController_new player;
    //public PlayerController_new playerController;
    [DisplayOnly] public float delayExplosionTimer;
    [DisplayOnly] bool explode;
    //public float delayExplosionTime;
    //public GameObject dragon;


    private void Start()
    {
        explode = false;
        //dragon.SetActive(false);
    }

    private void Update()
    {
        if (explode)
        {
            delayExplosionTimer -= Time.deltaTime;

            if (delayExplosionTimer <= 0)
            {
                explodable.explode();
                //playerController.Unlock();
                Destroy(gameObject);
                //dragon.SetActive(true);
            }

        }
    }


    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Player") && !explode)
    //     {
    //         explode = true;
    //         delayExplosionTimer = delayExplosionTime;
    //     }
    // }
}
