using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public string itemName;
    public float itemRange;
    public ItemCanvasHandler itemCanvasHandler;

    protected GameObject player;

    [DisplayOnly] public bool isPlayerOnGround;
    [DisplayOnly] public bool isPlayerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected bool IsPlayerInRange(float rangeToDetect) {
        Vector3 playerPos = player.transform.position;
        float distance = (playerPos - transform.position).magnitude;

        if (distance <= rangeToDetect / 2) {
            isPlayerInRange = true;
            return true;
        }
        else {
            isPlayerInRange = false;
            return false;
        }
    }

    public void OpenItemGetCanvas(string itemName) {
        itemCanvasHandler.OpenItemGetCanvas(itemName);
    }
}
