using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ClickingItem : Item
{
    private GameObject hintCanvas;
    private CanvasGroup hintCanvasGroup; //用來控制透明度
    private Image mouseBackground;
    private Animator anim;

    public float maxCount = 15f;
    [DisplayOnly] public float currentCount;
    [DisplayOnly] public bool canCollect;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        hintCanvas = transform.Find("HintCanvas").gameObject;
        hintCanvasGroup = hintCanvas.GetComponent<CanvasGroup>();
        mouseBackground = hintCanvas.transform.Find("HintBG").GetComponent<Image>();
        anim = GetComponent<Animator>();

        currentCount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDoClick();

        HintTransparent();

        anim.SetFloat("Remain", currentCount);
    }

    private void PlayerDoClick() {
        if (IsPlayerInRange(itemRange)) {
            isPlayerOnGround = GameObject.Find("Player").GetComponent<PlayerController_new>().isGrounded;
        }

        if (isPlayerInRange && isPlayerOnGround) {
            if (currentCount == maxCount) {
                // Counter is smaller than 0, player can collect!
                Destroy(gameObject);
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                // Reduce the counter
                currentCount += 1;
            }
        }
    }

    private void HintTransparent() {
        Vector3 playerPos = player.transform.position;
        float distance = (playerPos - transform.position).magnitude;
        if (distance > (itemRange / 2) + 2) {
            hintCanvasGroup.alpha = 0f;
            mouseBackground.color = new Color(0, 0, 0, 0.9f);
        }
        else if (distance <= (itemRange / 2) + 2 && distance > (itemRange / 2)) {
            hintCanvasGroup.alpha = 1f - (distance - (itemRange / 2)) / 2;
            mouseBackground.color = new Color(0, 0, 0, 0.9f);
        }
        else {
            hintCanvasGroup.alpha = 1f;
            if (Input.GetKey(KeyCode.Space)) {
                mouseBackground.color = new Color(0, 0.5f, 0, 0.9f);
            }
            else {
                mouseBackground.color = new Color(0, 0.75f, 0, 0.9f);
            }
        }
    }
}
