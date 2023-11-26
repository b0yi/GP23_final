using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEnemy : EnemyController
{
    [Header("Cat Enemy Scripts Parameters")]
    public float jumpRange = 10f;
    private Animator anim;
    [DisplayOnly] public bool boolForJumpAnim;
    // Start is called before the first frame update
    void Start()
    {
        stage = "OnPlanet";
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (stage == "OnPlanet")
        {
            gravity = planet.GetComponent<PlanetGravity>().gravity;
        }

        DetectPlayer();

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

    protected override void GroundCheck()
    {
        Vector2 position = (Vector2)transform.position - (Vector2)transform.up * footOffset; // 射線起點
        RaycastHit2D raycast = Physics2D.Raycast(position, -(Vector2)transform.up, raycastDistance, groundLayer);
        height = raycast.distance;
        if (raycast && height < 0.1f)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        /* DEBUG START */
        Color color = (!isGrounded) ? Color.red : Color.green;
        Debug.DrawRay(position, -(Vector2)transform.up * raycastDistance, color);
        /* DEBUG END */
    }

    protected override void Jump()
    {
        if (isGrounded && IsPlayerInJumpRange() && canJump) {
            jump = true;
            boolForJumpAnim = true;
            // 只保留水平方向的速度
            rb.velocity = Vector2.Dot(rb.velocity, ((Vector2)transform.right).normalized) * ((Vector2)transform.right).normalized;
            // 往上初速度
            rb.velocity += Mathf.Sqrt(2f * jumpHeight * gravity) * (Vector2)transform.up;
            jump = false;
            canJump = false;
            StartCoroutine(JumpCoolDown(jumpCoolDown));
        }
            
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "Player") {
            // TODO: Hurt player
            Vector2 direct = player.transform.position - planet.transform.position;
            Vector3 knockback = direction < 0 ? new Vector3(direct.y, -direct.x, 0) : new Vector3(-direct.y, direct.x, 0);
            player.transform.position = player.transform.position - knockback.normalized * 8;
        }
    }

    private bool IsPlayerInJumpRange() {
        Vector3 playerPos = player.transform.position;
        float distance = (playerPos - transform.position).magnitude;

        if (distance <= jumpRange / 2) {
            return true;
        }
        else {
            return false;
        }
    }
}
