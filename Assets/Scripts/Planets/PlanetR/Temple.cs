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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;

        canTeleport = true;
        startCounting = false;
        currentTime = 0f;
        currentCD = teleportCD;
    }

    // Update is called once per frame
    void Update()
    {
        if (canTeleport) {
            if (startCounting) {
                currentTime += Time.deltaTime;
                if (currentTime >= teleportTime) {
                    Teleport();
                }
            }
        }
        else {
            currentCD -= Time.deltaTime;
            if (currentCD < 0f) {
                canTeleport = true;
                currentTime = 0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player") {
            Debug.Log("Player Entered");
            startCounting = true;
        }
        else {
            Debug.Log("None entered");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player") {
            Debug.Log("Player Left");
            startCounting = false;
            currentTime = 0f;
        }
        else {
            Debug.Log("None left");
        }
    }

    private void Teleport() {
        currentCD = teleportCD;
        otherTemple.currentCD = teleportCD;
        canTeleport = false;
        otherTemple.canTeleport = false;
        player.position = otherTemple.transform.position;
    }
}
