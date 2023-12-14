using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CatEnemy : EnemyController
{
    [Header("Cat Enemy Scripts Parameters")]
    private Animator anim;
    private AnimatorStateInfo animState;
    [DisplayOnly] public bool boolForJumpAnim;

    private int idleState;
    private int findState;
    private int runState;
    private int jumpState;

    public float questRange;                // 互動距離
    [DisplayOnly] public string catStage;   // stages: water / fish / reward / kill / ...

    // Start is called before the first frame update
    void Start()
    {
        stage = "OnPlanet";
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canJump = true;

        idleState = Animator.StringToHash("Base Layer.Cat_idle");
        findState = Animator.StringToHash("Base Layer.Cat_findPlayer");
        runState = Animator.StringToHash("Base Layer.Cat_run");
        jumpState = Animator.StringToHash("Base Layer.Cat_jump");

        catStage = "water";
    }

    // Update is called once per frame
    void Update()
    {
        if (stage == "OnPlanet")
        {
            gravity = planet.GetComponent<PlanetGravity>().gravity;
        }

        DetectPlayer();

        anim.SetBool("isPlayerInRange", isPlayerInEnemyRange);
        anim.SetBool("jump", boolForJumpAnim);
        if (boolForJumpAnim) {
            boolForJumpAnim = !boolForJumpAnim;
        }
    }

    void FixedUpdate()
    {
        GroundCheck();

        if (stage == "OnPlanet")
        {
            Walk();
            Jump();
        }
    }

    protected override void Jump()
    {
        if (canJump && isGrounded && IsPlayerInRange(jumpRange)) {
            canJump = false;
            boolForJumpAnim = true;
            // 只保留水平方向的速度
            rb.velocity = Vector2.Dot(rb.velocity, ((Vector2)transform.right).normalized) * ((Vector2)transform.right).normalized;
            // 往上初速度
            rb.velocity += Mathf.Sqrt(2f * jumpHeight * gravity) * (Vector2)transform.up;
            jump = false;
            StartCoroutine(JumpCoolDown(jumpCoolDown));
        }
    }

    protected override void DetectPlayer() {
        bool inDetectRange = IsPlayerInRange(detectRange);
        if (inDetectRange || chasePlayer) {
            isPlayerInEnemyRange = true;
            if (inDetectRange) {
                chasePlayer = false;
            }
            animState = anim.GetCurrentAnimatorStateInfo(0);
            if (animState.fullPathHash == runState || animState.fullPathHash == jumpState) {
                CaculateDirection();
            }
        }
        else {
            isPlayerInEnemyRange = false;
            direction = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "Player") {
            // kill player
            player.GetComponent<PlayerController>().isHurtByCat = true;
        }
    }

    private void StageBehavior() {
        if (catStage == "water" || catStage == "fish") {
            if (IsPlayerInRange(questRange)) {
                ShowQuest();
            }
        }
        else if (catStage == "reward") {

        }
        else if (catStage == "kill") {
            GoChasePlayer();
        }
        else {

        }
    }

    private void ShowQuest() {
        if (catStage == "water") {

        }
        else if (catStage == "fish") {

        }
        else {
            
        }
    }
}
