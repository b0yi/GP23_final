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

    public CatEnemy protector;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        hintCanvas = transform.Find("HintCanvas").gameObject;
        hintCanvasGroup = hintCanvas.GetComponent<CanvasGroup>();
        mouseBackground = hintCanvas.transform.Find("MouseBackground").GetComponent<Image>();
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
            isPlayerOnGround = GameObject.Find("Player").GetComponent<PlayerController>().isGrounded;
        }

        if (isPlayerInRange && isPlayerOnGround) {
            if (currentCount == maxCount) {
                // Counter is smaller than 0, player can collect!
                Destroy(gameObject);
            }

            if (Input.GetMouseButtonDown(0)) {
                // Reduce the counter
                currentCount += 1;
                protector.GoChasePlayer();
            }
        }
    }

    private void HintTransparent() {
        Vector3 playerPos = player.transform.position;
        float distance = (playerPos - transform.position).magnitude - (itemRange / 2);
        if (distance > 5) {
            hintCanvasGroup.alpha = 0f;
            mouseBackground.color = new Color(0, 0, 0, 0.8f);
        }
        else if (distance <= 5 && distance > 0) {
            hintCanvasGroup.alpha = 1f - distance / 5;
            mouseBackground.color = new Color(0, 0, 0, 0.8f);
        }
        else {
            hintCanvasGroup.alpha = 1f;
            mouseBackground.color = new Color(0, 0.75f, 0, 0.8f);
        }
    }
}
