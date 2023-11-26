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
    private Rigidbody2D rb;

    [Header("移動")]
    private float direction;
    private bool jump;

    [Header("星球上移動")]
    public float maxWalkSpeed;
    public float WalkAcceleration;

    [Header("星球上跳躍")]
    [DisplayOnly] public bool isGrounded;
    [DisplayOnly] public float height;      // 物體海拔（RayCast 檢測發生距離）
    [DisplayOnly] public float gravity;     // 所受重力
    public float jumpHeight;                // 跳躍高度
    public float launchAcceleration;        // 發射加速度
    public float footOffset = 0.5f;         // RayCast 起點
    public float raycastDistance;           // RayCast 長度（要設定超大）
    public LayerMask groundLayer;           // RayCast 層設定

    [Header("攻擊")]
    public float detectRange = 10f;
    public float damage = 10f;
    [DisplayOnly] public bool isPlayerLocked = false;       // 玩家是否被敵人鎖定
    [DisplayOnly] public bool isPlayerOnceInRange = false;  // 玩家是否曾在感知範圍內 

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


    private void GroundCheck()
    {
        Vector2 position = (Vector2)transform.position - (Vector2)transform.up * footOffset; // 射線起點
        RaycastHit2D raycast = Physics2D.Raycast(position, -(Vector2)transform.up, raycastDistance, groundLayer);
        height = raycast.distance;
        if (raycast && height < 1f)
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

    private void Walk()
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

    private void Jump()
    {
        if (isGrounded && jump)
        {
            // 只保留水平方向的速度
            rb.velocity = Vector2.Dot(rb.velocity, ((Vector2)transform.right).normalized) * ((Vector2)transform.right).normalized;
            // 往上初速度
            rb.velocity += Mathf.Sqrt(2f * jumpHeight * gravity) * (Vector2)transform.up;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "Player") {
            // TODO: Hurt player
            player.transform.position = player.transform.position - (Vector3)other.contacts[0].normal * 8;
        }
    }

    private void DetectPlayer() {
        if (IsPlayerInRange()) {
            CaculateDirection();
        }
        else {
            if (!isPlayerLocked) {
                direction = 0;
            }
        }
    }

    public bool IsPlayerInRange() {
        Vector3 playerPos = player.transform.position;
        float distance = (playerPos - transform.position).magnitude;

        if (distance <= detectRange/2) {
            isPlayerOnceInRange = true;
            return true;
        }
        else {
            if (isPlayerOnceInRange) {
                isPlayerLocked = false;
                isPlayerOnceInRange = false;
            }
            return false;
        }
    }

    public void CaculateDirection() {
        if (!isPlayerLocked) {
            // 玩家若尚未被鎖定
            // 鎖定玩家 (同時避免重複執行此函式)
            isPlayerLocked = true;

            // 玩家相對於星球中心的向量
            Vector3 playerToCenter = player.transform.position - planet.transform.position;

            // 敵人相對於星球中心的向量
            Vector3 enemyToCenter = transform.position - planet.transform.position;

            // 使用Vector3.Cross計算兩個向量的外積，以確定玩家在敵人的左邊還是右邊
            float crossProduct = Vector3.Cross(enemyToCenter, playerToCenter).z;

            // 如果外積為正，玩家在敵人的左邊，反之在右邊
            if (crossProduct > 0) {
                // 玩家在左邊，敵人向左移動
                Debug.Log("Enemy Go Left.");
                direction = -1f;
            }
            else if (crossProduct <= 0) {
                // 玩家在右邊，敵人向右移動
                Debug.Log("Enemy Go Right.");
                direction = 1f;
            }
        }
    }

    public void StopMove() {
        isPlayerLocked = false;
        isPlayerOnceInRange = false;
        direction = 0;
    }
}

