using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerController : MonoBehaviour
{

    [Header("狀態")]
    [DisplayOnly] public string stage;      // OnPlanet | InSpace
    private Rigidbody2D _rb;
    [DisplayOnly] public float fuel;        // 油量/電量（0 - 100）
    public float fuelDelta;
    [DisplayOnly] public bool direction;    // 速度往上 or 往下 or 0
    [DisplayOnly] public UIManager uIManager;
    [DisplayOnly] public bool isLocked;


    [Header("輸入")]
    private InputHandler _inputHandler;
    private float _horizontal;
    private bool _w;

    [Header("相機")]
    public CinemachineVirtualCamera vcam;
    public float changeOrthographicSpeed;
    [DisplayOnly] public float targetOrthographicSize;
    public GameObject dashboard;
    public GameObject arrowContainer;


    [Header("星球上移動")]
    public float maxWalkSpeed;
    public float WalkAcceleration;

    [Header("星球上跳躍")]
    [DisplayOnly] public bool isGrounded;
    [DisplayOnly] public float height;      // 物體海拔（RayCast 檢測發生距離）
    [DisplayOnly] public float gravity;     // 所受重力
    public float jumpHeight;                // 跳躍高度
    public GameObject planet;               // 所在星球
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





    void Start()
    {
        uIManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        stage = "OnPlanet";
        targetOrthographicSize = 10f;
        dashboard.SetActive(true);
        arrowContainer.SetActive(false);
        _rb = GetComponent<Rigidbody2D>();
        _inputHandler = GetComponent<InputHandler>();
        fuel = 100f;
        isLocked = false;
    }

    void Update()
    {

        _horizontal = _inputHandler.horizontal;
        _w = _inputHandler.w;
        if (stage == "OnPlanet")
        {
            gravity = planet.GetComponent<PlanetGravity>().gravity;
        }
        if (stage == "InSpace")
        {
            arrowContainer.SetActive(true);
        }

        vcam.m_Lens.OrthographicSize = Mathf.Lerp(vcam.m_Lens.OrthographicSize, targetOrthographicSize, changeOrthographicSpeed * Time.deltaTime);

    }

    void FixedUpdate()
    {
        GroundCheck();

        if (stage == "OnPlanet" && (!isLocked))
        {
            Walk();
            Jump();
            Launch();
        }

        if (stage == "InSpace" && (!isLocked))
        {
            Drive();
            Turn();
        }

        if (stage == "Landing")
        {
            Land();
        }


        if (isGrounded)
        {
            direction = false;
        }
        else
        {
            if (Vector2.Dot(_rb.velocity, transform.up) > 0)
            {
                direction = true;
            }
            else if (Vector2.Dot(_rb.velocity, transform.up) < -1)
            {
                direction = false;
            }
        }


    }


    private void GroundCheck()
    {
        Vector2 position = (Vector2)transform.position - (Vector2)transform.up * footOffset; // 射線起點
        RaycastHit2D raycast = Physics2D.Raycast(position, -(Vector2)transform.up, raycastDistance, groundLayer);
        height = raycast.distance;
        if (raycast && height < .05)
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

            if (_horizontal == 0)
            {
                // 只保留垂直方向的速度
                _rb.velocity = Vector2.Dot(_rb.velocity, ((Vector2)transform.up).normalized) * ((Vector2)transform.up).normalized;
            }
            else
            {
                transform.localScale = (_horizontal > 0) ? new Vector3(1f, 1, 1) : new Vector3(-1f, 1, 1);
                Vector2 horizontalVelocity = Vector2.Dot(_rb.velocity, ((Vector2)transform.right).normalized) * ((Vector2)transform.right).normalized;
                if (horizontalVelocity.magnitude < maxWalkSpeed)
                {
                    // 水平加速
                    _rb.AddForce(_horizontal * WalkAcceleration * _rb.mass * ((Vector2)transform.right).normalized);
                }
            }
        }


    }

    private void Jump()
    {
        if (isGrounded && _w)
        {
            // 只保留水平方向的速度
            _rb.velocity = Vector2.Dot(_rb.velocity, ((Vector2)transform.right).normalized) * ((Vector2)transform.right).normalized;
            // 往上初速度
            _rb.velocity += Mathf.Sqrt(2f * jumpHeight * gravity) * (Vector2)transform.up;
        }
    }

    private void Launch()
    {

        if (_w && height > (jumpHeight - .1))
        {
            // 只保留垂直方向的速度（TODO 怪怪的，先左右好像起飛會比較快）
            _rb.velocity = Vector2.Dot(_rb.velocity, ((Vector2)transform.up).normalized) * ((Vector2)transform.up).normalized;
            _rb.AddForce((launchAcceleration + gravity) * _rb.mass * transform.up);
            // 這邊可能有 bug，IDK
        }

    }

    private void Land()
    {
        // _rb.AddForce(_rb.mass * resistAcceleration * transform.up);
        if (isGrounded)
        {
            ChangeStage("OnPlanet");
        }
    }

    private void Drive()
    {

        if (_w)
        {
            _rb.AddForce(driveAcceleration * _rb.mass * ((Vector2)transform.up).normalized);
        }

        if (_rb.velocity.magnitude > maxDriveSpeed)
        {
            _rb.velocity = _rb.velocity.normalized * maxDriveSpeed;
        }

        if (_w)
        {
            // TODO
            fuel -= fuelDelta;
            if (fuel <= 0)
            {
                uIManager.LoadPlayScene();
            }
        }
    }

    private void Turn()
    {
        if (_horizontal != 0)
        {
            _rb.AddTorque(-_horizontal * turnAcceleration * _rb.mass * .5f); // .5 是力臂
        }

        if (_rb.angularVelocity > maxTurnAngularVelocity)
            _rb.angularVelocity = maxTurnAngularVelocity;

        if (_rb.angularVelocity < -maxTurnAngularVelocity)
            _rb.angularVelocity = -maxTurnAngularVelocity;
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
        if (stage == "OnPlanet" && collider.gameObject.name == "Field")
        {
            ChangeStage("InSpace");
        }
    }

    void ChangeStage(string stageName)
    {
        // before
        if (stage == "InSpace")
        {
            // 從太空到 ...
            _rb.drag = 0;
            _rb.angularDrag = 1000f;
            targetOrthographicSize = 10f;
        }

        // change
        stage = stageName;

        // after
        if (stage == "InSpace")
        {
            // 從 ... 到太空
            targetOrthographicSize = 20f;
            _rb.drag = 1f;
            _rb.angularDrag = 10f;

        }


        if (stage == "Landing")
        {
            _rb.velocity = Vector3.zero;
        }
    }
}