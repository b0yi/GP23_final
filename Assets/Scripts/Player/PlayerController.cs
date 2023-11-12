using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;



public class PlayerController : MonoBehaviour
{
    [Header("狀態")]
    public string stage;

    [Header("星球上移動")]
    public float maxMoveSpeed;
    public float moveForce;

    [Header("星球上跳躍")]
    public float footOffset = 0.5f;
    public float groundDistance = 0.1f;
    public LayerMask groundLayer;
    public bool isGrounded;
    public float jumpHeight;
    public float gravity = 20f;

    [Header("升空")]
    public float maxLaunchForce;
    public float launchForceRate;
    public float launchForce = 0f;

    [Header("太空")]
    public float maxDriveSpeed;
    public float driveForce;
    public float maxAngularVelocity;
    public float turnTorque;
    public GameObject dashboard;

    [Header("降落")]
    public float landingForce = 100f;

    private PlayerInputHandler _input;
    private Rigidbody2D _rb;

    private float _movement;
    private float _turn;
    private bool _jump;
    private bool _ignition;

    [Header("相機")]
    public CinemachineVirtualCamera vcam;
    public float onPlanetOrtho;
    public float inSpaceOrtho;
    public float orthoSmoothSpeed; // true for OnPlanet
    public bool orthoStatus = true; // true for OnPlanet
    public float changeHeight;
    // test
    private void Ortho()
    {

        if (stage == "Launch" || stage == "Landing")
        {
            if (transform.position.y < changeHeight)
            {
                orthoStatus = true;
            }
            else
            {
                orthoStatus = false;
            }
        }


        if (orthoStatus)
        {
            // OnPlanet
            vcam.m_Lens.OrthographicSize = Mathf.MoveTowards(vcam.m_Lens.OrthographicSize, onPlanetOrtho, orthoSmoothSpeed * Time.deltaTime);
        }
        else
        {
            vcam.m_Lens.OrthographicSize = Mathf.MoveTowards(vcam.m_Lens.OrthographicSize, inSpaceOrtho, orthoSmoothSpeed * Time.deltaTime);
        }





    }



    void Start()
    {
        stage = "OnPlanet";
        _input = GetComponent<PlayerInputHandler>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _movement = _input.movement;
        _turn = _input.turn;
        _jump = _input.jump;
        _ignition = _input.ignition;


        Ortho();

    }

    void FixedUpdate()
    {
        GroundCheck();

        if (stage == "OnPlanet")
        {
            Move();
            Jump();
        }
        if (stage == "Launch")
        {
            Launch();
        }
        if (stage == "InSpace")
        {
            Drive();
            Turn();
        }
        if (stage == "Landing")
        {
            Landing();
        }
    }

    private void Move()
    {

        if (isGrounded)
        {
            if (_movement == 0)
            {
                // 只保留垂直方向的速度
                _rb.velocity = Vector2.Dot(_rb.velocity, ((Vector2)transform.up).normalized) * ((Vector2)transform.up).normalized;
            }
            else
            {
                Vector2 horizontalVelocity = Vector2.Dot(_rb.velocity, ((Vector2)transform.right).normalized) * ((Vector2)transform.right).normalized;
                if (horizontalVelocity.magnitude < maxMoveSpeed)
                {
                    // 水平加速
                    _rb.AddForce(_movement * moveForce * ((Vector2)transform.right).normalized);
                }
            }
        }


    }

    private void Jump()
    {
        if (isGrounded && _jump)
        {
            _rb.velocity += Mathf.Sqrt(2f * jumpHeight * gravity) * (Vector2)transform.up;
        }
    }

    private void GroundCheck()
    {
        Vector2 position = (Vector2)transform.position - (Vector2)transform.up * footOffset;
        RaycastHit2D check = Physics2D.Raycast(position, -(Vector2)transform.up, groundDistance, groundLayer);

        if (check)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        Color color = check ? Color.red : Color.green;
        Debug.DrawRay(position, -(Vector2)transform.up * groundDistance, color);
    }


    private void Landing()
    {
        _rb.AddForce(landingForce * ((Vector2)transform.up).normalized);
    }


    private void Launch()
    {

        if (_ignition)
        {
            if (launchForce < maxLaunchForce)
            {
                launchForce += launchForceRate * Time.fixedDeltaTime;
            }
        }
        else
        {
            launchForce = landingForce;
        }

        _rb.AddForce(launchForce * ((Vector2)transform.up).normalized);

    }


    private void Drive()
    {
        if (_ignition && _rb.velocity.magnitude < maxDriveSpeed)
        {
            _rb.AddForce(driveForce * ((Vector2)transform.up).normalized);
        }
    }

    private void Turn()
    {
        if (_turn != 0)
        {
            _rb.AddTorque(-_turn * turnTorque);
        }

        if (_rb.angularVelocity > maxAngularVelocity)
            _rb.angularVelocity = maxAngularVelocity;

        if (_rb.angularVelocity < -maxAngularVelocity)
            _rb.angularVelocity = -maxAngularVelocity;

    }



    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Launcher" && Input.GetKeyDown(KeyCode.F))
        {
            if (stage == "OnPlanet")
            {
                ChangeStage("Launch");
            }
            else if (stage == "Launch" && isGrounded)
            {
                ChangeStage("OnPlanet");
            }
        }

        if (collider.gameObject.name == "Launcher" && stage == "Landing" && isGrounded)
        {
            ChangeStage("OnPlanet");
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (stage == "InSpace" && collider.gameObject.name == "Field")
        {
            ChangeStage("Landing");
        }

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (stage == "Launch" && collider.gameObject.name == "Field")
        {
            ChangeStage("InSpace");
        }
    }


    void ChangeStage(string stageName)
    {
        // before
        if (stage == "InSpace")
        {
            _rb.drag = 0;
            _rb.angularDrag = 1000f;
            dashboard.SetActive(false);
        }


        // change
        _input.ChangeActionMap(stageName);
        stage = stageName;

        // after
        if (stage == "InSpace")
        {
            _rb.drag = 1f;
            _rb.angularDrag = 1f;
            dashboard.SetActive(true);
        }


        if (stage == "Launch")
        {
            transform.position = new Vector3(0, 30.5f, 0);
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = 0;
        }
        if (stage == "Landing")
        {
            transform.position = new Vector3(0, transform.position.y, 0);
            _rb.velocity = Vector3.zero;
        }
        print("Change stage to: " + stage);


    }



}