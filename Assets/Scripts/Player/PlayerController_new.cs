using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.Playables;

public enum Location
{
    Planet,
    Space,
}

public enum PlayerState
{
    OnPlanet,
    Transform,
    Launch,
    InSpace
}


public class PlayerController_new : MonoBehaviour
{

    private Rigidbody2D _rb;
    [DisplayOnly] public float fuel;            // 油量/電量（0 - 100）

    [DisplayOnly] public float horizontal;
    [DisplayOnly] public bool up;

    [DisplayOnly] public Location location;

    [Header("星球上動作")]
    public float walkSpeed;
    public float jumpHeight;
    public float launchAcceleration;


    public GameObject planet;                   // 所在星球
    [DisplayOnly] public bool isGrounded;
    [DisplayOnly] public PlayerState playerState;


    [Header("變身時間")]
    [DisplayOnly] public float transformTimer;
    public float transformTime;

    private float _gravity;

    [Header("阻力")]
    public float linearDragOnPlanet;
    public float angularDragOnPlanet;
    public float linearDragInSpace;
    public float angularDragInSpace;

    [Header("太空移動")]
    public float driveAcceleration;
    public float turnAcceleration;


    // ======== animation ========
    private Animator _animator;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        fuel = 100f;
        transformTimer = transformTime;
        location = Location.Planet;
        _animator = GetComponent<Animator>();
        isGrounded = false;
        playerState = PlayerState.OnPlanet;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        up = Input.GetKey(KeyCode.W);

        _gravity = planet.GetComponent<PlanetGravity>().gravity;

    }


    void FixedUpdate()
    {

        WalkOrNot();

        JumpOrNot();

        LaunchOrNot();

    }


    private void WalkOrNot()
    {

        if (playerState == PlayerState.OnPlanet && isGrounded)
        {
            if (horizontal != 0)
            {
                int param = (horizontal > 0f) ? 1 : -1;
                transform.localScale = new Vector3(param, 1f, 1f); // 角色左右轉向 
                _rb.velocity = param * walkSpeed * transform.right.normalized;
                _animator.SetTrigger("walk");
            }
            else
            {
                _animator.SetTrigger("idle");
            }
        }


    }

    private void JumpOrNot()
    {
        if (playerState == PlayerState.OnPlanet && isGrounded && up)
        {
            // 先歸零垂直方向的速度, 然後加入往上初速度
            _rb.velocity = Vector2.Dot(_rb.velocity, ((Vector2)transform.right).normalized) * ((Vector2)transform.right).normalized;
            _rb.velocity += Mathf.Sqrt(2f * jumpHeight * _gravity) * (Vector2)transform.up.normalized;
            isGrounded = false;
        }
    }

    private void LaunchOrNot()
    {
        if (playerState == PlayerState.OnPlanet && !isGrounded && Mathf.Abs(Vector2.Dot(_rb.velocity, ((Vector2)transform.up).normalized)) < 0.2f && up)
        {
            playerState = PlayerState.Transform;
            _animator.SetTrigger("transform");
            transformTimer = transformTime;
        }

        if (playerState == PlayerState.Transform)
        {
            _rb.velocity = Vector2.zero;
            _rb.AddForce(_gravity * _rb.mass * transform.up); // F = m a
            transformTimer -= Time.fixedDeltaTime;

            if (!up)
            {
                playerState = PlayerState.OnPlanet;
                _animator.SetTrigger("untransform");
            }

            if (transformTimer <= 0f)
            {
                playerState = PlayerState.Launch;
                // _rb.velocity = (Vector2)transform.up.normalized * launchSpeed;
                _animator.SetTrigger("space");
            }
        }

        if (playerState == PlayerState.Launch)
        {

            _rb.AddForce((_gravity + launchAcceleration) * _rb.mass * transform.up); // F = m a


            if (!up)
            {
                playerState = PlayerState.OnPlanet;
                _animator.SetTrigger("untransform");
            }
        }

        if (playerState == PlayerState.InSpace)
        {
            if (up)
            {
                _rb.AddForce(driveAcceleration * _rb.mass * transform.up);
            }
            if (horizontal != 0)
            {
                _rb.AddTorque(-horizontal * turnAcceleration * _rb.mass * .5f); // .5 是力臂

            }
        }



    }




    private void Turn()
    {
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            transformTimer = transformTime;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Field")
        {
            playerState = PlayerState.Launch;
            _rb.drag = linearDragOnPlanet;
            _rb.angularDrag = angularDragOnPlanet;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Field")
        {
            playerState = PlayerState.InSpace;
            _rb.drag = linearDragInSpace;
            _rb.angularDrag = angularDragInSpace;
        }

    }


}