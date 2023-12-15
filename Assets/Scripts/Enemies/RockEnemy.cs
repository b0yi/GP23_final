using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RockEnemy : EnemyController
{
    [Header("Cat Enemy Scripts Parameters")]
    private Animator anim;
    private AnimatorStateInfo animState;
    [DisplayOnly] public bool boolForJumpAnim;

    private int idleState;
    private int walkState;
    private int runState;
    private int jumpState;

    // Start is called before the first frame update
    void Start()
    {
        stage = "OnPlanet";
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //canJump = true;

        idleState = Animator.StringToHash("Base Layer.Rock_idle");
        walkState = Animator.StringToHash("Base Layer.Rock_walk");
        runState = Animator.StringToHash("Base Layer.Rock_run");
        //jumpState = Animator.StringToHash("Base Layer.Cat_jump");
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
        // anim.SetBool("jump", boolForJumpAnim);
        // if (boolForJumpAnim) {
        //     boolForJumpAnim = !boolForJumpAnim;
        // }
    }

    void FixedUpdate()
    {
        GroundCheck();

        if (stage == "OnPlanet")
        {
            Walk();
            //print(isGrounded);
        }
    }

    protected override void Walk()
    {
        if (isGrounded)
        {
            if (direction == 0)
            {
                // 只保留垂直方向的速度
                rb.velocity = Vector2.Dot(rb.velocity, ((Vector2)transform.up).normalized) * ((Vector2)transform.up).normalized;
            }
            else
            {
                transform.localScale = (direction > 0) ? new Vector3(2.0f, 2, 1) : new Vector3(-2.0f, 2, 1);
                Vector2 horizontalVelocity = Vector2.Dot(rb.velocity, ((Vector2)transform.right).normalized) * ((Vector2)transform.right).normalized;
                if (horizontalVelocity.magnitude < maxWalkSpeed)
                {
                    // 水平加速
                    rb.AddForce(direction * WalkAcceleration * rb.mass * ((Vector2)transform.right).normalized);
                }
            }
        }
    }
    protected override void DetectPlayer() {
        // bool inDetectRange = IsPlayerInRange(detectRange);
        // if (inDetectRange || chasePlayer) {
        //     isPlayerInEnemyRange = true;
        //     if (inDetectRange) {
        //         chasePlayer = false;
        //     }
        //     animState = anim.GetCurrentAnimatorStateInfo(0);
        //     // print(animState.fullPathHash );
        //     // print(runState);
        //     // if (animState.fullPathHash == runState ) {
        //     //     CaculateDirection();
        //     // }
        // }
        // else {
        //     isPlayerInEnemyRange = false;
        //     direction = 0;
        // }
        if (IsPlayerInRange(detectRange) || chasePlayer) {
            CaculateDirection();

        }
        else {
            direction = 0;
        }
    }

}
