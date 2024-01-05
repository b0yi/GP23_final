using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ClickingItem : Item
{
    private GameObject hintCanvas;
    private CanvasGroup canvasGroup; 
    private Image HintBG;
    private Slider slider;
    private Animator anim;
    public UIMazeItem uIMazeItem;

    public float maxCount = 15f;
    [DisplayOnly] public float currentCount;
    [DisplayOnly] public bool canCollect;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        hintCanvas = transform.Find("HintCanvas").gameObject;
        canvasGroup = hintCanvas.GetComponent<CanvasGroup>();
        HintBG = hintCanvas.transform.Find("HintBG").GetComponent<Image>();
        slider = hintCanvas.transform.Find("Slider").GetComponent<Slider>();
        anim = GetComponent<Animator>();
        canvasGroup.alpha = 0f;
        slider.value = 0;
        slider.maxValue = maxCount;
        currentCount = 0f;
        canCollect = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (uIMazeItem.itemCanShowCanvas) {
            PlayerDoClick();

            HintTransparent();

            anim.SetFloat("Remain", currentCount);
        }
    }

    private void PlayerDoClick() {
        if (IsPlayerInRange(itemRange)) {
            isPlayerOnGround = GameObject.Find("Player").GetComponent<PlayerController_new>().isGrounded;
        }

        if (isPlayerInRange && isPlayerOnGround) {
            if (currentCount == maxCount) {
                // Counter is smaller than 0, player can collect!
                uIMazeItem.IncreaseCollect();
                Destroy(gameObject);
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                // Reduce the counter
                currentCount += 1;
            }
        }

        slider.value = currentCount;
    }

    private void HintTransparent() {
        Vector3 playerPos = player.transform.position;
        float distance = (playerPos - transform.position).magnitude;
        if (distance > (itemRange / 2) + 4) {
            canvasGroup.alpha = 0f;
            HintBG.color = new Color(0, 0, 0, 0.9f);
        }
        else if (distance <= (itemRange / 2) + 4 && distance > (itemRange / 2)) {
            canvasGroup.alpha = 1f - (distance - (itemRange / 2)) / 4;
            HintBG.color = new Color(0, 0, 0, 0.9f);
        }
        else {
            canvasGroup.alpha = 1f;
            if (Input.GetKey(KeyCode.Space)) {
                HintBG.color = new Color(0, 0.5f, 0, 0.9f);
            }
            else {
                HintBG.color = new Color(0, 0.75f, 0, 0.9f);
            }
        }
    }
}
