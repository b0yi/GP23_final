using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temple : MonoBehaviour
{
    public Temple otherTemple;
    private Transform player;

    [DisplayOnly] public bool canTeleport;
    [DisplayOnly] public bool startCounting;
    public float teleportTime = 1.5f;
    [DisplayOnly] public float currentTime;
    public float teleportCD = 8f;
    [DisplayOnly] public float currentCD;

    public ParticleSystem teleportParticle;
    public GameObject teleportLight;
    private StageManager _stageManager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject m = GameObject.FindWithTag("UIManager");
        _stageManager = m.GetComponent<StageManager>();

        player = GameObject.Find("Player").transform;

        canTeleport = true;
        startCounting = false;
        currentTime = 0f;
        currentCD = teleportCD;
        StopParticle();
    }

    // Update is called once per frame
    void Update()
    {
        if (canTeleport)
        {
            teleportLight.SetActive(true);
            if (startCounting)
            {
                currentTime += Time.deltaTime;
                if (currentTime >= teleportTime)
                {
                    Teleport();
                    if (_stageManager.stage == Stage.Maze)
                    {
                        _stageManager.UpdateStage();
                    }
                }
            }
        }
        else
        {
            teleportLight.SetActive(false);
            currentCD -= Time.deltaTime;
            if (currentCD < 0f)
            {
                canTeleport = true;
                currentTime = 0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            startCounting = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if (canTeleport && startCounting)
            {
                GenerateParticle();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            startCounting = false;
            currentTime = 0f;
            StopParticle();
        }
    }

    private void Teleport()
    {
        currentCD = teleportCD;
        otherTemple.currentCD = teleportCD;
        canTeleport = false;
        otherTemple.canTeleport = false;
        player.position = otherTemple.transform.position;
    }

    private void GenerateParticle()
    {
        teleportParticle.Play();
    }

    private void StopParticle()
    {
        teleportParticle.Stop();
    }
}
