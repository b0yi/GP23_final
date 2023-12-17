using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CatEnemy : EnemyController
{
    [Header("Cat Enemy Script Parameters")]
    [DisplayOnly] public bool boolForJumpAnim;
    private Animator anim;
    private AnimatorStateInfo animState;

    private int idleState;
    private int findState;
    private int runState;
    private int jumpState;

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
        animState = anim.GetCurrentAnimatorStateInfo(0);
        if (canJump && isGrounded && IsPlayerInRange(jumpRange) && animState.fullPathHash == runState) {
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

    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.collider.name == "Player") {
    //         // Knock back player
    //         Vector2 direct = player.transform.position - planet.transform.position;
    //         Vector3 knockback = direction < 0 ? new Vector3(direct.y, -direct.x, 0) : new Vector3(-direct.y, direct.x, 0);
    //         player.transform.position = player.transform.position - knockback.normalized * 8;
    //     }
    // }
    
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.name == "Player") {
            animState = anim.GetCurrentAnimatorStateInfo(0);
            if (animState.fullPathHash == jumpState) {
                // Knock back player
                Vector2 direct = player.transform.position - planet.transform.position;
                Vector3 knockback = direction < 0 ? new Vector3(direct.y, -direct.x, 0) : new Vector3(-direct.y, direct.x, 0);
                player.transform.position = player.transform.position - knockback.normalized * 8f;
            }
        }
    }
}


