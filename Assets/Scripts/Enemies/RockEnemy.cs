using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RockEnemy : EnemyController
{
    [Header("Cat Enemy Scripts Parameters")]
    private Animator anim;
    private AnimatorStateInfo animState;
    [DisplayOnly] public bool boolForIdleAnim=false;
    [DisplayOnly] public bool boolForWandering=true;
    [DisplayOnly] public bool inAttackRange=false;

    private int idleState;
    private int walkState;
    private int runState;
    float _changeDirectionCooldown=1.0f;
    float _idletime=3.0f;
    float attackRange=8.0f;
    //Random rnd = new Random();
    // Start is called before the first frame update
    void Start()
    {
        stage = "OnPlanet";
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        direction=1;
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
        anim.SetBool("IsWandering", boolForWandering);
        anim.SetBool("idle", boolForIdleAnim);
        anim.SetBool("inAttackRange", inAttackRange);
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
            Run();
            //print(isGrounded);
        }
    }
    private void HandleRandomDirectionChange()
    {
        _changeDirectionCooldown -= Time.deltaTime;

        if (_changeDirectionCooldown <= 0)
        {
            boolForIdleAnim=true;
            _idletime-= Time.deltaTime;
            direction=0;
            if (_idletime <= 0)
            {
                boolForIdleAnim=false;
                _changeDirectionCooldown = Random.Range(1f, 5f);

                do
                {
                    direction=Random.Range(-2,2);
                }
                while(direction==0);
                _idletime=3.0f;
            }
        }
    }

    // private void Idle()
    // {
    //    _idletime-= Time.deltaTime;
    // }
    protected override void Walk()
    {
        // player.GetComponent<CapsuleCollider2D>().enabled==false
        if ((isGrounded&&boolForWandering))
        {
            HandleRandomDirectionChange();
            //print(_changeDirectionCooldown);
            //print(direction);
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

    protected void Run()
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
                if (horizontalVelocity.magnitude < maxWalkSpeed*2)
                {
                    // 水平加速
                    rb.AddForce(direction * WalkAcceleration * rb.mass * ((Vector2)transform.right).normalized*2);
                }
            }
        }
    }
    protected override void DetectPlayer() 
    {
        if(player.GetComponent<PlayerController_new>().isHurt==true)
            isPlayerInEnemyRange=false;

        if (IsPlayerInRange(detectRange)&& player.GetComponent<PlayerController_new>().isHurt==false)
        //if (IsPlayerInRange(detectRange))
        {
            //print("In detect range");
            boolForWandering=false;
            isPlayerInEnemyRange=true;
            //print(isPlayerInEnemyRange);
            CaculateDirection();
            if(IsPlayerInRange(attackRange))
            {
                //print(isPlayerInEnemyRange);
                
                inAttackRange=true;
            }
        }
        else 
        {
            //direction = 0;
            boolForWandering=true;
            inAttackRange=false;
        }
        //print(isPlayerInEnemyRange);
    }

    protected override bool IsPlayerInRange(float rangeToDetect) 
    {
        Vector3 playerPos = player.transform.position;
        float distance = (playerPos - transform.position).magnitude;

        if (distance <= rangeToDetect / 2) {
            //isPlayerInEnemyRange = true;
            return true;
        }
        else {
            //isPlayerInEnemyRange = false;
            return false;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
         if (other.gameObject.name == "Player")
          {
            // kill player
            player.GetComponent<PlayerController_new>().isHurt = true;
        }
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.name == "Player")
    //     {
    //         inAttackRange=true;
    //     }

    // }

    
    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.name == "Player")
    //     {
    //         inAttackRange=false;
    //     }
    // }
}
