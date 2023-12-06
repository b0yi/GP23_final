using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("玩家")]
    public GameObject player;

    [Header("所在星球")]
    public GameObject planet;

    [Header("狀態")]
    [DisplayOnly] public string stage;      // OnPlanet | InSpace
    protected Rigidbody2D rb;

    [Header("移動")]
    protected float direction;
    [DisplayOnly] public bool jump;

    [Header("星球上移動")]
    public float maxWalkSpeed;
    public float WalkAcceleration;

    [Header("星球上跳躍")]
    [DisplayOnly] public bool isGrounded;
    [DisplayOnly] public float height;      // 物體海拔（RayCast 檢測發生距離）
    [DisplayOnly] public float gravity;     // 所受重力
    [DisplayOnly] public bool canJump = true;  // 可否跳躍
    public float jumpCoolDown = 1f;
    public float jumpHeight;                // 跳躍高度
    public float jumpRange;                 // 可起跳距離
    public float launchAcceleration;        // 發射加速度
    public float footOffset = 0.5f;         // RayCast 起點
    public float raycastDistance;           // RayCast 長度（要設定超大）
    public LayerMask groundLayer;           // RayCast 層設定

    [Header("太空移動")]
    public float maxDriveSpeed;
    public float driveAcceleration;

    public float maxTurnAngularVelocity;
    public float turnAcceleration;

    [Header("降落")]
    public float resistAcceleration;

    [Header("攻擊")]
    public float detectRange = 10f;
    public float damage = 10f;
    [DisplayOnly] public bool chasePlayer = false;          // 是否要追玩家
    [DisplayOnly] public bool isPlayerInEnemyRange = false; // 玩家是否在感知範圍內 

    [Header("其他部分 (e.g. Inherited Class)")]
    [DisplayOnly] public bool IUnderstoodThis = true;

    void Start()
    {
        stage = "OnPlanet";
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (stage == "OnPlanet")
        {
            gravity = planet.GetComponent<PlanetGravity>().gravity;
        }

        DetectPlayer();
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

    protected void GroundCheck()
    {
        Vector2 position = (Vector2)transform.position - (Vector2)transform.up * footOffset; // 射線起點
        RaycastHit2D raycast = Physics2D.Raycast(position, -(Vector2)transform.up, raycastDistance, groundLayer);
        height = raycast.distance;
        if (raycast && height < 0.15f)
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

    protected void Walk()
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
                transform.localScale = (direction > 0) ? new Vector3(-3f, 3, 1) : new Vector3(3f, 3, 1);
                Vector2 horizontalVelocity = Vector2.Dot(rb.velocity, ((Vector2)transform.right).normalized) * ((Vector2)transform.right).normalized;
                if (horizontalVelocity.magnitude < maxWalkSpeed)
                {
                    // 水平加速
                    rb.AddForce(direction * WalkAcceleration * rb.mass * ((Vector2)transform.right).normalized);
                }
            }
        }
    }

    protected virtual void Jump()
    {
        if (isGrounded && jump)
        {
            // 只保留水平方向的速度
            rb.velocity = Vector2.Dot(rb.velocity, ((Vector2)transform.right).normalized) * ((Vector2)transform.right).normalized;
            // 往上初速度
            rb.velocity += Mathf.Sqrt(2f * jumpHeight * gravity) * (Vector2)transform.up;
        }
    }





    protected virtual void DetectPlayer() {
        if (IsPlayerInRange(detectRange) || chasePlayer) {
            CaculateDirection();
        }
        else {
            direction = 0;
        }
    }

    /// <summary>
    /// Use to detect whether player is in the given range.
    /// </summary>
    /// <param name="rangeToDetect">The range you want to check. (e.g. detectRange)</param>
    /// <returns>Return true if player is in the range, else false.</returns>
    protected bool IsPlayerInRange(float rangeToDetect) {
        Vector3 playerPos = player.transform.position;
        float distance = (playerPos - transform.position).magnitude;

        if (distance <= rangeToDetect / 2) {
            isPlayerInEnemyRange = true;
            return true;
        }
        else {
            isPlayerInEnemyRange = false;
            return false;
        }
    }

    public void CaculateDirection() {
        // 玩家相對於星球中心的向量
        Vector3 playerToCenter = player.transform.position - planet.transform.position;

        // 敵人相對於星球中心的向量
        Vector3 enemyToCenter = transform.position - planet.transform.position;

        // 使用Vector3.Cross計算兩個向量的外積，以確定玩家在敵人的左邊還是右邊
        float crossProduct = Vector3.Cross(enemyToCenter, playerToCenter).z;

        // 如果外積為正，玩家在敵人的左邊，反之在右邊
        if (crossProduct > 0) {
            // 玩家在左邊，敵人向左移動
            // Debug.Log("Enemy Go Left.");
            direction = -1f;
        }
        else if (crossProduct <= 0) {
            // 玩家在右邊，敵人向右移動
            // Debug.Log("Enemy Go Right.");
            direction = 1f;
        }
    }

    protected IEnumerator JumpCoolDown(float sec) {
        yield return new WaitForSeconds(sec);
        canJump = true;
    }

    public void GoChasePlayer() {
        chasePlayer = true;
    }
}

