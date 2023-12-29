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
    public GameObject dragon;
    public GameObject sun;
    private StageManager _stageManager;
    private void Start()
    {
        GameObject m = GameObject.FindWithTag("UIManager");
        explode = false;
        dragon.SetActive(false);
        CinemachineShake.finalitem = true;
        _stageManager = m.GetComponent<StageManager>();

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
                dragon.SetActive(true);
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
            CinemachineShake.finalitem = false;
            sun.SetActive(false);
            //_stageManager.UpdateStage();
            if (_stageManager.stage == Stage.ToDragonPlanet) {
                _stageManager.UpdateStage();
            }
        }
    }
}
