using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

//[RequireComponent(typeof(Explodable))]
public class TriggerExplosion : MonoBehaviour 
{

	public Explodable explodable;
    public PlayerController_new playerController;
    [DisplayOnly] public float delayExplosionTimer;
    [DisplayOnly] bool explode;
    public float delayExplosionTime;

   

    private void Start()
    {
        explode = false;
    }

    private void Update()
    {
        if (explode)
        {
            delayExplosionTimer -= Time.deltaTime;
            
            if (delayExplosionTimer <= 0)
            {
                explodable.explode();
                playerController.Unlock();
                Destroy(gameObject);
            }

        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !explode) 
        {
            explode = true;
            delayExplosionTimer = delayExplosionTime;
            playerController.Lock();
            playerController.Transform();
            CinemachineShake.finalitem=false;
            print(other.gameObject.name);
        }
    }
}
