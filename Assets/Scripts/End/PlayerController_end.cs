using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.Playables;
using System;
using UnityEngine.Rendering.Universal;



public class PlayerController_end : MonoBehaviour
{
    [Header("粒子特效")]
    public ParticleSystem fireParticleSystem;
    public ParticleSystem speedupParticleSystem;
    public Light2D  playerLight;

    [Header("鎖定")]
    [DisplayOnly] public bool isLocked;
    [DisplayOnly] public bool isFreezed;



    [Header("星球上移動跳躍")]
    public float walkSpeed;
    public float jumpHeight;
    public float launchAcceleration;

    [Header("狀態")]
    [DisplayOnly] public PlayerState playerState;
    [DisplayOnly] public bool isGrounded;

    [Header("所在星球")]
    public GameObject planet;
    public LayerMask groundLayer;


    [Header("阻力")]
    public float linearDragOnPlanet;
    public float angularDragOnPlanet;
    public float linearDragInSpace;
    public float angularDragInSpace;

    [Header("鍵盤輸入")]
    [DisplayOnly] public float horizontal;
    [DisplayOnly] public bool up;

    private Animator _animator;
    private float _gravity;
    private Rigidbody2D _rb;



    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        isGrounded = false;
        playerState = PlayerState.OnPlanet;

        if (fireParticleSystem.isPlaying)
        {
            fireParticleSystem.Stop();
        }
        if (speedupParticleSystem.isPlaying)
        {
            speedupParticleSystem.Stop();
        }
    }


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        up = Input.GetKey(KeyCode.W);

        if (planet)
        {
            _gravity = planet.GetComponent<PlanetGravity>().gravity;
        }


    }


    void FixedUpdate()
    {

        WalkOrNot();

        JumpOrNot();

        _animator.SetInteger("state", (int)playerState);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 10f, groundLayer);
        _animator.SetFloat("height", hit.distance);

    }



    private void WalkOrNot()
    {
        if (playerState == PlayerState.OnPlanet)
        {
            if (horizontal != 0)
            {
                int param = (horizontal > 0f) ? 1 : -1;
                transform.localScale = new Vector3(param, 1f, 1f); // 角色左右轉向 
                _rb.velocity = Vector2.Dot(_rb.velocity, ((Vector2)transform.up).normalized) * ((Vector2)transform.up).normalized
                                + param * walkSpeed * ((Vector2)transform.right).normalized;

                _animator.SetBool("walk", true);

            }
            else
            {
                _rb.velocity = Vector2.Dot(_rb.velocity, ((Vector2)transform.up).normalized) * ((Vector2)transform.up).normalized;
                _animator.SetBool("walk", false);
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


        float vertical = Vector2.Dot(_rb.velocity, ((Vector2)transform.up).normalized);
        if (vertical < 1.6f && vertical > -1.6f) {
            _animator.SetInteger("vertical", 0);
        }
        else if (vertical > 1.6f) {
            _animator.SetInteger("vertical", 1);
        }
        else if (vertical < -1.6f) {
            _animator.SetInteger("vertical", -1);
        }
    }





    void OnCollisionEnter2D(Collision2D other)
    {

        if ((1 << other.gameObject.layer & groundLayer) == 1 << other.gameObject.layer)
        {
            isGrounded = true;
        }



    }

    void OnCollisionExit2D(Collision2D other)
    {
        if ((1 << other.gameObject.layer & groundLayer) == 1 << other.gameObject.layer)
        {
            isGrounded = false;
        }
    }


}

