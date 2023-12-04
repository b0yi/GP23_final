using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickingItem : Item
{
    private Slider progressBar;

    [SerializeField]
    float maxCount = 50f;
    [SerializeField][DisplayOnly]
    float currentCount;

    private bool canCollect;

    public CatEnemy protector;

    // Start is called before the first frame update
    void Start()
    {
        progressBar = itemCanvas.transform.Find("ProgressBar").GetComponent<Slider>();
        progressBar.maxValue = maxCount;
        ItemReset();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange) {
            isPlayerOnGround = GameObject.Find("Player").GetComponent<PlayerController>().isGrounded;
        }
        if (canCollect && isPlayerOnGround) {
        // if (canCollect) {
            if (currentCount == maxCount) {
                // Counter is smaller than 0, player can collect!
                OpenItemGetCanvas(itemName);
                Destroy(itemCanvas);
                Destroy(gameObject);
            }
            // Player is in the collect range
            progressBar.value = currentCount; // Slider's value

            if (Input.GetMouseButtonDown(0)) {
                // Reduce the counter
                currentCount += 1;
                protector.CaculateDirection();
            }
        }
    }

    public override void ShowItemCanvas()
    {
        itemCanvas.SetActive(true);
        canCollect = true;
    }

    public override void CloseItemCanvas()
    {
        itemCanvas.SetActive(false);
        canCollect = false;
    }

    public override void ItemReset() {
        // Reset the item's state
        CloseItemCanvas();
        currentCount = 0f;
    }
}
