using UnityEngine;

/// <summary>
/// 星球重力
/// 受重力影響的物件 e.g., Player call AddGravity()
/// 參考：https://www.youtube.com/watch?v=gHeQ8Hr92P4
/// </summary>
public class PlanetGravity : MonoBehaviour
{
    [Header("重力加速度")]
    public float gravity = 20f;

    private readonly float slerpAlpha = 1000;

    public void AddGravity(Transform objectTF)
    {
        // 加入從 player 到 planet 方向的力（重力）
        Vector2 gravityDirection = ((Vector2)(transform.position - objectTF.position)).normalized;
        Rigidbody2D objectRB = objectTF.GetComponent<Rigidbody2D>();
        objectRB.AddForce(gravity * objectRB.mass * gravityDirection); // F = m a

        // 物件隨位置旋轉（底部永遠朝向星球中心）
        Vector2 playerUpDirection = (Vector2)objectTF.up;
        Quaternion playerRotation = Quaternion.FromToRotation((Vector3)playerUpDirection, -(Vector3)gravityDirection) * objectTF.rotation;
        // objectTF.rotation = Quaternion.Slerp(objectTF.rotation, playerRotation, Time.deltaTime * slerpAlpha);
        objectTF.rotation = playerRotation;
    }
}